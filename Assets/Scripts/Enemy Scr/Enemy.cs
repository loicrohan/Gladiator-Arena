using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int HP = 5;
    public Slider healthBar;
    public Animator anim;
    void Update()
    {
        healthBar.value = HP;
    }
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //play death animation
            AudioManager.instance.Play("Dragon Death");
            anim.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
            //Destroy(this.gameObject, 5);
        }
        else
        {
            //play hit animation
            AudioManager.instance.Play("Dragon Damage");
            anim.SetTrigger("damage");
            Debug.Log(HP + " : life");
        }
    }
}