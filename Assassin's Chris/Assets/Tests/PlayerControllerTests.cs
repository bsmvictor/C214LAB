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

        // Configura os parâmetros do PlayerController
        playerController.SetPlayerSpeed(5f);
        playerController.SetMinX(-10f);
        playerController.SetMaxX(10f);
        playerController.SetJumpForce(5f);
    }

    //[Test]
    //public void TestJump()
    //{
    //    // Arrange
    //    float initialYPosition = player.transform.position.y;
    //    float jumpForce = playerController.GetJumpForce();

    //    // Act
    //    playerController.Jump();

    //    // Assert
    //    Assert.Greater(player.transform.position.y, initialYPosition);
    //    Assert.AreEqual(jumpForce, oRigidbody2D.velocity.y);
    //}
}
