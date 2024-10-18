using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    private Rigidbody2D oRigidbody2D;
    public Animator oAnimator;

    [Space]
    [Header("Stats")]
    public float playerSpeed = 10;
    public float jumpForce = 50;
    public float fallMult = 1.5f;
    public Vector2 X_bounds = new(-10, 10);
    public Vector2 Y_bounds = new(-10, 10);

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool canPunch;
    public bool isPunching;
    public bool isJumping;
    public bool onAir = false;

    // Setters
    public void SetPlayerSpeed(float speed) => playerSpeed = speed;
    public void SetJumpForce(float force) => jumpForce = force;
    public void SetXBounds(Vector2 xBounds) => X_bounds = xBounds;
    public void SetYBounds(Vector2 yBounds) => Y_bounds = yBounds;

    //Getters

    public float GetPlayerSpeed() => playerSpeed;
    public float GetJumpForce() => jumpForce;
    public Vector2 GetXBounds() => X_bounds;
    public Vector2 GetYBounds() => Y_bounds;

    void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Bater();
        if (!isPunching)
        {
            PlayerMovement();
        }

        if (oRigidbody2D.velocity.y < 0)
        {
            oRigidbody2D.velocity += Physics2D.gravity.y * fallMult * Time.deltaTime * Vector2.up;
        }
        else if (oRigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            oRigidbody2D.velocity += Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }

        // Verifica o input da tecla de pulo
        bool isJumpKeyPressed = Input.GetKeyDown(KeyCode.Space);

        // Passa o valor da tecla pressionada para o método InputJump
        InputJump(isJumpKeyPressed);

        bool isPunchKeyPressed = Input.GetButtonDown("Fire1");

        InputPunch(isPunchKeyPressed);

    }

    private void PlayerMovement()
    {
        // Armazena a direção que o jogador define
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        oRigidbody2D.velocity = new Vector2(horizontalInput * playerSpeed, oRigidbody2D.velocity.y);

        if (horizontalInput == 0)
        {
            oAnimator.SetTrigger("isIdle");
        }
        else
        {
            oAnimator.SetTrigger("isWalking");
        }

        //limita movimentaçao do player
        oRigidbody2D.position = new Vector2(Mathf.Clamp(oRigidbody2D.position.x, X_bounds.x, X_bounds.y), oRigidbody2D.position.y);

        Jump();

        //Espelhar
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void InputJump(bool isJumpKeyPressed)
    {
        if (isJumpKeyPressed && !onAir)
        {
            isJumping = true;
        }
    }



    public void Jump()
    {
        if (isJumping)
        {
            oRigidbody2D.velocity = new Vector2(oRigidbody2D.velocity.x, jumpForce);
            onAir = true;
            oAnimator.SetTrigger("isJumping");
            isJumping = false;
        }
    }

    public void InputPunch(bool isPunchKeyPressed)
    {
        if (isPunchKeyPressed && canPunch && !isPunching)
        {
            isPunching = true;
        }
    }

    public void Bater()
    {
        if (isPunching)
        {
            if (!onAir)
            {
                oAnimator.SetTrigger("isPunching");
                oRigidbody2D.velocity = new(0, oRigidbody2D.velocity.y);
                StartCoroutine(IsPunching());
            }
            else
            {
                //oAnimator.SetTrigger("isPunching"); //Mudar pra animção de airpunch
                //oRigidbody2D.velocity = Vector2.zero;
                //StartCoroutine(IsAirPunching());
            }
        }
    }

    private IEnumerator IsPunching()
    {
        canMove = false;
        isPunching = true;
        canPunch = false;
        yield return new WaitForSeconds(oAnimator.GetCurrentAnimatorStateInfo(0).length);
        isPunching = false;
        canMove = true;
        canPunch = true;
    }

    private IEnumerator IsAirPunching()
    {
        canMove = false;
        isPunching = true;
        oRigidbody2D.gravityScale = 0;
        yield return new WaitForSeconds(oAnimator.GetCurrentAnimatorStateInfo(0).length);
        oRigidbody2D.gravityScale = 4;
        isPunching = false;
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            oAnimator.SetTrigger("isIdle");
            onAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onAir = true;
        }
    }
}