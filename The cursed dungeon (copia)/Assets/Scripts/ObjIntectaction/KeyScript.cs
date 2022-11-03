using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : Interactable
{

    public DoorScript doorToOpen;

    public override void Interact()
    {

        base.Interact();

        doorToOpen.isUnloked = true;
        Destroy(gameObject);

    }
}
