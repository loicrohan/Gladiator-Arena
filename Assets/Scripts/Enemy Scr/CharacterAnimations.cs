using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Run(bool run)
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    public void Attack()
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }
    #region for defense animation
    //void FreezeAnimaton()
    //{
    //    anim.speed = 0f;
    //}

    //public void UnFreezeAnimation()
    //{
    //    anim.speed = 1f;
    //}
    #endregion

}