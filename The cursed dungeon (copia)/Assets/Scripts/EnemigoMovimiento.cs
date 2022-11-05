using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;
    public bool atacando;

    public GameObject jugador;
    

    void Start()
    {
        anim = GetComponent<Animator>();

        jugador = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }

    public void ComportamientoEnemigo()
    {
        if(Vector3.Distance(transform.position, jugador.transform.position) > 5)
        {
            anim.SetBool("correr", false);
            cronometro += 1 * Time.deltaTime;
            if(cronometro >= 4)
            {
            rutina = Random.Range(0,2);
            cronometro = 0;
            }
            switch (rutina)
           {
            case 0: anim.SetBool("caminar", false);
            break;

            case 1: grado = Random.Range(0, 360);
            angulo = Quaternion.Euler(0,grado,0);
            rutina++;
            break;

            case 2: transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            anim.SetBool("caminar", true);
            break;
           }
       }
       else
       {
        if(Vector3.Distance(transform.position, jugador.transform.position) > 2 &&  !atacando)
        {
        var lookPos = jugador.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
        anim.SetBool("correr", true);
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        anim.SetBool("atacar", false);

        }
        else
        {
            anim.SetBool("correr", false);
            anim.SetBool("caminar", false);
            anim.SetBool("atacar", true);
            atacando = true;

        }
        
       }

    }

    public void FinalAnimacion()
    {
        anim.SetBool("atacar", false);
        atacando = false;
    }
}
