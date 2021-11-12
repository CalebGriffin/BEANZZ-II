using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HelperMovement : MonoBehaviour
{
    public enum HelperState : int
    {
        Idle = 0,
        FollowPlayer,
        GotoTarget,
        NumOfStates
    }

    
    public struct HelperData
    {
        public Vector3 targetPosition;
        public Vector3 lookAtPosition;
        public HelperState helperState;
    }

    private HelperData myHelperData;
    private Vector3 smoothVel = Vector3.zero;
    private float smoothTime = 50.0f;
    private GameObject myHelperHolder;
    private Collider myCollider;
    private GameObject mainCam;

    [SerializeField] float targetTollerance = 0.05f;

    private NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        myHelperData.targetPosition = transform.position;
        myHelperData.lookAtPosition = mainCam.transform.position;
        myHelperData.helperState = HelperState.FollowPlayer;
        transform.LookAt(myHelperData.lookAtPosition);
        myCollider = GetComponent<Collider>();
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (myHelperData.helperState)
        {
            case HelperState.Idle:
                myHelperData.lookAtPosition = mainCam.transform.position;
                transform.LookAt(myHelperData.lookAtPosition);
                break;
            case HelperState.FollowPlayer:
                transform.LookAt(new Vector3(myHelperData.lookAtPosition.x, transform.position.y, myHelperData.lookAtPosition.z));
                myAgent.destination = myHelperData.targetPosition;
                break;
            case HelperState.GotoTarget:
                transform.LookAt(new Vector3(myHelperData.lookAtPosition.x, transform.position.y, myHelperData.lookAtPosition.z));
                myAgent.destination = myHelperData.targetPosition;
                if(Vector3.Distance(myHelperData.targetPosition, transform.position) < targetTollerance)
                {
                    myHelperData.helperState = HelperState.Idle;
                }
                break;
            default:
                break;
        }
        
        /*
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(myHelperData.targetPosition.x, transform.position.y, myHelperData.targetPosition.z), ref smoothVel, smoothTime * Time.deltaTime);
        if (smoothVel == Vector3.zero)
        {
            // have reached the target - do somthing?
        }
        */

    }

    void SetTarget(HelperData helperData)
    {
        myHelperData = helperData;
        
    }

    void SetHelperHolder(GameObject helperHolder)
    {
        myHelperHolder = helperHolder;
        //transform.parent = myHelperHolder.transform;
        gameObject.layer = 7; //set to CaptiveHelper layer so future collisions with HelperHolder are ignored
        Physics.IgnoreLayerCollision(6, 7, true); //ignore collisions between HelperHolder and CaptiveHelper layer
    }

    void CleartHelperHolder(GameObject helperHolder)
    {
        myHelperHolder = null;
        //transform.parent = null;
        gameObject.layer = 0; //set back to default layer so can be collected again (collisions with HelperHolder are back on)
        Physics.IgnoreLayerCollision(6, 7, true); //ignore collisions between HelperHolder and CaptiveHelper layer
    }
}
