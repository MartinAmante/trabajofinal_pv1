using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolas : MonoBehaviour
{
   [SerializeField]
    private float speedX = 10f;

  

    private void Start()
    {
    }
    void Update()
    {
        transform.Translate( 0, speedX * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

    }

}
