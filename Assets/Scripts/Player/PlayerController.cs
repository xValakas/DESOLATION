using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] public float movingSpeed;
        [SerializeField] public float jumpForce;
        [SerializeField] private float moveInput;

        private bool facingRight = true;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rb;
        private Animator animator;
        //private GameManager gameManager;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            //gameManager = GameObject.FindFirstObjectByType(typeof(GameManager)) as GameManager;
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            // if (!isGrounded) animator.SetInteger("playerState", 2); // Turn on jump animation

            if (facingRight == true && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == false && moveInput < 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

    }
}