using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{

    public Canvas canvas;
    public Canvas canvasControle;

    void Start()
    {
        canvas.enabled = true;
        canvasControle.enabled = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Controles()
    {
        canvas.enabled = false;
        canvasControle.enabled = true;
    }

    public void Voltar()
    {
        canvas.enabled = true;
        canvasControle.enabled = false;
    }
}