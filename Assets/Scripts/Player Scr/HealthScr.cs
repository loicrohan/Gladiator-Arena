//using JetBrains.Annotations;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScr : MonoBehaviour
{
    public static HealthScr instance;
    public float health = 5f;
    [SerializeField] private Slider healthSlider;
    [HideInInspector] public bool shieldActivated;
    public Animator anim;
    public GameObject Loser;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public void ApplyDamage(float damage)
    {
        if (shieldActivated || SkeletonHealth.Instance.health <= 0)
        {
            return;
        }

        health -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = health / 5f;
            AudioManager.instance.Play("Player Hurt");
            anim.SetTrigger("damage");

        }

        if(health <= 0)
        {
            print("Player Died");
            AudioManager.instance.Stop("Player Hurt");
            AudioManager.instance.Play("Player Death");
            anim.SetTrigger("die");
            GetComponent<CharacterController>().enabled = false;
            GetComponent<ThirdPersonController>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<HealthScr>().enabled = false;
            Invoke("StopAnimation", 0.85f);
        }
    }

    void StopAnimation()
    {
        SkeletonHealth.Instance.anim.enabled = false;
        Invoke("YouLost", 3.25f);
    }

    void YouLost()
    {
        Loser.SetActive(true);
        Invoke("MainMenu", 4.25f);
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}