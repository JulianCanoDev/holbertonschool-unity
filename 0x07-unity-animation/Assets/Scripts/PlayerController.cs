using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalMove;
    [SerializeField] private float verticalMove;
    [SerializeField] private float playerSpeed = 6.0f;
    [SerializeField] private float gravity = 40.0f;
    [SerializeField] private float fallVelocity;
    [SerializeField] private float jumpForce = 10.0f;
    public static bool isJumping;
    public static event Action Jump;

    public CharacterController Player;
    public Camera mainCamera;
    private Vector3 movePlayer;

    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 camRight;
    void Start()
    {
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        movePlayer = movePlayer * playerSpeed;

        Player.transform.LookAt(Player.transform.position + movePlayer);

        setGravity();

        PlayerSkills();

        Player.Move(movePlayer * Time.deltaTime);

        if (transform.position.y < -40)
            transform.position = new Vector3(0, 60, 0);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void PlayerSkills()
    {
        if (Player.isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            Jump();
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    void setGravity()
    {
        if (Player.isGrounded)
        {
            if (isJumping)
            {
                isJumping = false;
                Jump();
            }

            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fall_space"))
        {
            transform.position = new Vector3(0, 5, 0);
        }
    }
}
