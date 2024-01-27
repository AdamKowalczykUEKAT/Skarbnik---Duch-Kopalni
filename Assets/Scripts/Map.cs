using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public Texture2D mapImage;
    public RawImage rawImageDisplay;
    public GameObject mapaPanel; // Referencja do panelu mapy w Unity
    public GameObject kursor;
    // Referencja do kursora w Unity
    public FirstPersonLook kontrolaMyszySkrypt; // Referencja do skryptu poruszania w Unity
    private bool isPauza = false; // Flaga wskazująca, czy gra jest w trybie pauzy

    private void Start()
    {
        rawImageDisplay.texture = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            rawImageDisplay.texture = null;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isPauza)
                {
                    KontynuujRozgrywke();
                }
                else
                {
                    AktywujPauze();
                }
            }
            rawImageDisplay.texture = mapImage;
        }
    }

    // Metoda do aktywowania pauzy
    void AktywujPauze()
    {
        Time.timeScale = 0f; // Zatrzymaj czas w grze
        mapaPanel.SetActive(true); // Aktywuj panel pauzy
        kursor.SetActive(true); // Aktywuj kursor
        isPauza = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        kontrolaMyszySkrypt.ruchMyszyAktywny = false;
    }

    // Metoda do kontynuowania rozgrywki
    public void KontynuujRozgrywke()
    {
        Time.timeScale = 1f; // Wznów czas w grze
        mapaPanel.SetActive(false); // Dezaktywuj panel pauzy
        kursor.SetActive(false); // Dezaktywuj kursor
        isPauza = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        kontrolaMyszySkrypt.ruchMyszyAktywny = true;
    }
}