using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private Animator animator;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    float socialTimer = 0;
    float socialTime = 2;
    bool countSocialTime = false;

    public GameObject player; // Mouse rotation
    public float turnSpeed = 10.0f; //
    public TogglePause tP; //


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        if (tP.pauseActive == false) // Mouse rotation
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            float y = Input.GetAxis("Mouse X") * turnSpeed;
            player.transform.eulerAngles = new Vector3(0, player.transform.eulerAngles.y + y, 0);
        }
        else
        {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None; 
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = move.normalized;

        animator.SetFloat("SpeedX", move.x);
        animator.SetFloat("SpeedZ", move.z);

        animator.SetFloat("SpeedMag", move.magnitude);

        move = move.z * transform.forward + transform.right * move.x;

        controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        //if (Input.GetButtonDown("Jump") && groundedPlayer)
        //{
        //animator.SetLayerWeight(1, 1);
        // countSocialTime = true;
        //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //}

        if (countSocialTime)
        {
            socialTimer += Time.deltaTime;
        }

        if (socialTimer >= socialTime)
        {
            animator.SetLayerWeight(1, 0);
            socialTimer = 0.0f;
            countSocialTime = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
