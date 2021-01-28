using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelController : MonoBehaviour
{
    // Countdown for level end
    [SerializeField] private float countdown;

    [Header("Optional")]
    [SerializeField] private TMP_Text timeText;

    private Transform player;
    private bool playerExist;


    private void FixedUpdate()
    {
        // count-down
        countdown -= Time.fixedDeltaTime;   

        // Update ui with time if it exists
        if (timeText)
        {
            int minutes = (int)(countdown / 60);
            int seconds = (int)(countdown % 60);

            if (seconds > 9)
            {
                timeText.text = string.Format("{0}:{1}", minutes, seconds);
            }
            else
            {
                timeText.text = string.Format("{0}:0{1}", minutes, seconds);
            }
        }


        if (InstanceSingleton.Instance.characters.Count == 1)      // if 1 character left standing
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (countdown < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // if countdown ended
        }

        
    }

    public static void ManualRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    // static restart for Player elimination
    }
}
