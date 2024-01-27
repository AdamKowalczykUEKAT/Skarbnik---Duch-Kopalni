using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kursorEnd : MonoBehaviour
{
    public GameObject kursor;
    // Referencja do kursora w Unity
    private void Start()
    {
        kursor.SetActive(true); // Aktywuj kursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    } 
}
