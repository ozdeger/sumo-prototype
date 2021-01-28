using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject collectable;

    [Header("Spawn Settings")]
    public float spawnRadius;
    public float spawnHeight;
    public int collectableCount;


    void Start()
    {
        // Fill the scene with collectables
        for(int i = 0; i < collectableCount; i++)
        {
            SpawnCollectableAtRandom();
        }
    }

    public void SpawnCollectableAtRandom()
    {
        // Instantiate new collectable
        Transform summon = Instantiate(collectable).transform;
        Vector2 randomUnitCircle = Random.insideUnitCircle * spawnRadius;
        summon.transform.position = new Vector3(randomUnitCircle.x, spawnHeight, randomUnitCircle.y);
        summon.GetComponent<Collectable>().cs = this;
    }
}
