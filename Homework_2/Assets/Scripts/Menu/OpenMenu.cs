using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenMenu : MonoBehaviour
{
    [SerializeField]
    private Menu openMenu;

    [SerializeField]
    private MenuHandler menuHandler;

    private Button button;

    private void Awake()
    {
        this.button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.button.onClick.AddListener(OnEnableMenu);
    }

    private void OnDisable()
    {
        this.button.onClick.RemoveListener(OnEnableMenu);
    }

    private void OnEnableMenu()
    {
        this.menuHandler.ChangeMenu(this.openMenu);
    }
}
