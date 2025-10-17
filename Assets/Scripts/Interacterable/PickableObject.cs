using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractableObject
{
    public ItemSO ItemSO;
    protected override void Interact()
    {
        Destroy(this.gameObject);
        InventoryManager.Instance.AddItem(ItemSO);
    }
}
