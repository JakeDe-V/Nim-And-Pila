using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDetailed : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector3 moveInput;

    // Make A Game Like Pokemon in Unity

    private Animator animator;

    /*Rytech - How to Create Player Movement in UNITY - character controller movement

    private Vector3 velocity;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity = -9.81f;

    */

    //Rytech - How to Create Player Movement in UNITY - rigidbody movement


    [SerializeField]
    private Rigidbody playerBody;

    //Make A Game Like Pokemon in Unity #1
    //private bool IsWalkable = true;



    private void Awake()
    {
        // Make A Game Like Pokemon in Unity

        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        /* Unity Junior Programming Pathway - Player Positioning Unity 2.1

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        

       transform.Translate(Vector3.right * moveInput.x * moveSpeed * Time.deltaTime);
       transform.Translate(Vector3.forward * moveInput.y * moveSpeed * Time.deltaTime);
        */


        /*Rytech - How to Create Player Movement in UNITY - character controller movement

        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();

        */

        //Rytech - How to Create Player Movement in UNITY - rigidbody movement

        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();

        // Make A Game Like Pokemon in Unity

        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.z);

        if (moveInput != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }

        if (moveInput == Vector3.zero)
        {
            animator.SetBool("isMoving", false);
        }

        /*Make A Game Like Pokemon in Unity #1

        if (!isMoving)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("moveX", moveInput.x);
                animator.SetFloat("moveY", moveInput.y);

                var targetPos = transform.position;
                targetPos.x += moveInput.x;
                targetPos.z += moveInput.y;

                if (IsWalkable)
                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving); */
    }

    /*Rytech - How to Create Player Movement in UNITY - character controller movement



    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(moveInput);

        //y -= gravity * -2f * Time.deltatime;

        
        if (controller.isGrounded)
        {
            velocity.y = -1f;
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
        }
        
        

        controller.Move(moveVector * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        
    }

    */

    //Rytech - How to Create Player Movement in UNITY - rigidbody movement

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(moveInput) * moveSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
    }


        /* Make A Game Like Pokemon in Unity #1

        IEnumerator Move(Vector3 targetPos)
        {
            isMoving = true;

            while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                /*void OnTriggerStay(Collider other)
                {
                    return;
                }

                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = targetPos;

            isMoving = false;
        } */



        /*void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "SolidObject")
            {
                print("ENTER");
                IsWalkable = false;
            }

        }*/



        /*private bool IsWalkable()
        {
            void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.tag == "SolidObject")
                {
                    return false;
                }

                return true;
            }
        }*/
    }
