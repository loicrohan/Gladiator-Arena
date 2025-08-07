using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Player Controller Variables
    [Header("Player Controller References")]
    [SerializeField]
    private Animator playerAnim;

    [Header("Equip-Unequip variables")]
    [SerializeField]
    private GameObject sword;
    [SerializeField]
    private GameObject swordOnShoulder;
    public bool isEquipping;
    public bool isEquipped;

    [Header("Blocking variables")]
    public bool isBlocking;
    private PlayerShield shield;

    [Header("Kick variables")]
    public bool isKicking;

    [Header("Attack variables")]
    public bool isAttacking;
    private float timeSinceAttack;
    public int currentAttack = 0;
    public GameObject attackPoint;
    #endregion

    private void Awake()
    {
        shield = GetComponent<PlayerShield>();
        attackPoint.SetActive(false);
    }

    #region Player Controller Functions
    private void Update()
    {
        timeSinceAttack += Time.deltaTime;

        Attack();
        Equip();
        Block();
        //Kick();
    }
    private void Equip()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerAnim.GetBool("Grounded"))
        {
            isEquipping = true;
            playerAnim.SetTrigger("Equip");
        }
    }

    public void ActiveWeapon()
    {
        if (!isEquipped)
        {
            sword.SetActive(true);
            swordOnShoulder.SetActive(false);
            isEquipped = !isEquipped;
        }
        else
        {
            sword.SetActive(false);
            swordOnShoulder.SetActive(true);
            isEquipped = !isEquipped;
        }
    }

    public void Equipped()
    {
        isEquipping = false;
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.Mouse1) && playerAnim.GetBool("Grounded"))
        {
            playerAnim.SetBool("Block", true);
            isBlocking = true;
            shield.ActivateShield(true);
        }
        else
        {
            playerAnim.SetBool("Block", false);
            isBlocking = false;
            shield.ActivateShield(false);
        }
    }

    //public void Kick()
    //{
    //    if (Input.GetKey(KeyCode.LeftControl) && playerAnim.GetBool("Grounded"))
    //    {
    //        playerAnim.SetBool("Kick", true);
    //        isKicking = true;
    //    }
    //    else
    //    {
    //        playerAnim.SetBool("Kick", false);
    //        isKicking = false;
    //    }
    //}

    private void Attack()
    {

        if (Input.GetMouseButtonDown(0) && playerAnim.GetBool("Grounded") && timeSinceAttack > 0.8f)
        {
            if (!isEquipped)
                return;

            currentAttack++;
            isAttacking = true;

            if (currentAttack > 3)
                currentAttack = 1;

            //Reset
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            //Call Attack Triggers
            playerAnim.SetTrigger("Attack" + currentAttack);

            //Reset Timer
            timeSinceAttack = 0;
        }
    }

    //This will be used at animation event
    public void ResetAttack()
    {
        isAttacking = false;
    }
    void Activate_AttackPoint()
    {
        attackPoint.SetActive(true);
    }
    void Deactivate_AttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
    #endregion
}