using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject _createDestroyed;

    public void DestroyCrate()
    {
        Instantiate(_createDestroyed, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
