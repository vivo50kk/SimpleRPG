using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance {  get; private set; }
    private GameObject uiGameObject;
    private GameObject content;
    public GameObject itemPrefab;
    private bool isShow = false;

    private void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        uiGameObject = transform.Find("UI").gameObject;
        content = transform.Find("UI/ListBg/Scroll View/Viewport/Content").gameObject;
        Hide();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            
            if (isShow)
            {
                Hide();
                isShow = false;
            }
            else
            {
                Show();
                isShow = true;
            }
        }
    }


    public void Show()
    {
        uiGameObject.SetActive(true);
    }

    public void Hide()
    {
        uiGameObject.SetActive(false);
    }
    public void AddItem(ItemSO itemSO)
    {
        if (itemSO == null)
        {
            Debug.LogError("InventoryUI.AddItem: 传入的 itemSO 为 null.");
            return;
        }

        if (itemPrefab == null)
        {
            Debug.LogError("InventoryUI.AddItem: itemPrefab 未在 Inspector 中设置.");
            return;
        }
        GameObject itemGO = GameObject.Instantiate(itemPrefab);
        itemGO.transform.parent = content.transform;
        ItemUI itemUI = itemGO.GetComponent<ItemUI>();
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
        itemUI.InitItem(itemSO.icon, itemSO.name, type);
    }
}
