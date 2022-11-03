using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screemer : MonoBehaviour
{
    public GameObject[] susto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(susto[Random.Range(0,susto.Length)]);
            Destroy(gameObject);
        }
    }

}
