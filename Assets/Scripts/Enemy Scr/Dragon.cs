using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private int HP = 5;
    public Animator anim;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0 )
        {
            //play death animation
            anim.SetTrigger("die");
            GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject,5);
        }
        else
        {
            //play hit animation
            anim.SetTrigger("damage");
        }
    }
}
