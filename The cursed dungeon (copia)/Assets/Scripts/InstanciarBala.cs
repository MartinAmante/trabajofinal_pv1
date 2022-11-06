using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBala : MonoBehaviour
{

    public Transform SpawnPoint;

    public GameObject Bala;

    public float FuerzaDisparo = 1500f;
    //Con esto tendremos un tiempo de espera entre disparo para que no disparemos constantemente.
    public float cooldown = 0.5f;
    //contador del cooldown.
    private float cooldownTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > cooldownTime)
            {
                GameObject newBala;

                newBala = Instantiate(Bala, SpawnPoint.position, SpawnPoint.rotation);

                newBala.GetComponent<Rigidbody>().AddForce(SpawnPoint.forward * FuerzaDisparo);

                cooldownTime = Time.time + cooldown;

            }

        }
    }
}
