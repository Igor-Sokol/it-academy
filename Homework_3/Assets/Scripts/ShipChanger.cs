using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipChanger : MonoBehaviour
{
    private int currentShipIndex = 0;

    [SerializeField] private Ship[] ships;

    public Ship CurrentShip { get; private set; }

    private void Awake()
    {
        this.CurrentShip = this.ships[this.currentShipIndex];
        this.CurrentShip.gameObject.SetActive(true);
    }

    public void Next()
    {
        if (this.currentShipIndex + 1 == this.ships.Length)
        {
            this.currentShipIndex = 0;
        }
        else
        {
            this.currentShipIndex++;
        }

        this.ChangeShip(this.currentShipIndex);
    }

    public void Previous()
    {
        if (this.currentShipIndex - 1 < 0)
        {
            this.currentShipIndex = this.ships.Length - 1;
        }
        else
        {
            this.currentShipIndex--;
        }

        this.ChangeShip(this.currentShipIndex);
    }

    private void ChangeShip(int index)
    {
        this.CurrentShip.gameObject.SetActive(false);

        this.CurrentShip = this.ships[index];
        this.CurrentShip.gameObject.SetActive(true);
        this.currentShipIndex = index;
    }
}
