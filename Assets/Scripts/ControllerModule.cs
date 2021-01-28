using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControllerModule : MonoBehaviour
{


    [Header("General")]
    [SerializeField] private Vector2 startDirection;
    [Header("Indicator Settings")]
    [SerializeField] private Transform wayIndicatorObject;
    public float indicatorDistance;

    private Vector2 clickPosition; // First Click Position
    private Vector2 direction;
    private MovementModule mm;

    void Start()
    {
        mm = GetComponent<MovementModule>();
        wayIndicatorObject.LookAt(transform.position);
        direction = startDirection;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            direction = ((Vector2)Input.mousePosition - clickPosition).normalized;
            // Set new direction to Movement module if direction is not (0,0)
            if (direction.sqrMagnitude > 0) 
            {
                mm.SetDirection(direction);
                wayIndicatorObject.LookAt(new Vector3(transform.position.x,wayIndicatorObject.transform.position.y,transform.position.z)); // rotate indicator
            }
        }
        // teleport indicator 
        wayIndicatorObject.transform.position = new Vector3(transform.position.x + (direction.x * indicatorDistance), wayIndicatorObject.position.y, transform.position.z + (direction.y * indicatorDistance));
    }
}
