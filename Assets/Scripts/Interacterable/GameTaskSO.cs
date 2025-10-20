using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTaskState
{
    Waiting,
    Executing,
    Complete,
    End
}
[CreateAssetMenu()]
public class GameTaskSO:ScriptableObject
{
    public GameTaskState state;

    public string[] dialogue;

    public ItemSO startReward;
    public ItemSO endReward;

    public int enemyCountNeed = 10;
    public int currentEnemyCount = 0;

    public void Start()
    {
        currentEnemyCount = 0;
        state = GameTaskState.Executing;
        EventCenter.OnEnemyDied += OnEnemyDied;
    }
    
    private void OnEnemyDied(Enemy enemy)
    {
        if (state == GameTaskState.Complete) return;
        currentEnemyCount++;
        if (currentEnemyCount >= enemyCountNeed)
        {
            state = GameTaskState.Complete;
            MessageUI.Instance.Show("��������ɣ���ǰȥ�ύ����!");

        }
    }

    public void End()
    {
        EventCenter.OnEnemyDied -= OnEnemyDied;
        state = GameTaskState.End;
    }
} 
