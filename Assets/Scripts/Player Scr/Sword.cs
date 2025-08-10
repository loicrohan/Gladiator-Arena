using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public LayerMask layer;
    public float radius = 1f;
    public float damage = 1f;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layer);

        if (hits.Length > 0)
        {
            print("Slashed");
            hits[0].GetComponent<SkeletonHealth>().ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}