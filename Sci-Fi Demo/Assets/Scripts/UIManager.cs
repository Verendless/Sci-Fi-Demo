using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    [SerializeField] private GameObject _pickupCoinsText;
    
    public void UpdateAmmoCount(int currentAmmo)
    {
        _ammoText.text = "Ammo : " + currentAmmo;
    }

    public void DisplayPickupCoinsText()
    {
        _pickupCoinsText.SetActive(true);
    }

    public void HidePickupCoinsText()
    {
        _pickupCoinsText.SetActive(false);
    }
}
