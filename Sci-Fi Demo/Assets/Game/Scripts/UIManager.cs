using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    [SerializeField] private GameObject _pickupCoinsText;
    [SerializeField] private GameObject _coinIamge;
    [SerializeField] private GameObject _shopText;
    [SerializeField] private GameObject _dontHaveCoinText;
    
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

    public void DisplayCoinImage()
    {
        _coinIamge.SetActive(true);
    }

    public void HideCoinImange()
    {
        _coinIamge.SetActive(false);
    }

    public void DisplayShopText()
    {
        _shopText.SetActive(true);
    }

    public void HideShopText()
    {
        _shopText.SetActive(false);
    }

    public void DisplayDontHaveCoinText()
    {
        _dontHaveCoinText.SetActive(true);
    }

    public void HideDontHaveCoinText()
    {
        _dontHaveCoinText.SetActive(false);
    }
}
