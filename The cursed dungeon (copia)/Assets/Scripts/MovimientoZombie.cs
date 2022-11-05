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

    public int Dano = 10;




    

    void Start()
    {
       Accion();
        
    }

    
    void Update()
    {
      estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);

      if(estarAlerta == false)
      {
        GetComponent<Animator>().SetBool("correr", false);
        if(camina)
        {
         transform.position += (transform.forward * velMovimiento * Time.deltaTime);
         GetComponent<Animator>().SetBool("caminar", true);
        }
        if(espera)
        {
          GetComponent<Animator>().SetBool("caminar", false);
        }
        if(gira)
        {
          transform.Rotate(Vector3.up * velRotacion * Time.deltaTime);
        }
      }
      else
      {
        if(Vector3.Distance(transform.position, jugador.transform.position) > 1.5)
        {
          transform.LookAt(new Vector3(jugador.position.x, transform.position.y, jugador.position.z));
          transform.position = Vector3.MoveTowards(transform.position,new Vector3(jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime );
          GetComponent<Animator>().SetBool("correr", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("correr", false);
            GetComponent<Animator>().SetBool("caminar", false);
            GetComponent<Animator>().SetBool("atacar", true);

        }

      }
    } 


     public void FinalAnimacion()
    {
        GetComponent<Animator>().SetBool("atacar", false);
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

     private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<BarraVida>().RecibirDano(10);
            //Destroy(gameObject);
        }
        
    } 
  
}

