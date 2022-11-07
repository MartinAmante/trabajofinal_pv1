using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    //Con esto obtenemos la posicion de la camara
    private new Transform camera;
    //Con esta variables definiremos la distancia del rayo
    public float RayDistance;

    void Start()
    {
        //En esta parte decimos que la variable camera tiene que buscar la posicion del objeto "Main Camera"
        camera = transform.Find("Main Camera");
    }

    void Update()
    {
        //Con esta linea de codigo dibujamos el rayo.
        Debug.DrawRay(camera.position, camera.forward * RayDistance, Color.red);


        //Aqui "preguntaremos" si el boton dele input "Interactable" es presionado entonces realiza lo que est dentro dele if.
        if (Input.GetButtonDown("Interactable"))
        {
            RaycastHit hit;
            //Y con esto ultimo haremos que nuestro RayCast interactue solo con los objetos que tengan el layer Interaction.
            if (Physics.Raycast(camera.position, camera.forward, out hit, RayDistance, LayerMask.GetMask("Interaction")))
            {
                hit.transform.GetComponent<Interactable>().Interact();
            }
        }
    }
}
