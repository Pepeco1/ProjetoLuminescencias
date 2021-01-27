using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    private float mouseMovX;
    private float mouseMovY;
    private float rotationX = 0f;

    public Transform player;
    public float sensitivity = 100f;


    void Start()
    {
        
    }

    
    void Update()
    {


        mouseMovX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseMovY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotationX -= mouseMovY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);      // Clamp vai fixar o valor fornecido entre um valor maximo e minimo

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);


        player.Rotate(Vector3.up * mouseMovX);


    }
}
