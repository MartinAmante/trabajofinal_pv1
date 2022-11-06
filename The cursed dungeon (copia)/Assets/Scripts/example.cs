using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example : MonoBehaviour {
    // Start is called before the first frame update
    public bool elevar;
    void Start() {
        elevar = false;
        //StartCoroutine(AbrirAnimacion());
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(AbrirAnimacion());
    }

    IEnumerator AbrirAnimacion() {
        while (elevar) {
            this.transform.Translate(new Vector3(0, 2f * Time.deltaTime, 0));
            yield return new WaitForSeconds(1);
        }
    }
}
