using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damage = 1f;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);

        if(hits.Length > 0 )
        {
            print("Attacked");

            //hits[0].GetComponent<PlayerHealth>().TakeDamage(1);
            hits[0].GetComponent<HealthScr>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}