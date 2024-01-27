using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauza : MonoBehaviour
{
    public GameObject pauzaPanel; // Referencja do panelu pauzy w Unity
    public GameObject kursor;
    // Referencja do kursora w Unity
    public FirstPersonLook kontrolaMyszySkrypt; // Referencja do skryptu poruszania w Unity
    private bool isPauza = false; // Flaga wskazująca, czy gra jest w trybie pauzy

    void Update()
    {
        // Sprawdzanie naciśnięcia klawisza pauzy (np. Escape)
        if (Input.GetKeyDown(KeyCode.Tab))
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
    }

    // Metoda do aktywowania pauzy
    void AktywujPauze()
    {
        Time.timeScale = 0f; // Zatrzymaj czas w grze
        pauzaPanel.SetActive(true); // Aktywuj panel pauzy
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
        pauzaPanel.SetActive(false); // Dezaktywuj panel pauzy
        kursor.SetActive(false); // Dezaktywuj kursor
        isPauza = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        kontrolaMyszySkrypt.ruchMyszyAktywny = true;
    }

    // Metoda do zapisu gry
    public void ZapiszGre()
    {
        // Tutaj możesz umieścić kod do zapisu stanu gry
        Debug.Log("Gra zapisana!");
    }

    // Metoda do powrotu do menu głównego
    public void WrocDoMenuGlownego()
    {
        Time.timeScale = 1f; // Wznów czas w grze
        SceneManager.LoadScene("MainMenu"); // Załaduj scenę menu głównego
    }

    // Metoda do zamknięcia gry
    public void ZamknijGre()
    {
        Application.Quit(); // Zamknij aplikację (działa tylko w buildzie, nie w edytorze Unity)
    }
}
