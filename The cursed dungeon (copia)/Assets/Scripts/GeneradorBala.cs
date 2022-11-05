using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorBala : MonoBehaviour
{
    public GameObject BolaEnemigo;
    public int tipoEnemigo;


    void Start()
    {
        switch (tipoEnemigo)
        {
            case 1: InvokeRepeating("Disparar",0,1f); break;
            case 2: Invoke("Disparar",0); break;
            default: break;
        }
    }
    
    void Disparar()
    {
        Instantiate(BolaEnemigo, transform.position, transform.rotation);
        if(tipoEnemigo == 2)
        {
            Invoke("Disparar", Random.Range(1,5));
        }

    }

}
