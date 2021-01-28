using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int score;  // point amount rewarded to the character who picks this up
    [HideInInspector] public CollectableSpawner cs;
    

    void Start()
    {
        // register to Singleton
        InstanceSingleton.Instance.collectables.Add(this);
    }

    private void OnDestroy()
    {
        // remove register
        InstanceSingleton.Instance.collectables.Remove(this);
    }

    public void Collected()
    {
        // spawn new collectable and die
        cs.SpawnCollectableAtRandom();
        Destroy(gameObject);
    }
}
