using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionNotifier : MonoBehaviour
{
    // Sends collision info to chosen Hitmodule - used for tarcking hits from behind collider

    [SerializeField] private HitModule hitModule;

    private void OnCollisionEnter(Collision coll)
    {
        hitModule.GotCollisionFromBehind(coll);
    }
}
