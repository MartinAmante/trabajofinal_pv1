using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activadorTrampa : MonoBehaviour {

    public GameObject trampaObjeto;
    public bool trampa;
    public bool trampaOnOff;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            OnOffTrampa();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            OnOffTrampa();
        }
    }
    public void OnOffTrampa() {
        trampaOnOff = !trampaOnOff;
        if (trampaOnOff) {
            trampaObjeto.SetActive(true);
        } else {
            trampaObjeto.SetActive(false);
        }
    }
}
