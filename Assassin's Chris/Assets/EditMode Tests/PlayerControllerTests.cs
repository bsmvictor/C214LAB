using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using System.Collections;
using System;

class MyTests : InputTestFixture
{
    private GameObject player;
    private PlayerController playerController;

    [SetUp]
    public override void Setup()
    {
        // Cria um jogador temporário na cena para os testes
        player = new GameObject();
        playerController = player.AddComponent<PlayerController>();

        // Inicializa o Animator e Rigidbody2D se necessário
        playerController.oAnimator = player.AddComponent<Animator>();
        playerController.oRigidbody2D = player.AddComponent<Rigidbody2D>();

    }

    [Test]
    public void TestPlayerCanPunch()
    {
        playerController.canPunch = true;
        playerController.isPunching = false;

        playerController.PerformPunch();

        Assert.That(playerController.isPunching, Is.True);
    }

}