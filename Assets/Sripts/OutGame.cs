using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
