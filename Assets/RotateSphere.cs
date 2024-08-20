using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public Transform player;  
    public float rotationSpeed = 50f;  
    public float detectionRadius = 5f;

    private Vector3 originalPosition;

   
    void Start()
    {
        originalPosition = transform.position;
    }

    
    void Update()
    {
        float distance = Vector3.Distance(player.position, originalPosition);

       
        if (distance <= detectionRadius)
        {
            
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
