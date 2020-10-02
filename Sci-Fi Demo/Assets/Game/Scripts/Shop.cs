using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private UIManager _uiManager;
    private bool _eKeyIsPressed = false;
    [SerializeField] private AudioClip _winSound;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _eKeyIsPressed = true;
            Debug.Log("E is Pressed");
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _eKeyIsPressed = false;
            Debug.Log("E is Lifted");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_eKeyIsPressed == true)
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    if (player._hasCoins == true)
                    {
                        player.DisplayWeapon();
                        if (_uiManager != null)
                        {
                            _uiManager.HideCoinImange();  
                        }
                        player._hasCoins = false;
                        player._hasWeapon = true;
                        AudioSource.PlayClipAtPoint(_winSound, Camera.main.transform.position, 1);
                    }
                    else
                    {
                        if (_uiManager != null)
                        {
                            _uiManager.HideShopText();
                            _uiManager.DisplayDontHaveCoinText();
                        }
                    
                    }
                }   
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.DisplayShopText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _uiManager.HideShopText();
            _uiManager.HideDontHaveCoinText();
        }
    }
}
