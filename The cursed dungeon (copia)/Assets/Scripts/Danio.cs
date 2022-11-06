using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danio : MonoBehaviour
{
    // Start is called before the first frame update
    private float danio;
    // Start is called before the first frame update
    void Start() {
        danio = 30;
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && other.GetComponent<BarraVida>()) {
            other.GetComponent<BarraVida>().RecibirDano(danio);
        }
    }
}