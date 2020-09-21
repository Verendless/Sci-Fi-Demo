using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    
    public void UpdateAmmoCount(int currentAmmo)
    {
        _ammoText.text = "Ammo : " + currentAmmo;
    }
}
