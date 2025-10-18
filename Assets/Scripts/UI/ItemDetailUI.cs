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
                type = "����";
                break;
            case ItemType.Consumable:
                type = "����Ʒ";
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
                    propertyName = "����ֵ";
                    break;
                case ItemPropertyType.EnergyValue:
                    propertyName = "����ֵ";
                    break;
                case ItemPropertyType.MentalValue:
                    propertyName = "����ֵ";
                    break;
                case ItemPropertyType.SpeedValue:
                    propertyName = "�ٶ�";
                    break;
                case ItemPropertyType.AttackValue:
                    propertyName = "������";
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
