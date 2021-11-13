using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    [SerializeField] CinemachineFreeLook cinemachineFreeLook;

    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject cursorObj;

    [SerializeField] private Animator animator;

    [SerializeField] float moveSpeed;

    PlayerControls controls;

    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float targetAngle;
    float angle;

    float raycastDist = 30;
    RaycastHit hit;
    public LayerMask interactiveLayer;

    bool isLooking;

    Vector2 lookingVec;

    Vector3 direction;

    bool towardsBool;
    bool awayBool;

    [SerializeField] float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        controls = new PlayerControls();
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        characterController.SimpleMove(Vector3.down * 9.8f * Time.deltaTime);

        if (animator.GetBool("isMoving") == true)
        {
            Move();
        }

        if (isLooking == true)
        {
            Look();
        }

        if (towardsBool)
        {
            raycastDist += -9f * Time.deltaTime;
        }

        if (awayBool)
        {
            raycastDist += +9f * Time.deltaTime;
        }
    }

    private void FixedUpdate() 
    {
        if (Physics.SphereCast(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), 1f, transform.forward, out hit, raycastDist, interactiveLayer))
        {
            cursorObj.transform.position = hit.collider.gameObject.transform.position;
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            cursorObj.transform.localPosition = new Vector3(0f, 0f, raycastDist);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.TransformDirection(Vector3.forward) * raycastDist, Color.blue);
        }
    }
        

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();
        direction = new Vector3(inputVec.x, 0f, inputVec.y);

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void OnRotate(InputValue input)
    {
        lookingVec = input.Get<Vector2>();
        
        if (lookingVec != Vector2.zero)
        { 
            isLooking = true;
        }
        else
        {
            isLooking = false;
        }
    }

    public void OnCursorTowards(InputValue input)
    {
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

    public void Move()
    {
        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
    }

    public void Look()
    {
        cinemachineFreeLook.m_XAxis.Value += lookingVec.x * sensitivity * Time.deltaTime;
        cinemachineFreeLook.m_YAxis.Value += lookingVec.y * Time.deltaTime;
    }
}
