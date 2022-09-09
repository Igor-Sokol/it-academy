using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text displayText;

    [SerializeField]
    private Menu startMenu;

    private Menu lastMenu;

    private void Start()
    {
        this.startMenu.gameObject.SetActive(true);
        this.lastMenu = this.startMenu;
    }

    public void ChangeMenu(Menu newMenu)
    {
        this.lastMenu.gameObject.SetActive(false);

        newMenu.gameObject.SetActive(true);
        this.displayText.text = newMenu.MenuHeader;

        this.lastMenu = newMenu;
    }

    public void ChangeDisplayText(string text)
    {
        this.displayText.text = text;
    }
}
