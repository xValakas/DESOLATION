using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] public Vector2 moveSpeed;
    [SerializeField] public float speedMultiplier;
    [SerializeField] public float jumpForce;
    [SerializeField] public float moveInput;
    [SerializeField] public float sprintCooldown;

    [Header("Movement Controls")]
    [SerializeField] KeyCode upKey;
    [SerializeField] KeyCode downKey;
    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;
    private bool isGrounded;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private Animator animator;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(leftKey))
        {
            rb.AddForce(-moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            animator.SetInteger("playerState", 1); // Turn on left walk animation
        }
        else if (Input.GetKeyDown(rightKey))
        {
            rb.AddForce(moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            animator.SetInteger("playerState", 2); // Turn on right walk animation
        }
        else
        {
           //idle animator....
        }

    }

}
