using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    private Vector2 moveVec = Vector2.zero;
    private Vector2 rotateVec = Vector2.zero;
    private float rotateSensitivity = 20.0f;

    private CharacterController myCharController;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myCharController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myCharController.Move(transform.TransformDirection(new Vector3(moveVec.x, 0, moveVec.y) * playerSpeed * Time.deltaTime));
        transform.Rotate(0, rotateVec.x * rotateSensitivity * Time.deltaTime, 0);

    }

    public void OnMovePlayer(InputValue input)
    {
        moveVec = input.Get<Vector2>();
        animator.SetFloat("Speed", (float)moveVec.y);
    }

    public void OnRotatePlayer(InputValue input)
    {
        rotateVec = input.Get<Vector2>();
    }    

}
