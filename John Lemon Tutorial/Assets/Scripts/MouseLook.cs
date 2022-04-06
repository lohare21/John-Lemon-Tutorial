using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5;
    public float smoothing = 10;

    private float xMousePos;
    private float smoothedMousePos;

    private float  currentLookingPos;

    void start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePos, 1f / smoothing);
    }

    void MovePlayer()
    {
        currentLookingPos += smoothedMousePos;
        transform.localRoation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }
}