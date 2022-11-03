using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour {

    private int vida;
    [SerializeField]
    private Slider barraVida;
    // Start is called before the first frame update
    void Start() {
        this.vida = 100;
    }

    // Update is called once per frame
    void Update() {
        barraVida.value = vida;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            QuitarVida();
            Debug.Log("colisiono");
        }
    }

    private void QuitarVida() {
        this.vida -= 1;
    }
}
