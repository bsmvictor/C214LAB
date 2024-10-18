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
        // Inicializa o GameObject e o PlayerController
        player = new GameObject();
        playerController = player.AddComponent<PlayerController>();
        oRigidbody2D = player.AddComponent<Rigidbody2D>();
        playerController.oAnimator = player.AddComponent<Animator>();

        // Configura os parâmetros do PlayerController
        playerController.SetPlayerSpeed(5f);
        playerController.SetXBounds(new Vector2(-10, 10));
        playerController.SetYBounds(new Vector2(-10, 10));
        playerController.SetJumpForce(5f);
    }

    [Test]
    public void TestInputJump()
    {
        // Arrange
        playerController.onAir = false;  // O jogador não está no ar

        // Act - Simula que a tecla de pulo foi pressionada
        playerController.InputJump(true);

        // Assert
        Assert.IsTrue(playerController.isJumping);  // Verifica se o jogador está pulando
    }

    [Test]
    public void TestInputBater()
    {
        // Arrange - setup
        playerController.canPunch = true;
        playerController.isPunching = false;

        // Act - Simula que a tecla de soco foi pressionada
        playerController.InputPunch(true);
        playerController.Bater();  // Certifica que a lógica do soco é processada

        // Assert
        Assert.IsTrue(playerController.isPunching);  // Verifica se o jogador está batendo
        Assert.IsFalse(playerController.canPunch);  // Verifica se o jogador não pode socar enquanto o soco está ativo
    }

}
