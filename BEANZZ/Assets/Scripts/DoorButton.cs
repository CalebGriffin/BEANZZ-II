using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] GameObject doorGameObject;
    [SerializeField] bool isHelperTriggered = false;
    [SerializeField] int helperSizeRequired = 0;
    private DoorInterface door;
    [SerializeField] private Material[] lockMats = new Material[4]; //will replicate Resize for now, but we should consider making the colours static so only in 1 place.

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorInterface>();
        door.SetLockMaterial(lockMats[helperSizeRequired]);
        GetComponent<Renderer>().material = lockMats[helperSizeRequired];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isHelperTriggered)
        {
            if ((other.tag == "Helper") && (other.GetComponent<Resize>().sizeIndex == (helperSizeRequired)))
            {
                door.UnlockDoor();
                door.ToggleDoor();
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                door.UnlockDoor();
                door.ToggleDoor();
            }
        }
        
    }
}
