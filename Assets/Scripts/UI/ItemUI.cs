using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemUI : MonoBehaviour
{
    public UnityEngine.UI.Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;

    public void InitItem(Sprite iconSprite,string name,string type)
    {
        iconImage.sprite = iconSprite;
        nameText.text = name;
        typeText.text = type;
    }
}
