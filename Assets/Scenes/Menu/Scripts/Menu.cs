using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public void GraStart()
    {
        PlayerPrefs.DeleteKey("DaneGry");
        // Zainicjuj nowe dane gry
        ZarzadzanieZapisem.daneGry = new DaneGry();
        SceneManager.LoadScene("Intro");
    }
    public void Continue()
    {
        SceneManager.LoadScene("Gra");
    }
    public void Opcje()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void End()
    {
        Application.Quit();
    }
}
