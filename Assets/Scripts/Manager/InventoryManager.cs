using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);return;
        }
        Instance = this;
    }

    public List<ItemSO> itemList;

    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
        //InventoryUI.Instance.AddItem(item);
    }
}
