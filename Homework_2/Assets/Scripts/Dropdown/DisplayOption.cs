using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class DisplayOption : MonoBehaviour
{
    [SerializeField]
    private MenuHandler menuHandler;

    private TMP_Dropdown dropdown;

    private void Awake()
    {
        this.dropdown = GetComponent<TMP_Dropdown>();
    }

    private void OnEnable()
    {
        this.dropdown.onValueChanged.AddListener(OnChangeOption);
    }

    private void OnDisable()
    {
        this.dropdown.onValueChanged.RemoveListener(OnChangeOption);
    }

    public void OnChangeOption(int index)
    {
        this.menuHandler.ChangeDisplayText(this.dropdown.options[index].text);
    }
}
