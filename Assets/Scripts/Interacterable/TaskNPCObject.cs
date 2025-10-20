using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    public string[] contentInTaskExecuting;
    public string[] contentInTaskComplete;
    public string[] contentInTaskEnd;

    private void Start()
    {
        gameTaskSO.state = GameTaskState.Waiting;
    }
    protected override void Interact()
    {
        switch(gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                //
                DialogueUI.Instance.Show(npcName, gameTaskSO.dialogue, OnDialogueEnd);
                break;
            case GameTaskState.Executing:
                DialogueUI.Instance.Show(npcName, contentInTaskExecuting, OnDialogueEnd);
                break;
            case GameTaskState.Complete:
                DialogueUI.Instance.Show(npcName, contentInTaskComplete, OnDialogueEnd);
                break;
            case GameTaskState.End:
                DialogueUI.Instance.Show(npcName, contentInTaskEnd, OnDialogueEnd);
                break;
            default:
                break;

        }
        //print("你是来找工作的吗？");
    }

    public void OnDialogueEnd()
    {
        switch(gameTaskSO.state)
        {
            case GameTaskState.Waiting:
                gameTaskSO.Start();
                InventoryManager.Instance.AddItem(gameTaskSO.startReward);
                MessageUI.Instance.Show("你接受了一个任务!");
                break;
            case GameTaskState.Executing:
                break;
            case GameTaskState.Complete:
                gameTaskSO.End();
                InventoryManager.Instance.AddItem(gameTaskSO.endReward);
                MessageUI.Instance.Show("任务已提交!");
                break;
            case GameTaskState.End:
                //任务结束
                break;
        }
    }
}
