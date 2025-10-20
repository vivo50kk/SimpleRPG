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

    public ItemDetailUI itemDetailUI;
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
        
        GameObject itemGO = GameObject.Instantiate(itemPrefab,content.transform);
        itemGO.transform.SetParent(content.transform);
        ItemUI itemUI = itemGO.GetComponent<ItemUI>();
        
        itemUI.InitItem(itemSO);
    }

    public void OnItemClick(ItemSO itemSO,ItemUI itemUI)
    {
        itemDetailUI.UpdateItemDetailUI(itemSO,itemUI);
    }

    public void OnItemUse(ItemSO itemSO,ItemUI itemUI)
    {
        Destroy(itemUI.gameObject);
        InventoryManager.Instance.RemoveItem(itemSO);

        GameObject.FindGameObjectWithTag(Tag.PLAYER).GetComponent<Player>().UseItem(itemSO);
    }
}
