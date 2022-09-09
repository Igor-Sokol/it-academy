using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private MenuHandler menuHandler;

    public void Display()
    {
        this.menuHandler.ChangeDisplayText(this.text.text);
    }
}
