using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

//public class RaycastColorChange : MonoBehaviour
//{
//    public float rayDistance = 2f;  // Distancia del Raycast
//    public LayerMask targetLayer;   // Capa del cubo objetivo
//    private Renderer cubeRenderer;
//    // Start is called before the first frame update
//    void Start()
//    {
//        cubeRenderer = GetComponent<Renderer>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        RaycastHit hit;

//        // Emite un raycast hacia adelante desde la posición del cubo
//        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, targetLayer))
//        {
//            // Cambia el color del cubo objetivo a verde si se detecta un impacto
//            hit.collider.GetComponent<Renderer>().material.color = Color.green;
//        }
//        else
//        {
//            // Cambia el color del cubo de vuelta a blanco si no hay impacto
//            cubeRenderer.material.color = Color.white;
//        }
//    }
//}
using UnityEngine;

public class RaycastColorChange : MonoBehaviour
{
    public float rayDistance = 2f;  
    public LayerMask targetLayer;   
    private Renderer targetRenderer;
    private bool isTargetHit = false;

    void Update()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, targetLayer))
        {
           
            if (!isTargetHit)
            {
                targetRenderer = hit.collider.GetComponent<Renderer>();
                if (targetRenderer != null)
                {
                    targetRenderer.material.color = Color.green;
                    isTargetHit = true;
                }
            }
        }
        else
        {
            
            if (isTargetHit && targetRenderer != null)
            {
                targetRenderer.material.color = Color.white;
                isTargetHit = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("TargetCube"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("TargetCube"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
