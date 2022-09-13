using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ColorChanger : MonoBehaviour
{
    private Button button;
    private Color color;

    [SerializeField] private ShipChanger shipChanger;

    private void Awake()
    {
        this.button = this.GetComponent<Button>();
        this.color = this.GetComponent<Image>().color;
    }

    private void OnEnable()
    {
        this.button.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        this.button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        shipChanger.CurrentShip.ChangeColor(this.color);
    }
}
