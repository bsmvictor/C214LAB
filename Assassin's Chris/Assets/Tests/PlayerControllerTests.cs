using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using System.Collections;

class MyTests : InputTestFixture
{
    [Test]
    public void CanPressButtonOnGamepad()
    {
        var keyboard = InputSystem.AddDevice<Keyboard>();
        Press(keyboard.shiftKey);

        Assert.That(keyboard.shiftKey.isPressed, Is.True);
    }

    private GameObject player;
    private PlayerController playerController;
    private InputAction punchAction;

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
    public void CanPunch()
    {
        playerController.canPunch = true;
        playerController.isPunching = false;

        Press(Keyboard.current.shiftKey);

        Assert.That(playerController.isPunching, Is.True);
    }

}
