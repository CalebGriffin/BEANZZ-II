using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class GateHinge : MonoBehaviour, DoorInterface //inherits DoorInterface
{

    public enum GateState
    {
        Closed = 0,
        Open,
        NumOfStates
    }

    [SerializeField] private GameObject myGate;
    [SerializeField] private CinemachineVirtualCamera myCam;
    [SerializeField] private GameObject[] myLocks = new GameObject[(int)GateState.NumOfStates];


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
    [SerializeField] private bool helperTriggered = false;
    [SerializeField] private bool onlyPlayCutSceneOnce = true;
    private bool cutScenePlayed = false;


    // Start is called before the first frame update
    void Awake()
    {

        cutScenePlayed = false;
        currentGateState = GateState.Closed;
        newGateState = GateState.Closed;
        closedRotation = Quaternion.LookRotation(myGate.transform.TransformDirection(closedDirection));
        openRotation = Quaternion.LookRotation(myGate.transform.TransformDirection(openDirection));
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
                    if(cutScenePlayed == false || onlyPlayCutSceneOnce == false)
                    {
                        cutScenePlayed = true;
                        CameraDirector.Instance.SetCutCam(myCam);
                        GameSystemController.Instance.NewGameState = GameSystemController.GameStates.PlayerToGateCutScene;
                    }
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
            if(GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
            {
                //spherically lerp (slerp) from the starting point to the target as defined in the switch case above
                ToggleLockActive(false);
                myGate.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / slerpDuration);
                timeElapsed += Time.deltaTime;
            }
            else if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.CutSceneLive)
            {
                //spherically lerp (slerp) from the starting point to the target as defined in the switch case above
                ToggleLockActive(false);
                myGate.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / slerpDuration);
                timeElapsed += Time.deltaTime;
                if (timeElapsed > slerpDuration)
                {
                    GameSystemController.Instance.NewGameState = GameSystemController.GameStates.GateToPlayerCutScene; //exit the cut scene
                }
            }
            else
            {
                //Do nothing - game is paused or at a menu, etc.
            }
            
        }
        else
        {
            //fix the timeElapsed = slerpDuration otherwise the calculations in the switch case won't be accurate
            timeElapsed = slerpDuration;
            //force the final value
            myGate.transform.rotation = targetRotation;
            if(currentGateState == GateState.Closed)
            {
                ToggleLockActive(true);
            }
            
            
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            if (helperTriggered)
            {

                if(other.tag == "Player")
                {
                    if((other.GetComponentInChildren<HelperHolderSystem>().GetNumberOfHelpers() == 0) && (currentGateState == GateState.Open) && (oneWay))
                    {
                        
                        //close the door behind the player - they don't have any helpers
                        CloseDoor();
                    }
                }
                //Needs upgrading to detect last helper in group (use distance from player?)
                else if ((other.tag == "Helper") && (currentGateState == GateState.Open) && (oneWay))
                {
                    //close the door behind the player
                    CloseDoor();
                }
            }
            else
            {
                if ((other.tag == "Player") && (currentGateState == GateState.Open) && (oneWay))
                {
                    //close the door behind the player
                    CloseDoor();
                }
            }
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

    public void UnlockDoor()
    {
        
    }

    public void SetLockMaterial(Material mat)
    {
        SetLocksMaterial(mat);
    }

    private void ToggleLockActive(bool active)
    {
        for(int i = 0; i < (int)GateState.NumOfStates; i++)
        {
            myLocks[i].SetActive(active);
        }
    }

    private void SetLocksMaterial(Material mat)
    {
        for (int i = 0; i < (int)GateState.NumOfStates; i++)
        {
            myLocks[i].GetComponent<Renderer>().material = mat;
        }
    }

}
