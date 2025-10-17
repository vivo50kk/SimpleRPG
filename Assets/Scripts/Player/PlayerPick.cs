using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPick : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag ==Tag.INTERACTABLE)
        {
            PickableObject po = collision.gameObject.GetComponent<PickableObject>();
            if (po != null)
            {
                print("Picking up " + po.ItemSO.name);
                InventoryManager.Instance.AddItem(po.ItemSO);
                Destroy(po.gameObject);
            }
        }
    }
}
