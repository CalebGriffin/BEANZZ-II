using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DoorInterface
{
    void OpenDoor();
    void CloseDoor();
    void ToggleDoor();

    void UnlockDoor();
    void SetLockMaterial(Material mat);

}
