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
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();

            CooldownTimer += Time.deltaTime;
        } 
    }


    private void Attack()
    {
        CooldownTimer = 0;

        //bullets[FindBullet()].transform.position = firePoint.position;
        //bullets[FindBullet()].GetComponent<Bullet>().SetDirection(Mathf.Sign(transform.localScale.x));

        //New instantiation code
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Destroy(bullet, 3f);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.right * bulletSpeed;
    }

    //Old code from when I was trying to make this with arrays instead of a prefab, didn't work, changed to the current instantiated method - Xander
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
