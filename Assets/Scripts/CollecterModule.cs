using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollecterModule : MonoBehaviour
{
    [Header("Optional")]
    [SerializeField] private ScoreBoard scoreboard;
    private int score = 0;
    private AIModule AI;
    private SizeModule sm;


    private void Start()
    {
        sm = GetComponent<SizeModule>();
        AI = GetComponent<AIModule>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Collectable>(out Collectable collectable))
        {
            collectable.Collected();

            score += collectable.score;

            if (scoreboard)   // Update score UI if UI is given
            {
                scoreboard.UpdateScore(collectable.score);
            }

            if (AI)  // Request new decision from AI if character has AI module
            {
                AI.DecideAction();
            }

            if (sm) // Increase Size if character has size module
            {
                sm.IncreaseSize();
            }
        }
    }
}
