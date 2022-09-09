using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnableButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        this.button = this.GetComponent<Button>();
    }

    private void OnEnable()
    {
        this.button.interactable = true;
    }
}
