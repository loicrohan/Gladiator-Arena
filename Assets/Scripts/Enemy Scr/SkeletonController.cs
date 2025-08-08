using UnityEngine;
using UnityEngine.AI;

public enum SkeletonState
{
    CHASE,
    ATTACK
}

public class SkeletonController : MonoBehaviour
{
    //[Header("Movements Settings")]
    private CharacterAnimations skeleton_Anim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;
    public float move_Speed = 3.5f;
    public float attack_Distance = 1f;
    public float chase_Player_After_Attack_Distance = 1f;
    private float wait_Before_Attack_Time = 3f;
    private float attack_Timer;
    public GameObject attackPoint;

    private SkeletonState skeleton_State;
    void Awake()
    {
        skeleton_Anim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start()
    {
        skeleton_State = SkeletonState.CHASE;

        attack_Timer = wait_Before_Attack_Time;
    }

    void Update()
    {
        if(skeleton_State == SkeletonState.CHASE)
        {
            ChasePlayer();
        }
        if (skeleton_State == SkeletonState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_Speed;

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            skeleton_Anim.Run(false);
        }
        else
        {
            skeleton_Anim.Run(true);
        }

        if(Vector3.Distance(transform.position, playerTarget.position)<=attack_Distance)
        {
            skeleton_State = SkeletonState.ATTACK;
        }

    }

    void AttackPlayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        skeleton_Anim.Run(false);

        attack_Timer += Time.deltaTime;

        if(attack_Timer > wait_Before_Attack_Time)
        {
            if(Random.Range(0,2) > 0)
            {
                skeleton_Anim.Attack();
            }

            //attack_Timer = 0f;
        }

        if(Vector3.Distance(transform.position,playerTarget.position)
            >attack_Distance + chase_Player_After_Attack_Distance)

        {
            navAgent.isStopped = false;
            skeleton_State = SkeletonState.CHASE;
        }

        void Activate_AttackPoint()
        {
            attackPoint.SetActive(true);
        }
        void Deactivate_AttackPoint()
        {
            if(attackPoint.activeInHierarchy)
            {
                attackPoint.SetActive(false);
            }
        }
    }
}