using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] GameObject doorGameObject;
    private DoorInterface door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<DoorInterface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            door.ToggleDoor();
        }
    }
}
