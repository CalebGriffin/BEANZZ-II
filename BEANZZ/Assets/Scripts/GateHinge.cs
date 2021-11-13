using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHinge : MonoBehaviour, DoorInterface //inherits DoorInterface
{
    
    public enum GateState
    {
        Closed = 0,
        Open,
        NumOfStates
    }

    private GateState currentGateState = GateState.Closed;
    [SerializeField] private GateState newGateState = GateState.Closed;
    [SerializeField] private Vector3 closedDirection = new Vector3(0f, 0f, 1f);
    [SerializeField] private Vector3 openDirection = new Vector3(-1f, 0f, 0f);
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private Quaternion targetRotation;
    private Quaternion startRotation;
    [SerializeField] private float slerpDuration = 1f;
    private float timeElapsed = 0f;

    [SerializeField] bool oneWay = false;

    // Start is called before the first frame update
    void Awake()
    {
        currentGateState = GateState.Closed;
        newGateState = GateState.Closed;
        closedRotation = Quaternion.LookRotation(transform.TransformDirection(closedDirection));
        openRotation = Quaternion.LookRotation(transform.TransformDirection(openDirection));
        targetRotation = closedRotation;
        startRotation = closedRotation;
        timeElapsed = slerpDuration;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentGateState)
        {
            case GateState.Closed:
                //if currently the gate is closed, and we want to open it
                if(newGateState == GateState.Open)
                {
                    //setup the slerp variables
                    startRotation = closedRotation;
                    targetRotation = openRotation;
                    //if we are interupting the door closing, calculate how much time we need to open
                    timeElapsed = slerpDuration - timeElapsed;
                    currentGateState = newGateState;
                }
                
                break;
            case GateState.Open:
                //if currently the gate is open, and we want to close it
                if (newGateState == GateState.Closed)
                {
                    //setup the slerp variables
                    startRotation = openRotation;
                    targetRotation = closedRotation;
                    //if we are interupting the door opening, calculate how much time we need to close
                    timeElapsed = slerpDuration - timeElapsed;
                    currentGateState = newGateState;
                }
                break;
            case GateState.NumOfStates:
            default:
                //Do nothing - should not get here
                break;
        }

        //test if we have completed the slerp - as slerp is a linear interpolation it may never reach the final value
        //therefore it is best to test that the expected slerp time has completed and then force the final value
        if (timeElapsed < slerpDuration)
        {
            //spherically lerp (slerp) from the starting point to the target as defined in the switch case above
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / slerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            //fix the timeElapsed = slerpDuration otherwise the calculations in the switch case won't be accurate
            timeElapsed = slerpDuration;
            //force the final value
            transform.rotation = targetRotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if((other.tag == "Player") && (currentGateState == GateState.Open) && (oneWay))
        {
            //close the door behind the player
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        newGateState = GateState.Open;

    }

    public void CloseDoor()
    {
        newGateState = GateState.Closed;
    }

    public void ToggleDoor()
    {
        if(currentGateState == GateState.Closed)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}
