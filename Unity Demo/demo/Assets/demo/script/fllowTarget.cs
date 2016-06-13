using UnityEngine;
using System.Collections;

public class fllowTarget : MonoBehaviour
{

    public Transform character;  
    public float smoothTime = 0.01f; 
    private Vector3 cameraVelocity = Vector3.zero;
    private Camera mainCamera; 

    void Awake()
    {
        mainCamera = Camera.main;
        
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, character.position + new Vector3(0, 0, -5), ref cameraVelocity, smoothTime);
    }

}