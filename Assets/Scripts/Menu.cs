using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject _Menu;

    private void Start()
    {
        _Menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Arena");
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitButton()
    {
        Application.Quit();
        print("Quit the game");
    }
}