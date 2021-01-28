using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private TMP_Text scoreText; 


    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        UpdateScore(0); // set start score as 0
    }

    // update UI with new score on change
    public void UpdateScore(int add)
    {
        score += add;
        scoreText.text = score.ToString();
    }
}
