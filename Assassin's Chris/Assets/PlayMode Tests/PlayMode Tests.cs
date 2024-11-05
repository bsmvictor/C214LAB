using System.Collections;
using NUnit.Framework;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayModeTests : InputTestFixture
{

    
    [UnityTest]
    public IEnumerator HitSpaceAndJump()
    {
        SceneManager.LoadScene("SampleScene");
        yield return null;  
        
        var player = GameObject.FindWithTag("Player"); 
        Assert.IsNotNull(player, "O jogador não foi encontrado na cena de teste.");
        
        var playerController = player.GetComponent<PlayerController>();
        var keyboard = InputSystem.AddDevice<Keyboard>();
        
        Press(keyboard.spaceKey);
        yield return new WaitForFixedUpdate(); 
        
        Assert.IsTrue(playerController.isJumping, "Esperado que o jogador esteja pulando.");
    }
}