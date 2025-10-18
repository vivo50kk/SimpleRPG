using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public List<ItemSO> itemList;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);return;
        }
        Instance = this;
        itemList = new List<ItemSO>();
    }

    

    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
        InventoryUI.Instance.AddItem(item);
    }
    public void RemoveItem(ItemSO item)
    {
        itemList.Remove(item);
        
    }
}
