using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ViewChanger : MonoBehaviour
{
    private Button button;

    [SerializeField] private Transform view;
    [SerializeField] private Vector3 rotation;

    private void Awake()
    {
        this.button = this.GetComponent<Button>();
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
        this.view.rotation = Quaternion.Euler(rotation);
    }
}
