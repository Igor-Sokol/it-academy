using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text header;

    [SerializeField]
    private TMP_Text displayText;

    [SerializeField]
    private Menu startMenu;

    private Menu currentMenu;

    private void Start()
    {
        this.startMenu.gameObject.SetActive(true);
        this.currentMenu = this.startMenu;
    }

    public void ChangeMenu(Menu newMenu)
    {
        this.currentMenu.gameObject.SetActive(false);

        newMenu.gameObject.SetActive(true);

        this.header.text = newMenu.MenuHeader;
        this.displayText.text = newMenu.DisplayText;

        this.currentMenu = newMenu;
    }

    public void ChangeDisplayText(string text)
    {
        this.displayText.text = text;
    }
}
