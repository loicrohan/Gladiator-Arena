using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject _pause;
    public static bool isPaused;

    void Start()
    {
        _pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void PauseGame()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameObject cam = GameObject.Find("PlayerArmature");
        cam.GetComponent<ThirdPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameObject cam = GameObject.Find("PlayerArmature");
        cam.GetComponent<ThirdPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}