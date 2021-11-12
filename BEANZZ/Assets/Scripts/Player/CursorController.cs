using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class CursorController : MonoBehaviour
{
    private bool towardsBool;

    private bool awayBool;

    [SerializeField] private float moveSpeed;

    //these are used to manually specify the input action needed
    public InputAction lookLeftAction;
    public InputAction lookRightAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
     //These are used to link the actions specified above to beheaviour- it doesn't work on the InputActions specified in the actions file
    void Awake()
    {
        // lookLeftAction.performed += CursorTowards ;
        // lookRightAction.performed += CursorAway;
    }

    
    private void OnEnable()
    {
        lookLeftAction.Enable();
        lookRightAction.Enable();
    }

    private void OnDisable()
    {
        lookLeftAction.Disable();
        lookRightAction.Disable();
    }*/


    // Update is called once per frame
    void Update()
    {
        if (towardsBool)
        {
            transform.position += new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
        }
        if (awayBool)
        {
            transform.position += new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
        }
        
    }

    /*
     //These are used when adding in the action by the input above
    public void CursorTowards(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            towardsBool = !towardsBool;
            Debug.Log("Held Towards");
        }
       
    }

    public void CursorAway(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            awayBool = !awayBool;
            Debug.Log("Held Away");
        }

    }*/

    /*
    public void towardsStarted()
    {
        Debug.Log("towards");
        towardsBool = true; 
    }

    public void towardsEnded()
    {
        towardsBool = false; 
    }

    public void awayStarted()
    {
        awayBool = true; 
    }

    public void awayEnded()
    {
        awayBool = false; 
    }*/

    public void OnCursorTowards(InputValue input)
    {
        //you can't get the boolean directly- but isPressed does the same, this will trigger when pressed and again when depressed
        bool inputBool = input.isPressed;

        if (inputBool)
        {
            towardsBool = true;
        }
        else
        {
            towardsBool = false;
        }
    }

    public void OnCursorAway(InputValue input)
    {
        bool inputBool = input.isPressed;

        if (inputBool)
        {
            awayBool = true;
        }
        else
        {
            awayBool = false;
        }
    }
}
