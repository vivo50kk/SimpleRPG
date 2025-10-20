using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    //����ģʽ��һ��������ֻ����һ��
    public static DialogueUI Instance { get; private set; }

    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private Button continueButton;

    private List<string> contentList;
    private int contentIndex = 0;
    private GameObject uiGameObject;

    private Action OnDiagueEnd;

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
        nameText = transform.Find("UI/NameTextBG/NameText").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/ContentText").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/ContinueButton").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);

        uiGameObject = transform.Find("UI").gameObject;

        Hide();
    }
    public void Show()
    {
        uiGameObject.SetActive(true);
    }

    public void Show(string name, string[] content,Action OnDiagueEnd=null)
    {
        uiGameObject.SetActive(true);

        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[0];

        this.OnDiagueEnd = OnDiagueEnd;
    }
    public void Hide()
    {
        uiGameObject.SetActive(false);
    }

    private void OnContinueButtonClick()
    {
        contentIndex++;
        if (contentIndex >= contentList.Count)
        {
            OnDiagueEnd?.Invoke();
            Hide();return;
        }
        
        contentText.text = contentList[contentIndex];
        

    }
}
