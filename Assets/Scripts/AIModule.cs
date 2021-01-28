using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIModule : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField] private float decisionTime;
    [SerializeField] private float agresiveness;

    private Transform currentTarget;
    private MovementModule mm;


    void Start()
    {
        mm = GetComponent<MovementModule>();
        float timingOffset = Random.Range(0, decisionTime); // creating an offset so that Every single agent will make their decison calculation at different frames (kills lag spikes)
        InvokeRepeating("DecideAction",0, decisionTime + timingOffset);  // Start Decision cloak
    }

    public void DecideAction()
    {
        Transform closestCharacter = InstanceSingleton.GetClosestCharacter(transform);
        Transform closestCollectable = InstanceSingleton.GetClosestCollectable(transform.position);
        if (closestCollectable) // check if any collectables exist
        {
            if (closestCharacter) // check if any other characters are alive
            {
                // if both are okay choose target by agresiveness
                float distanceToCharacter = (closestCharacter.position - transform.position).magnitude;
                float distanceToCollectable = (closestCollectable.position - transform.position).magnitude;
                if (distanceToCharacter * agresiveness > distanceToCollectable)
                {
                    currentTarget = closestCharacter;
                }
                else
                {
                    currentTarget = closestCollectable;
                }
            }
            else
            {
                currentTarget = closestCollectable;
            }
        }
    }

    private void FixedUpdate()
    {
        // Feed Movement Module with directions towards current target
        if (currentTarget) 
        {
            mm.SetDirection(new Vector2(currentTarget.position.x - transform.position.x, currentTarget.position.z - transform.position.z));
        }
    }
}
