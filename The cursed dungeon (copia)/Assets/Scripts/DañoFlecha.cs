using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoFlecha : MonoBehaviour {
    private float danio;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && other.GetComponent<BarraSalud>()) {
            other.GetComponent<BarraSalud>().RecibirDanio(danio);
        }
    }
}
