using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    public const string ANIM_PARM_ATTACK = "IsAttack";

    private Animator anim;

    public int atkValue = 50;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Attack();
    //    }
    //}
    override public void Attack()
    {
        anim.SetTrigger(ANIM_PARM_ATTACK);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(atkValue);
        }
    }
}
