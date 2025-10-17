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
            bulletGo.GetComponent<Collider>().enabled = true;
            Destroy(bulletGo, 10f);
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
        bulletGo.GetComponent<Collider>().enabled = false;
        if (tag == Tag.INTERACTABLE)
        {
            Destroy(bulletGo.GetComponent<JavelinBullet>());

            bulletGo.tag = Tag.INTERACTABLE;
            PickableObject po = bulletGo.AddComponent<PickableObject>();
            po.ItemSO = GetComponent<PickableObject>().ItemSO;
            Rigidbody rgd = bulletGo.GetComponent<Rigidbody>();
            rgd.constraints = ~RigidbodyConstraints.FreezeAll;
            bulletGo.GetComponent<Collider>().enabled = true;

            bulletGo.transform.parent = null;
            Destroy(this.gameObject);

        }
    }
}
