using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private bool isTorchFlameParticleSystemActive;
    private bool is2HandHold = false;
    private bool isHoldingTorch = false;
    private Vector3 moveInput;
    
    private Vector3 heldTorchFlameDownPosition = new Vector3(-0.007f, 0.0372f, -0.035f);
    private Vector3 heldTorchFlameUpPosition = new Vector3(-0.007f, 0.0372f, 0.0425f);
    private Vector3 heldTorchFlameLeftPosition = new Vector3(-0.0696f, 0.0821f, -0.035f);
    private Vector3 heldTorchFlameRightPosition = new Vector3(0.064f, 0.0821f, -0.035f);

    private Animator animatorHeldItem;
    private Animator animatorBody;
    private Animator animatorLegs;
    [SerializeField] private GameObject heldTorchFlame;
    [SerializeField] private GameObject heldItem;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject legs;


    [SerializeField] private Rigidbody playerBody;

    private void Awake()
    {
        animatorHeldItem = heldItem.GetComponent<Animator>();
        animatorBody = body.GetComponent<Animator>();
        animatorLegs = legs.GetComponent<Animator>();

        heldTorchFlame.SetActive(false);
    }


    private void Update()
    {
        //movement controller
        
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
        //print(moveInput.x);
        //add if code to change postive x values of x to 1 to fix animation latency (and for z)
        animatorBody.SetFloat("moveX", moveInput.x);
        animatorBody.SetFloat("moveY", moveInput.z);
        animatorLegs.SetFloat("moveX", moveInput.x);
        animatorLegs.SetFloat("moveY", moveInput.z);
        animatorHeldItem.SetFloat("moveX", moveInput.x);
        animatorHeldItem.SetFloat("moveY", moveInput.z);

        if (moveInput != Vector3.zero)
        {
            animatorBody.SetBool("isMoving", true);
            animatorLegs.SetBool("isMoving", true);
            animatorHeldItem.SetBool("isMoving", true);
        }

        if (moveInput == Vector3.zero)
        {
            animatorBody.SetBool("isMoving", false);
            animatorLegs.SetBool("isMoving", false);
            animatorHeldItem.SetBool("isMoving", false);
        }

        //2-handed holding controller

        if (Input.GetButtonDown("EquipmentCycle"))
        {
            if (is2HandHold)
            {
                animatorBody.SetBool("is2HandHolding", false);
                animatorHeldItem.SetBool("is2HandHolding", false);
                animatorHeldItem.SetBool("isHoldingTorch", false);
                is2HandHold = false;
                isHoldingTorch = false;
            }
            else
            {
                animatorBody.SetBool("is2HandHolding", true);
                animatorHeldItem.SetBool("is2HandHolding", true);
                animatorHeldItem.SetBool("isHoldingTorch", true);
                is2HandHold = true;
                isHoldingTorch = true;
            }
        }

        //flame on/off control

        if (isHoldingTorch)
        {
            if (isTorchFlameParticleSystemActive == false)
            {
                heldTorchFlame.SetActive(true);
                isTorchFlameParticleSystemActive = true;
            }
        }
        else
        {
            heldTorchFlame.SetActive(false);
            isTorchFlameParticleSystemActive = false;
        }

        

        
        
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(moveInput) * moveSpeed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

        //call flame position coroutine

        
    }

    private void FixedUpdate()
    {
        MoveFlamePosition();
    }
    //flame position

    private void MoveFlamePosition()
    {
        if (moveInput.x < 0)
        {
            if (moveInput.z == 0)
            {
                heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameLeftPosition);
            }
            else
            {
                if (moveInput.z < 0)
                {
                    heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameDownPosition);
                }
                else
                {
                    if (moveInput.z > 0)
                    {
                        heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameUpPosition);
                    }
                    else
                    {
                        heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameLeftPosition);
                    }
                }
            }
        }
        else
        {
            if (moveInput.x > 0)
            {
                if (moveInput.z == 0)
                {
                    heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameRightPosition);
                }
                else
                {
                    if (moveInput.z < 0)
                    {
                        heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameDownPosition);
                    }
                    else
                    {
                        if (moveInput.z > 0)
                        {
                            heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameUpPosition);
                        }
                        else
                        {
                            heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameRightPosition);
                        }
                    }
                }
            }
            else
            {
                if (moveInput.z < 0)
                {
                    heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameDownPosition);
                }
                else
                {
                    if (moveInput.z > 0)
                    {
                        heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameUpPosition);
                    }
                    else
                    {
                        heldTorchFlame.transform.position = transform.TransformPoint(heldTorchFlameDownPosition);
                    }
                }
            }
        }
        
    }
}
