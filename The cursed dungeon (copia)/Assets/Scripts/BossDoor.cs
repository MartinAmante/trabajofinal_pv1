using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    [SerializeField]
    private int numberDoor;
    private bool isOpen;
    private float speedMoveGate;

    public int NumberDoor { get => numberDoor; set => numberDoor = value; }

    void Start()
    {
        isOpen = false;
        speedMoveGate = 0.0002f;
    }

    void Update()
    {

    }

    public void OpenClose()
    {
        if (isOpen != true)
        {
            Transform transformDoor = transform.GetChild(0).transform;
            while (transformDoor.position.y < 3.5f)
            {
                transformDoor.Translate(0, speedMoveGate * Time.deltaTime, 0);
            }
            isOpen = true;
        }
    }

}
