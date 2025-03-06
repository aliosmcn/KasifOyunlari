using System;
using UnityEngine;

public class Oyun2_CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    private Vector3 newPosition;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (target == null) return;
    
        newPosition = target.position + offset;
    
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.1f);
    }
}
