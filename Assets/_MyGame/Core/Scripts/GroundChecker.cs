using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _distanceForRaycast = 0.5f;
    [SerializeField] private LayerMask _groundMask;
    
    public bool IsGrounded { get; private set; }
    
    private void FixedUpdate()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, _distanceForRaycast, _groundMask);
    }
}