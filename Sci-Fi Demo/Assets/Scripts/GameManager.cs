using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _pause = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _pause == false)
        {
            Cursor.lockState = CursorLockMode.None;
            _pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pause == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _pause = false;
        }
    }
}
