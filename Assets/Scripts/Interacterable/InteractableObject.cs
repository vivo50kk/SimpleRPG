using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractableObject : MonoBehaviour
{
    private NavMeshAgent playerAgent;
    public void OnClick(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        StartCoroutine(WaitForInteraction());
    }

    private IEnumerator WaitForInteraction()
    {
        while (playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                playerAgent = null;
                yield break; // 结束协程
            }
            yield return null; // 每帧检测一次
        }
    }

    protected virtual void Interact()
    {
        print("Interacting with Interactable Object.");
    }
}

