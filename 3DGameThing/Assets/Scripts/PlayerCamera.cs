using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]float sensX;
    [SerializeField]float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Cursor.lockState != CursorLockMode.None)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate cam and chara
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        

    }

}
