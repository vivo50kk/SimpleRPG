using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JavelinBullet : MonoBehaviour
{
    public int atkValue = 30;
    private Rigidbody rgd;
    private Collider col;

    private void Start()
    {
        rgd = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == Tag.PLAYER)
        {
            return;
        }

        rgd.velocity = Vector3.zero;
        rgd.isKinematic = true;
        col.enabled = false;
        transform.parent = collision.transform;

        Destroy(this.gameObject, 1f);
        
        if (collision.gameObject.tag == Tag.ENEMY)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }

    
}
