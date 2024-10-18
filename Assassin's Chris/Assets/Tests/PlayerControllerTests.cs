using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private GameObject player;
    private PlayerController playerController;
    private Rigidbody2D oRigidbody2D;

    [SetUp]
    public void Setup()
    {
        // Inicializa o GameObject e o componente PlayerController
        player = new GameObject();
        playerController = player.AddComponent<PlayerController>();
        oRigidbody2D = player.AddComponent<Rigidbody2D>();

        // Configura parâmetros do PlayerController (pode ser ajustado conforme necessário)
        playerController.playerSpeed = 5f;
        playerController.minX = -10f;
        playerController.maxX = 10f;
        playerController.jumpForce = 5f;
    }

    [Test]
    public void PlayerMovesRight()
    {
        // Simula input de movimento para a direita
        Input.simulateInput("Horizontal", 1f);  // Simula movimento para a direita
        playerController.Update();  // Chama o Update para simular um frame de jogo

        // Verifica se o player se moveu para a direita
        Assert.Greater(oRigidbody2D.velocity.x, 0);
    }
}
