using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinWeapon : Weapon
{
    public GameObject BulletPerfab;
    public float BulletSpeed;

    private GameObject bulletGo;

    private void Start()
    {
        SpawnBullet();
    }

    override public void Attack()
    {
        if(bulletGo!= null)
        {
            bulletGo.transform.parent = null;
            bulletGo.GetComponent<Rigidbody>().velocity = transform.forward * BulletSpeed;
            bulletGo = null;
            Invoke("SpawnBullet", 0.5f);
        }
        else
        {
            return;
        }

            
    }

    private void SpawnBullet()
    {
        bulletGo = GameObject.Instantiate(BulletPerfab, transform.position, transform.rotation);
        bulletGo.transform.parent = transform;
    }
}
