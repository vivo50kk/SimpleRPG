using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplete;

    public ItemSO ItemSO;
    private ItemUI itemUI;

    private void Start()
    {
        propertyTemplete.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void UpdateItemDetailUI(ItemSO itemSO,ItemUI itemUI)
    {
        this.ItemSO = itemSO;
        this.itemUI = itemUI;
        this.gameObject.SetActive(true);
        string type = "";
        switch (itemSO.itemType)
        {
            case ItemType.Weapon:
                type = "武器";
                break;
            case ItemType.Consumable:
                type = "消耗品";
                break;
        }
        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
        descriptionText.text = itemSO.description;

        foreach (Transform child in propertyGrid.transform)
        {
            if(child.gameObject.activeSelf)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        foreach (ItemProperty property in itemSO.propertyList)
        {
            string propertyStr = "";
            string propertyName = "";
            switch (property.propertyType)
            {
                case ItemPropertyType.HPValue:
                    propertyName = "生命值";
                    break;
                case ItemPropertyType.EnergyValue:
                    propertyName = "饥饿值";
                    break;
                case ItemPropertyType.MentalValue:
                    propertyName = "精神值";
                    break;
                case ItemPropertyType.SpeedValue:
                    propertyName = "速度";
                    break;
                case ItemPropertyType.AttackValue:
                    propertyName = "攻击力";
                    break;
            }
            propertyStr += propertyName;
            propertyStr += property.value;
            GameObject go = GameObject.Instantiate(propertyTemplete);
            go.SetActive(true);
            go.transform.parent = propertyGrid.transform;
            go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
        }
        
    }

    public void OnUseBottonClick()
    {
        InventoryUI.Instance.OnItemUse(ItemSO,itemUI);
        this.gameObject.SetActive(false);
    }
}
