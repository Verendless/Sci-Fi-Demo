using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _pickupCoinKey = false;
    private UIManager _uiManager;
    [SerializeField] private AudioClip _pickupCoinSound;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _pickupCoinKey = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _pickupCoinKey == true)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.UpdateCoin();
                _uiManager.HidePickupCoinsText();
                AudioSource.PlayClipAtPoint(_pickupCoinSound, transform.position, 1.0f);
                Destroy(this.gameObject);                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.DisplayPickupCoinsText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.HidePickupCoinsText();
        }
    }
}
