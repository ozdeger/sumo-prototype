using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModule : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float eliminationYCordinate;

    private Vector2 direction;  // Current Movement Direction
    private Quaternion lookRotation;
    private Rigidbody rb;

    // drag variables
    private bool dragging = false;
    private Vector3 dragVelocity;

    private ControllerModule cm;
    private float startYCord;

    void Start()
    {
        InstanceSingleton.Instance.characters.Add(this); // Register instance to active character instances
        rb = GetComponent<Rigidbody>();
        cm = GetComponent<ControllerModule>(); // used to determine if this cahracter is played controlled
        startYCord = transform.position.y; 
    }

    private void OnDestroy()
    {
        InstanceSingleton.Instance.characters.Remove(this); // remove register
    }

    private void FixedUpdate()
    {
        if (!dragging)
        {
            lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.y)); //create the rotation we need to be in to look at the target
            
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.fixedDeltaTime * rotateSpeed); //rotate us over time according to speed until we are in the required rotation

            rb.velocity = new Vector3(transform.forward.x * moveSpeed, rb.velocity.y, transform.forward.z * moveSpeed); // Change velocity with desired movespeed towards desired direction
        }
        else
        {
            // Drag object by Fading dragVelocity slowly 
            rb.velocity = new Vector3(dragVelocity.x, 0, dragVelocity.z);
            dragVelocity *= .9f;
            if (dragVelocity.magnitude < 0.25f)
            {
                dragging = false;
            }
        }

        // if character gone down by a little bit, close its collider block hanging at the side of arena
        if (transform.position.y + .1f < startYCord) 
        {
            GetComponent<Collider>().enabled = false;
        }

        // Character is below deadline eliminate it
        if (transform.position.y < eliminationYCordinate)
        {
            Eliminated();
        }
    }

    // Recieve hit from HitModule
    public void GotHit(Vector3 _dragVelocity)
    {
        dragVelocity = _dragVelocity;
        dragging = true;
    }

    // Recieve direction from ControllerModule / AIModule
    public void SetDirection(Vector2 dirXZ)
    {
        direction = dirXZ;
    }

    // If character is player controlled restart scene else destroy it
    public void Eliminated()
    {
        if (cm)
        {
            LevelController.ManualRestart();
        }
        Destroy(gameObject);
    }
}
