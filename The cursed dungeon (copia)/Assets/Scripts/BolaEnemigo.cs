using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaEnemigo : MonoBehaviour
{
   [SerializeField]
    private float speedX = 30f;

  

    private void Start()
    {
    }
    void Update()
    {
        transform.Translate( 0, speedX * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Enemy" || other.gameObject.tag == "Pared" || other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }

}
