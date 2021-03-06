using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Renderer meshRenderer;

    private GameObject currentHelper = null;

    [SerializeField] GameObject helperHolderObj;

    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineOrbitalTransposer orbitalTransposer;

    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject cursorObj;
    [SerializeField] Material cursorMat;
    [SerializeField] Material cursorCollectMat;

    [SerializeField] private Animator animator;

    [SerializeField] float moveSpeed;

    PlayerControls controls;

    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float targetAngle;
    float angle;

    float raycastDist = 5;
    RaycastHit hit;
    public LayerMask interactiveLayer;

    bool isLooking;
    bool shouldBeMoving = false;

    Vector2 lookingVec;

    Vector2 inputVec;

    Vector3 direction;

    bool towardsBool;
    bool awayBool;

    float distToCursor;
    [SerializeField] float raycastDistMax = 30;

    [SerializeField] float sensitivity;

    [SerializeField] LineRenderer lineRenderer;
    
    public int sweets = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        controls = new PlayerControls();

        orbitalTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();

        meshRenderer = cursorObj.GetComponent<Renderer>();
    }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var points = new Vector3[2];
        points[0] = new Vector3(0f, 2f, 0f);
        points[1] = cursorObj.transform.localPosition;
        lineRenderer.SetPositions(points);

        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            characterController.SimpleMove(Vector3.down * 9.8f * Time.deltaTime);

            if (animator.GetBool("isMoving") == true)
            {
                Look();
                Move();
            }

            if (isLooking == true)
            {
                Rotate();
            }

            if (towardsBool)
            {
                raycastDist = Mathf.Clamp(raycastDist - (15f * Time.deltaTime), 0, raycastDistMax);
            }

            if (awayBool)
            {
                raycastDist = Mathf.Clamp(raycastDist + (15f * Time.deltaTime), 0, raycastDistMax);
            }

            orbitalTransposer.m_RecenterToTargetHeading.m_enabled = shouldBeMoving;
        }
    }

    private void FixedUpdate() 
    {
        if (Physics.SphereCast(new Vector3(transform.position.x, transform.position.y, transform.position.z), raycastDist / 25f, transform.forward, out hit, raycastDist, interactiveLayer))
        {
            cursorObj.transform.position = hit.collider.gameObject.transform.position;
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            cursorObj.transform.localPosition = new Vector3(0f, 0f, raycastDist * 2);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.TransformDirection(Vector3.forward) * raycastDist, Color.blue);
        }
    }
        

    public void OnMoveAndLook(InputValue input)
    {
        inputVec = input.Get<Vector2>();
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            direction = new Vector3(inputVec.x, 0f, 0f);

            if (inputVec.y >= 0.8f)
            {
                awayBool = true;
                shouldBeMoving = true;
            } 
            else if (inputVec.y >= 0.2f)
            {
                awayBool = true;
            }
            else if (inputVec.y <= -0.2f)
            {
                towardsBool = true;
                shouldBeMoving = false;
            }
            else
            {
                towardsBool = false;
                awayBool = false;
                shouldBeMoving = false;
            }

            if (direction.magnitude >= 0.1f || shouldBeMoving)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
            isLooking = false;
            shouldBeMoving = false;
        }
    }

    public void OnRotate(InputValue input)
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
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
    }

    public void Look()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    public void Move()
    {
        if (shouldBeMoving)
        {
            distToCursor = Vector3.Distance(transform.position, cursorObj.transform.position);
            //direction.z = 1f * (distToCursor/raycastDistMax);
            direction.z = 1f * inputVec.y;
        }
        else
        {
            direction.z = 0f;
        }
        characterController.Move(transform.forward * direction.z * moveSpeed * Time.deltaTime);
    }

    public void Rotate()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            orbitalTransposer.m_XAxis.Value += lookingVec.x * sensitivity * Time.deltaTime;
        }
    }

    public void OnYeet()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            HelperMovement.HelperData data;
            data.targetPosition = cursorObj.transform.position;
            data.lookAtPosition = cursorObj.transform.position;
            data.helperState = HelperMovement.HelperState.GotoTarget;

            if (currentHelper != null)
            {
                Debug.Log("Got a Helper!");
                currentHelper.SendMessage("ClearHelperHolder");
                currentHelper.SendMessage("SetTarget", data);
                ButtonUIManager.Instance.ResetAllButtons();
                currentHelper = null;
            }
        }
    }

    public void OnCollect(InputValue input)
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            bool inputBool = input.isPressed;

            if (inputBool)
            {
                meshRenderer.material = cursorCollectMat;
                lineRenderer.material = cursorCollectMat;
                cursorObj.transform.localScale = new Vector3(10f, 10f, 10f);
                helperHolderObj.transform.localPosition = cursorObj.transform.localPosition;
            }
            else
            {
                meshRenderer.material = cursorMat;
                lineRenderer.material = cursorMat;
                cursorObj.transform.localScale = new Vector3(3f, 3f, 3f);
                helperHolderObj.transform.localPosition = new Vector3(0f, 0f, 0f);
            }
        }
    }

    public void OnButtonNorth()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            SelectHelper(2);
        }
    }

    public void OnButtonSouth()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            SelectHelper(1);
        }
    }

    public void OnButtonEast()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            SelectHelper(3);
        }
    }

    public void OnButtonWest()
    {
        if (GameSystemController.Instance.CurrentGameState == GameSystemController.GameStates.GamePlay)
        {
            SelectHelper(0);
        }
    }

    private void SelectHelper(int sizeSelected)
    {
        if (currentHelper != null)
        {
            currentHelper.SendMessage("SetSelected", false);
            if (currentHelper.GetComponent<Resize>().sizeIndex == sizeSelected)
            {
                currentHelper = null;
                ButtonUIManager.Instance.ResetAllButtons();
            }
            else
            {
                currentHelper = null;
                ButtonUIManager.Instance.ResetAllButtons();
                SelectHelper(sizeSelected);
            }
        }
        else
        {
            currentHelper = helperHolderObj.GetComponent<HelperHolderSystem>().GetHelperOfSize(sizeSelected);

            if (currentHelper != null)
            {
                Debug.Log("Selected");
                currentHelper.SendMessage("SetSelected", true);
                ButtonUIManager.Instance.SelectButton((ButtonUIManager.DiamondButtonMap)sizeSelected);
            }
        }
    }

    private void OnStartButton()
    {
        GameSystemController.Instance.StartButtonPressed();
    }

    private void OnEscape()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
