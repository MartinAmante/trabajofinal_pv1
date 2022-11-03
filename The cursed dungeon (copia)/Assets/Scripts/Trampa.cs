using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour {
    public GameObject flechas;
    // Start is called before the first frame update
    Transform[] allChildren;
    void Start() {
        InvokeRepeating("Disparar", 0, 1f);
        allChildren = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update() {

    }

    void Disparar() {
        if (this.gameObject.activeSelf) {
            foreach (Transform children in allChildren) {
                if (children.gameObject != this.gameObject) {
                    Instantiate(flechas, children.transform.position, children.transform.rotation);
                }

            }
        }


    }
}
