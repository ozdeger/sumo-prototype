using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSingleton : MonoBehaviour
{
    public List<MovementModule> characters = new List<MovementModule>();
    public List<Collectable> collectables = new List<Collectable>();


    public static InstanceSingleton Instance { get; private set; }


    private void Awake()
    {
        // Check if there are any other instanceSingletons if any destroy this
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public static Transform GetClosestCharacter(Transform requester)
    {
        float bestDistance = Mathf.Infinity;
        Transform bestCharacter = null;
        foreach(MovementModule character in Instance.characters)
        {
            if (requester != character.transform)
            {
                float distance = (character.transform.position - requester.position).magnitude;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestCharacter = character.transform;
                }
            }
        }
        return bestCharacter;
    }

    public static Transform GetClosestCollectable(Vector3 position)
    {
        float bestDistance = Mathf.Infinity;
        Transform bestCollectable = null;
        foreach(Collectable collectable in Instance.collectables)
        {
            float distance = (collectable.transform.position - position).magnitude;
            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestCollectable = collectable.transform;
            }
        }
        return bestCollectable;
    }
}
