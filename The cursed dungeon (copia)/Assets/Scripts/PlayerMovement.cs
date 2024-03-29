using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    new Rigidbody rigidbody;
    Vector2 inputMov;
    public float velCamina = 6f;
    public float velCorrer = 10f;
    public float rotationSpeed = 100;
    public float gravedad;

    public Animator animator;

    private float x, y;
    private bool HActivo; //se utiliza para saber si estan presionadas las teclas
    private bool VActivo; //se utiliza para saber si estan presionadas las teclas

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        //Con esta linea de codigo modificamos la gravedad que ya viene en unity.
        Physics.gravity *= gravedad;
    }

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

        animator.SetFloat("VelX", x); //reproduce la animacion de correr y caminar.
        animator.SetFloat("VelY", y);


        if (Input.GetButtonDown("Horizontal")) {
            if (VActivo == false) {
                HActivo = true;
            }
        }
        if (Input.GetButtonDown("Vertical")) {
            if (HActivo == false) {
                VActivo = true;

            }
        }
        if (Input.GetButtonUp("Horizontal")) {
            HActivo = false;
            if (VActivo == false) {

            }
        }
        if (Input.GetButtonUp("Vertical")) {
            VActivo = false;
            if (HActivo == false) {
            }
        }
    }
}
