using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float lerpSpeed;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        // Lerp towards player
        transform.position = Vector3.Lerp(transform.position, player.position + offset, lerpSpeed*Time.deltaTime);
    }
}
