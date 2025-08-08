using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkeletonHealth : MonoBehaviour
{
    public static SkeletonHealth Instance;
    public float health = 5f;
    [SerializeField] private Slider healthSlider;
    public Animator anim;
    public GameObject Winner;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = health / 5f;
            AudioManager.instance.Play("Skeleton Hurt");
            anim.SetTrigger("Damage");

        }

        if (health <= 0)
        {
            print("Enemy Died");
            AudioManager.instance.Stop("Skeleton Hurt");
            AudioManager.instance.Play("Skeleton Death");
            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Skeleton>().enabled = false;
            GetComponent<SkeletonHealth>().enabled = false;
            GameObject cam = GameObject.Find("PlayerArmature");
            cam.GetComponent<ThirdPersonController>().enabled = false;
            Invoke("YouWin", 2.25f);
        }
    }

    void YouWin()
    {
        Winner.SetActive(true);
        Invoke("MainMenu", 4.25f);
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}