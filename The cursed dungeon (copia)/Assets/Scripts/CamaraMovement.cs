using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    private new Transform camera;
    public Vector2 sensibility;

    void Start()
    {
        camera = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float Hor = Input.GetAxis("Mouse X");
        float Ver = Input.GetAxis("Mouse Y");

        if (Hor != 0)
        {
            transform.Rotate(Vector3.up * Hor * sensibility.x);
        }
        if (Ver != 0)
        {
            float angle = (camera.localEulerAngles.x - Ver * sensibility.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}
