using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    //单例模式：一个场景中只存在一个
    public static DialogueUI Instance { get; private set; }

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;

    private List<string> contentList;
    private int contentIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);return;
        }

        Instance = this;
    }
    private void Start()
    {
        nameText = transform.Find("NameTextBG/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);

        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Show(string name, string[] content)
    {
        gameObject.SetActive(true);

        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[0];

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnContinueButtonClick()
    {
        contentIndex++;
        if (contentIndex >= contentList.Count)
        {
            Hide();return;
        }
        
        contentText.text = contentList[contentIndex];
        

    }
}
