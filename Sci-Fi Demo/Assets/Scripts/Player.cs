using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed = 3.0f;   
    private float _gravity = 9.81f;
    
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private GameObject _hitMarkerPrefab;
    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isReload = false;
    public bool _hasCoins = false;

    private AudioSource _audioSource;

    private UIManager _uiManager;
    
    


    // Start is called before the first frame update
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        if(_characterController == null)
        {
            Debug.LogError("Character Controller is Null");
        }

        _audioSource = GetComponentInChildren<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is Null");
        }

        _currentAmmo = _maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("UIManager is Null");
        }
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        
        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _isReload == false)
        {
            Shoot();
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && _currentAmmo != _maxAmmo && _isReload == false)
        {
            StartCoroutine(ReloadRoutine());
        }
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        _muzzleFlash.SetActive(true);
        
        _currentAmmo--;
        _uiManager.UpdateAmmoCount(_currentAmmo);
        
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        
        if (Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            Debug.Log("Hit: " + hit.transform.name);
            GameObject hitMarkers = Instantiate(_hitMarkerPrefab, hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
            Destroy(hitMarkers, 1.0f);
        }    
    }
    
    public void UpdateCoin()
    {
        _hasCoins = true;
    }

    IEnumerator ReloadRoutine()
    {
        _isReload = true;
        yield return new WaitForSeconds(1f);
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmoCount(_currentAmmo);
        _isReload = false;
    }


}
