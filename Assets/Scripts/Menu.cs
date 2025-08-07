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
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Arena");
    }
    public void QuitButton()
    {
        Application.Quit();
        print("Quit the game");
    }
}