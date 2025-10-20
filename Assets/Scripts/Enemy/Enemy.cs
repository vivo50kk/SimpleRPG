using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemyAgent;

    private enum EnemyState
    {
        NormalState,
        FightingState,
        MovingState,
        RestingState
    }
    private EnemyState State = EnemyState.NormalState;
    private EnemyState ChildState = EnemyState.RestingState;

    public float restTime = 2f;
    private float restTimer = 0f;

    public int HP = 100;

    public int exp = 20;


    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(State == EnemyState.NormalState)
        {
            if(ChildState == EnemyState.RestingState)
            {
                restTimer += Time.deltaTime;

                if(restTimer > restTime)
                {
                    ChildState = EnemyState.MovingState;
                    Vector3 randomPos = FindRandomPosition();
                    enemyAgent.SetDestination(randomPos);
                }
            }
            else if(ChildState == EnemyState.MovingState)
            {
                if(enemyAgent.remainingDistance <= 0)
                {
                    ChildState = EnemyState.RestingState;
                    restTimer = 0f;
                }
            }
        }
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(30);
        //}
    }

    

    Vector3 FindRandomPosition()
    {
        Vector3 RandomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return transform.position + RandomDir.normalized * Random.Range(2,5);
    }

    public void TakeDamage(int damage)
    {
        HP-= damage;
        if(HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;
        //int count = Random.Range(0,4);
        int count = 4;
        for (int i = 0; i < count; i++)
        {
            SpawnPickableItem();
        }
        EventCenter.EnemyDied(this);
        Destroy(this.gameObject);
    }
    private void SpawnPickableItem()
    {
        ItemSO item = ItemDBManager.Instance.GetRandomItem();
        GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        go.tag = Tag.INTERACTABLE;
        Animator anim = go.GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }
        PickableObject po = go.AddComponent<PickableObject>();
        po.ItemSO = item;
        //Collider collider = go.AddComponent<Collider>();
        //if (collider != null)
        //{
        //    collider.enabled = true;
        //    collider.isTrigger = false;
        //}
        // 确保有Collider（使用原有的MeshCollider）
        Collider existingCollider = go.GetComponent<Collider>();
        if (existingCollider != null)
        {
            existingCollider.enabled = true;
            existingCollider.isTrigger = false;

        }
        else
        {
            // 如果没有Collider，添加一个MeshCollider
            MeshCollider meshCollider = go.AddComponent<MeshCollider>();


            if (meshCollider != null)
            {
                meshCollider.convex = true; // 重要：MeshCollider需要设置为convex才能用于碰撞检测
                meshCollider.isTrigger = false;
            }
        }
        Rigidbody rgd = go.GetComponent<Rigidbody>();
        if(rgd != null)
        {
            
            rgd.isKinematic = false;
            rgd.useGravity = true;

        }
    }
}
