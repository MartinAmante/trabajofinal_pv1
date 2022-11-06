using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BossDoor bossDoor = GameObject.Find("BossDoor").GetComponent<BossDoor>();
        if (bossDoor.NumberDoor == 1)
        {
            bossDoor.OpenClose();
        }
    }
}
