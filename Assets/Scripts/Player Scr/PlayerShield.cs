using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private HealthScr healthScr;

    // Start is called before the first frame update
    void Awake()
    {
        healthScr = GetComponent<HealthScr>();
    }

    public void ActivateShield(bool shieldActive)
    {
        healthScr.shieldActivated = shieldActive;
    }
}