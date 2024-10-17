using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General References")]                          //headers para ajudar na organizaçao de variaveis do ponto de vista do unity
    private Rigidbody2D oRigidbody2D;
    private AnimationController animation;
    private Animator oAnimator;

    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;             //velocidade em que o jogador se move
    private Vector2 movementInput;                          //entrada de movimento
    private Vector2 movementDirection;                      //qual direçao jogador ira andar
    private float horizontalInput;                          //entrada horizontal do jogador
    [SerializeField] private float jumpForce;
    private bool canJump;

    [Header("Player Punch")]
    [SerializeField] private float tempoMaxEntreAtaques;
    private float tempoAtualEntreAtaques;
    private bool canPunch = true;
    
    [Header("Player Limits")]
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    
    void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        animation = GetComponent<AnimationController>();
        oAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        PlayerMovement();
        EspelharPlayer();
        Bater();
        CronometroDeAtaque();
    }
    
    private void PlayerMovement()
    {
        // Armazena a direção que o jogador define
        horizontalInput = Input.GetAxisRaw("Horizontal");
        oRigidbody2D.velocity = new Vector2(horizontalInput * playerSpeed, oRigidbody2D.velocity.y);

        if(horizontalInput == 0)
        {
            oAnimator.SetTrigger("isIdle");
        }
        else
        {
            oAnimator.SetTrigger("isWalking"); 
        }
        
        //limita movimentaçao do player
        oRigidbody2D.position = new Vector2(Mathf.Clamp(oRigidbody2D.position.x, minX, maxX), oRigidbody2D.position.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            oRigidbody2D.velocity = new Vector2(oRigidbody2D.velocity.x, jumpForce);
            canJump = false;
        }
    }

    private void EspelharPlayer()
    {

        //se direita 
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //se esquerda
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);    //alterando somente eixo x
        }
    }

    private void Bater()
    {
        if (Input.GetButtonDown("Fire1") && canJump && canPunch)
        {
            oAnimator.SetTrigger("isPunching");   
            canPunch = false;

            //tem que fazer o boneco parar quando bater

        }
    }

    private void CronometroDeAtaque()
    {
        tempoAtualEntreAtaques -= Time.deltaTime;       //time.deltatime permite controlar melhor o framerate e descontar x segundos a cada segundo

        if (tempoAtualEntreAtaques <= 0)
        {
            canPunch = true;
            tempoAtualEntreAtaques = tempoMaxEntreAtaques;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
