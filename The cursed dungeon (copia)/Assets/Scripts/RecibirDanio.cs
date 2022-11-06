using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibirDanio : MonoBehaviour
{
    public int vida = 100;

    public void RestarVida( int cantidadVida)
    {
        vida -= cantidadVida;

        if(vida <= 0)
        {
            GetComponent<Animator>().SetBool("morir", true);
            Destroy(gameObject, 1);
        }
    }
}
