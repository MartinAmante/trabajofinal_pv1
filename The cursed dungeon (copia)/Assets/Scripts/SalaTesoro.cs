using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaTesoro : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BossDoor bossDoor = GameObject.Find("SalaTesoro").GetComponent<BossDoor>();
        if (bossDoor.NumberDoor == 2)
        {
            bossDoor.OpenClose();
        }
    }
}
