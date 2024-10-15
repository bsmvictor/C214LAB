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
    private Vector2 movementDirection;                      //qual direçao jogador ira andar
    [SerializeField] private float jumpForce;
    
    [Header("Player Limits")]
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    
    void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            oRigidbody2D.velocity = new Vector2(oRigidbody2D.velocity.x, jumpForce);
        }
    }
    
    private void PlayerMovement()
    {
        // Armazena a direção que o jogador define
        oRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, oRigidbody2D.velocity.y);
        
        

        //limita movimentaçao d player
        oRigidbody2D.position = new Vector2(Mathf.Clamp(oRigidbody2D.position.x, minX, maxX), oRigidbody2D.position.y);
        
        
    }
    

}
