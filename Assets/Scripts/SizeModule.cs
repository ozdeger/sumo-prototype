using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModule : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float sizeIncraseAmount;
    private HitModule hm;
    private ControllerModule cm;

    void Start()
    {
        hm = GetComponent<HitModule>();
        cm = GetComponent<ControllerModule>();
    }

    // increase object size and hit force multiplier
    public void IncreaseSize()
    {
        transform.localScale =  new Vector3(transform.localScale.x+sizeIncraseAmount,transform.localScale.y+sizeIncraseAmount,transform.localScale.z+sizeIncraseAmount);
        hm.IncreaseSize(sizeIncraseAmount);
        if (cm)
        {
            cm.indicatorDistance += sizeIncraseAmount / 2;
        }
    }
}
