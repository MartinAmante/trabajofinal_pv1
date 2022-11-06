using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectBehaviour : MonoBehaviour
{
    public AudioSource audioAmbiente;
    public AudioSource audioJefeFinal;
   
    bool reduce;


    private void Update()
    {
        if (reduce)
        {
            audioAmbiente.volume -= 0.5f * Time.deltaTime;
            audioJefeFinal.volume += 0.5f * Time.deltaTime;
        }
        else
        {
            audioAmbiente.volume +=0.5f * Time.deltaTime;
            audioJefeFinal.volume -= 0.5f * Time.deltaTime;

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            reduce = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if(other.tag == "Player")
        {
            reduce = false;
           
        }
    }
}
