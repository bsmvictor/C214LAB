using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General References")]                          //headers para ajudar na organizaçao de variaveis do ponto de vista do unity
    private Rigidbody2D oRigidbody2D;

    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;             //velocidade em que o jogador se move
    private Vector2 movementInput;                          //entrada de movimento
    private Vector2 movementDirection;                      //qual direçao x e y o jogador ira andar
    [SerializeField] private float jumpForce = 10;
    
    [Header("Player Limits")]
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    
    void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        ReceiveInputs();
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            oRigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    
    private void ReceiveInputs()
    {
        // Armazena a direção que o jogador define
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), oRigidbody2D.velocity.y);
    }
    private void PlayerMovement()
    {
        //movimenta o jogador com base na direçao
        oRigidbody2D.velocity = movementInput * playerSpeed;

        //limita movimentaçao d player
        oRigidbody2D.position = new Vector2(Mathf.Clamp(oRigidbody2D.position.x, minX, maxX), oRigidbody2D.position.y);
        
        
    }
    

}
