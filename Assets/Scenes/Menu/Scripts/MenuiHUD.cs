using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuiHUD : MonoBehaviour
{
    public GameObject HUD;
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown("h"))
        {
            HUD.SetActive(!HUD.activeSelf); 
        }
    }
}
