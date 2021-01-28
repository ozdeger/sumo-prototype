using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCountText : MonoBehaviour
{
    private TMP_Text tmp;

    void Start()
    {
        tmp = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        tmp.text = InstanceSingleton.Instance.characters.Count.ToString();
    }
}
