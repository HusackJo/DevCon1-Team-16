using Platformer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerController PlayerMovement;
    public float CooldownTimer = Mathf.Infinity;
    public float attackCooldown;
    public Transform firePoint;
    public GameObject[] bullets;
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && CooldownTimer > attackCooldown && PlayerMovement.isGrounded)
        {
            Attack();

            CooldownTimer += Time.deltaTime;
        } 
    }


    private void Attack()
    {
        CooldownTimer = 0;

        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 0;

    }
}
