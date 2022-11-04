using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoZombie : MonoBehaviour
{
   public float velMovimiento, velRotacion;

    public float tiempoReaccion = 0.8f;

    public int movimiento;

    public bool espera, camina, gira, estarAlerta;

    public Transform jugador;
    [SerializeField]
    private float velocidad = 3;

    public LayerMask capaJugador;

    public float rangoAlerta;

    void Start()
    {
        Accion();
    }

    
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);

        if(estarAlerta == true)
        {
        //transform.LookAt(jugador);
        GetComponent<Animator>().SetBool("Activo", true);
        transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime );
        }
        if(estarAlerta == false)
        {
         GetComponent<Animator>().SetBool("Activo3", false);
        }
         if(camina)
        {
         GetComponent<Animator>().SetBool("Activo2", true);
         transform.position += (transform.forward * velMovimiento * Time.deltaTime);
        }
        if(espera)
        {
          GetComponent<Animator>().SetBool("Activo2", false);
        }
        if(gira)
        {
          transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
        }

     
    }
    void Accion()
    {
        movimiento = Random.Range(1,4);

        if(movimiento == 1)
        {
            camina = true;
            espera = false;

        }
        if(movimiento == 2)
        {
            camina = false;
            espera = true;
        }
        if(movimiento == 3)
        {
            gira = true;
            StartCoroutine("TiempoGiro");
        }

       Invoke("Accion", tiempoReaccion);
    }

    IEnumerator TiempoGiro()
    {
        yield return new WaitForSeconds(2);
        gira = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
        
    }
}
