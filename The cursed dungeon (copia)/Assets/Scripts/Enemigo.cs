using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour {

    private Animator animator;
    [SerializeField]
    private GameObject llama;
    private int vida;
    [SerializeField]
    private Slider barraVida;
    // Start is called before the first frame update
    void Start() {
        this.vida = 100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        barraVida.value = vida;
        LanzarLLamas();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            QuitarVida();
            Debug.Log("colisiono");
        }
    }

    private void LanzarLLamas() {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Idle01") {
            llama.SetActive(false);
            //Debug.Log("Tirar Llamas");
        } else {
            llama.SetActive(true);
            //Debug.Log("No tirar Llamas");
        }
    }
    private void QuitarVida() {
        this.vida -= 10;
    }
    private void Atacar() {
        animator.SetBool("Atacar", true);
        Debug.Log(animator.GetAnimatorTransitionInfo(0));
    }

    private void Parar() {
        animator.SetBool("Atacar", false);
        //Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        //Debug.Log(animator.GetAnimatorTransitionInfo(0).);
    }


}
