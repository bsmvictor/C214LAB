using System.Collections;
using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

public class PlayModeTests : InputTestFixture
{
    [UnityTest]
    public IEnumerator HitSpaceAndJump()
    {
        // Criação do GameObject e componentes
        var gameObject = new GameObject();
        var animator = gameObject.AddComponent<Animator>();
        gameObject.AddComponent<Rigidbody2D>();
        var playerController = gameObject.AddComponent<PlayerController>();

        // Adiciona um controlador de animação vazio para evitar erros
        var animatorController = new AnimatorController();
        animator.runtimeAnimatorController = animatorController;
        
        // Configura o sistema de entrada e simula o pressionamento da tecla espaço
        var keyboard = InputSystem.AddDevice<Keyboard>();
        Press(keyboard.spaceKey);
        InputSystem.Update();

        // Aguarda um quadro para que a entrada seja processada
        yield return null;

        // Verifica se o player pode pular após pressionar a tecla espaço
        Assert.IsTrue(playerController.canJump, "Esperado que o jogador pudesse pular, mas não foi possível.");
    }
}