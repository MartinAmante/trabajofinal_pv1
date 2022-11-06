using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrullaje : MonoBehaviour
{
     [SerializeField] 
    private GameObject enemigo;
    [SerializeField] 
    private Transform[] puntosDeControl;
    [SerializeField] 
    private float velocidadCorrutina = 3f;

    public float rangoAlerta;

    public LayerMask capaJugador;

    public Transform jugador;

    private float velocidad = 3;

    bool estarAlerta;



    void Start()
    {
        StartCoroutine("RealizarMovimiento"); 
    }

   void Update()
    {
     
       estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);
       
       if(estarAlerta == true)
       {
        StopAllCoroutines();
        GetComponent<Animator>().SetBool("correr", true);
        velocidad = 1;
        //transform.LookAt(jugador);
        transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime );
        if(Vector3.Distance(transform.position, jugador.transform.position) > 1.5)
        {
            GetComponent<Animator>().SetBool("correr", false);
            GetComponent<Animator>().SetBool("caminar", false);
            GetComponent<Animator>().SetBool("atacar", true);
        }
       }
       else
       {
        GetComponent<Animator>().SetBool("caminar", true);
       }
        
    }

        public void FinalAnimacion()
    {
        GetComponent<Animator>().SetBool("atacar", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
        
    }

    IEnumerator RealizarMovimiento()
    {
        int i = 0;
        Vector3 nuevaPosicion = new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].position.z);
     
     while(true)
     {
        while (enemigo.transform.position != nuevaPosicion)
        {
           GetComponent<Animator>().SetBool("caminar", true);
           enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position, nuevaPosicion, velocidadCorrutina * Time.deltaTime);
           yield return null;
        }
        yield return StartCoroutine("RotarEnemigo");

        if( i < puntosDeControl.Length - 1)
        {
            i++;
        }
        else
        {
            i = 0;
        }
        nuevaPosicion =  new Vector3(puntosDeControl[i].position.x, enemigo.transform.position.y, puntosDeControl[i].transform.position.z);
        //Debug.Log(i);
     }

    }

    IEnumerator RotarEnemigo()
    {
        for( int i = 1; i <= 90; i++)
        {
            enemigo.transform.Rotate(0,-1,0);
        }
        yield return null;
    }

}
