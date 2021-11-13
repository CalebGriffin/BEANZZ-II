using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperHolderSystem : MonoBehaviour
{
    

    [SerializeField] Vector3 offsetFromPlayer = new Vector3(0f, 0.5f, -1f);
    [SerializeField] Vector3 helperOffset = new Vector3(0f, 0.5f, -1.5f);

    private GameObject player;
    private List<GameObject> helpers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreLayerCollision(6, 7, true); //ignore collisions between HelperHolder and CaptiveHelper layer
    }

    // Update is called once per frame
    void Update()
    {
        //List<GameObject> helpers = findChildrenWithTag(gameObject, "Helper");
        //transform.position = player.transform.position + transform.TransformDirection(offsetFromPlayer);
        //transform.rotation = player.transform.rotation;

        
        foreach(GameObject helper in helpers)
        {
            HelperMovement.HelperData helperData;
            helperData.targetPosition = transform.position + transform.TransformDirection(helperOffset);
            helperData.lookAtPosition = player.transform.position;
            if (helper.GetComponent<HelperMovement>().GetHelperState() != HelperMovement.HelperState.Selected)
            {
                helperData.helperState = HelperMovement.HelperState.FollowPlayer;
            }
            else
            {
                helperData.helperState = HelperMovement.HelperState.Selected;
            }
            helper.SendMessage("SetTarget", helperData);
        }
        
    }

    private List<GameObject> findChildrenWithTag(GameObject parent, string tag)
    {
        List<GameObject> taggedChildren = new List<GameObject>();
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            Transform child = parent.transform.GetChild(i);
            if (child.tag == tag)
            {
                taggedChildren.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                findChildrenWithTag(child.gameObject, tag);
            }
        }
        return taggedChildren;
    }

    public GameObject GetHelperOfSize(int size)
    {
        foreach (GameObject helper in helpers)
        {
            if (helper.GetComponent<Resize>().sizeIndex == size)
            {
                return helper;
            }
        }

        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Helper" && other.GetComponent<HelperMovement>().GetHelperState() == HelperMovement.HelperState.Idle)
        {
            Debug.Log("Set the Helper Holder");
            helpers.Add(other.gameObject);
            other.SendMessage("SetHelperHolder", gameObject);
            
            //Debug.Log("Collision with Helper");
        }
    }

    public void RemoveHelper(GameObject helperToRemove)
    {
        helpers.Remove(helperToRemove);
    }
}
