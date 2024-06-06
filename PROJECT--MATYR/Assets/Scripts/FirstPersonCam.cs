using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{

    public Transform player;
    public float mouseSensitivity =0.5f;
    float cameraVerticalRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis ("Mouse X")*mouseSensitivity;
        float inputY = Input.GetAxis ("Mouse Y")*mouseSensitivity;

        //rotate camera
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation= Mathf.Clamp(cameraVerticalRotation,-90f,90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        //rotate the player object and the camera around its y axis
        player.Rotate(Vector3.up *inputX);
    }
}
