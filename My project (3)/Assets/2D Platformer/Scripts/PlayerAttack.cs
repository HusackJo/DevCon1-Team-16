using Platformer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController PlayerMovement;
    private float CooldownTimer = Mathf.Infinity;
    public float attackCooldown;
    private Transform firePoint;
    private GameObject[] bullets;
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && CooldownTimer > attackCooldown && PlayerMovement.canAttack())
        {
            Attack();

            CooldownTimer += Time.deltaTime;
        } 
    }

    private void Attack()
    {
        CooldownTimer = 0;

        bullets[0].transform.position = firePoint.position;
        bullets[0].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localscale.x));
    }
}
