using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] public PlayerController player;
    public GameObject PauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.activeSelf){
            player.HandleUpdate();
        }
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Continue(){
        PauseMenu.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed){
            if(PauseMenu.activeSelf){
            PauseMenu.SetActive(false);
            }else{
                PauseMenu.SetActive(true);
            }
        }
    }

}
