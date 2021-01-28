using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitModule : MonoBehaviour
{
    [Header("Hit Settings")]
    [SerializeField] private float hitForce;
    [SerializeField] private float hitFromBehindMultiplier;
    private float sizeMultiplier = 1;
    private MovementModule mm;

    private void Start()
    {
        mm = GetComponent<MovementModule>();
    }

    // pass hit force to MovementModule
    public void GotCollisionFromBehind(Collision coll)
    {
        if (coll.transform.TryGetComponent<HitModule>(out HitModule otherHM))
        {
            if (mm != this)
            {
                float sizeDifferenceMultiplier = otherHM.sizeMultiplier / sizeMultiplier; // bigger self = less pushed back, smalller self = more pushed back
                mm.GotHit((transform.position - coll.transform.position).normalized * hitForce * hitFromBehindMultiplier *sizeDifferenceMultiplier);
            }
        }
    }

    // pass hit force to MovementModule
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.TryGetComponent<HitModule>(out HitModule otherHM))
        {
            float sizeDifferenceMultiplier = otherHM.sizeMultiplier / sizeMultiplier; // bigger self = less pushed back, smalller self = more pushed back
            mm.GotHit((transform.position - coll.transform.position).normalized * hitForce * sizeDifferenceMultiplier);
        }
    }

    // Used by SizeModule
    public void IncreaseSize(float amount)
    {
        sizeMultiplier += amount;
    }
}
