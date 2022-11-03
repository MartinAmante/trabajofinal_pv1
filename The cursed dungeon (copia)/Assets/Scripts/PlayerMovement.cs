using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    new Rigidbody rigidbody;
    Vector2 inputMov;
    public float velCamina = 10f;
    public float velCorrer = 20f;
    public float rotationSpeed = 100;
    private float x, y;
    private bool HActivo; //se utiliza para saber si estan presionadas las teclas
    private bool VActivo; //se utiliza para saber si estan presionadas las teclas
    //public Animator anim;

    void Start() {

        rigidbody = GetComponent<Rigidbody>();
        //anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

    }

    private void FixedUpdate() {
        float speed = Input.GetKey(KeyCode.LeftShift) ? velCorrer : velCamina;
        rigidbody.velocity =
            transform.forward * speed * inputMov.y //movernos hacia adelante y atras.
            + transform.right * speed * inputMov.x; //movernos hacia izquierda y derecha.

        //anim.SetFloat("VelX", x); //reproduce la animacion de correr y caminar.

        //anim.SetFloat("VelY", y); //reproduce las animaciones de giro a los alterales.


        if (Input.GetButtonDown("Horizontal")) {
            if (VActivo == false) {
                HActivo = true;
                //steep.Play();
            }
        }
        if (Input.GetButtonDown("Vertical")) {
            if (HActivo == false) {
                VActivo = true;
                //steep.Play();
            }
        }
        if (Input.GetButtonUp("Horizontal")) {
            HActivo = false;
            if (VActivo == false) {
                //steep.Pause();
            }
        }
        if (Input.GetButtonUp("Vertical")) {
            VActivo = false;
            if (HActivo == false) {
                //steep.Pause();
            }
        }
    }
}
