using Platformer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController PlayerMovement;
    private float CooldownTimer = Mathf.Infinity;
    private float AttackCooldown;
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && CooldownTimer > AttackCooldown && PlayerMovement.canAttack())
        {
            Attack();

            CooldownTimer += Time.deltaTime;
        } 
    }

    private void Attack()
    {
        CooldownTimer = 0;
    }
}
