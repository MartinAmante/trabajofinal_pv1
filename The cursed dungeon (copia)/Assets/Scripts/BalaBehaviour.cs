using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBehaviour : MonoBehaviour
{

    public GameObject Bala;

    public int cantidadVida = 20;

    void Update()
    {
        
    }
      private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<RecibirDanio>().RestarVida(20);
            Destroy(gameObject);
            Debug.Log("colisonenemigo");
        }
        
    } 

}
