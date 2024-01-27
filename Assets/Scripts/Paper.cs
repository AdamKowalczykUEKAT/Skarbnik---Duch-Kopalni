using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public string paperText = "Domyślny tekst";
    public TextMeshProUGUI text;
    public GameObject notatkaPanel; // Referencja do panelu pauzy w Unity
    public GameObject kursor;
    // Referencja do kursora w Unity
    public FirstPersonLook kontrolaMyszySkrypt; // Referencja do skryptu poruszania w Unity
    private bool isPauza = false; // Flaga wskazująca, czy gra jest w trybie pauzy
    public Button zamknijButton;

    private void Start()
    {
        text.text = ""; // Wyczyść tekst na początku
        zamknijButton.onClick.AddListener(ZamknijNotatke);
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
            text.text = "";
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
            text.text = paperText;
            Debug.Log(text);
        }

        
    }

    void ZamknijNotatke()
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

    // Metoda do aktywowania pauzy
    void AktywujPauze()
    {
        Time.timeScale = 0f; // Zatrzymaj czas w grze
        notatkaPanel.SetActive(true); // Aktywuj panel pauzy
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
        notatkaPanel.SetActive(false); // Dezaktywuj panel pauzy
        kursor.SetActive(false); // Dezaktywuj kursor
        isPauza = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        kontrolaMyszySkrypt.ruchMyszyAktywny = true;
    }

 
}
