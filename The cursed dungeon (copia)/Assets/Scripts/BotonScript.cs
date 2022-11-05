using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BossDoor BossDoor = GameObject.Find("BossDoor").GetComponent<BossDoor>();
        if (BossDoor.NumberDoor == 1)
        {
            BossDoor.OpenClose();
        }
    }
}
