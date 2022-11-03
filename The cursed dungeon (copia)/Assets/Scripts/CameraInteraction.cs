using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private new Transform camera;

    public float RayDistance;

    void Start()
    {
        camera = transform.Find("Main Camera");
    }

    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * RayDistance, Color.red);

        if (Input.GetButtonDown("Interactable"))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit, RayDistance, LayerMask.GetMask("Interaction")))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
