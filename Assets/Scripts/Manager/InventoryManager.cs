using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public List<ItemSO> itemList;
    public ItemSO defaultWeapon;

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

    //IEnumerator Start()
    //{
    //    yield return new WaitForSeconds(1);
    //    AddItem(defaultWeapon);
    //}

    public void AddItem(ItemSO item)
    {
        itemList.Add(item);
        InventoryUI.Instance.AddItem(item);

        MessageUI.Instance.Show("ƒ„ ∞µ√¿’“ª∏ˆ:"+item.name);
    }
    public void RemoveItem(ItemSO item)
    {
        itemList.Remove(item);
        
    }
}
