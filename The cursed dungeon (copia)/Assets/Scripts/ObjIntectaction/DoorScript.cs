using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform door;
    public Transform OpenDoor;
    public Transform CloseDoor;
    public float doorSpeed;
    Vector3 targetposition;
    float time;
    public bool isUnloked = true;
    public KeyScript doorToOpen;

    void Start()
    {
        targetposition = CloseDoor.position;
    }

    void Update()
    {
        if (isUnloked && door.position != targetposition)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetposition, time);
            time += Time.deltaTime * doorSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            targetposition = OpenDoor.position;
            time = 0;
        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            targetposition = CloseDoor.position;
            time = 0;
        }
    }
}
