using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour {
    // Start is called before the first frame update
    float speed = 10f;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0), Space.Self);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Trampa") {
            Destroy(this.gameObject);
            Debug.Log("destruido");
        }
    }
}
