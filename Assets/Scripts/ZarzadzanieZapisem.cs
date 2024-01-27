using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DaneGry
{
    public float pozycjaX, pozycjaY, pozycjaZ;
    // Dodaj więcej zmiennych, które chcesz zapisywać
}

public class ZarzadzanieZapisem : MonoBehaviour
{
    public GameObject SystemZapisu;
    public static DaneGry daneGry = new DaneGry(); // Utwórz statyczną zmienną dla danych gry
    public static ZarzadzanieZapisem wczytaj = new ZarzadzanieZapisem();
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WczytajGre();
    }
    public void ZapiszGre()
    {
        // Zapisz potrzebne dane gry
        daneGry.pozycjaX = player.transform.position.x;
        daneGry.pozycjaY = player.transform.position.y;
        daneGry.pozycjaZ = player.transform.position.z;

        // Konwertuj obiekt do JSON
        string daneJson = JsonUtility.ToJson(daneGry);

        // Zapisz JSON w PlayerPrefs
        PlayerPrefs.SetString("DaneGry", daneJson);
        PlayerPrefs.Save();

        Debug.Log($"Gra została zapisana.{daneGry.pozycjaX}, {daneGry.pozycjaY}, {daneGry.pozycjaZ}");
    }

    public void WczytajGre()
    {
        // Odczytaj JSON z PlayerPrefs
        string daneJson = PlayerPrefs.GetString("DaneGry");

        if (!string.IsNullOrEmpty(daneJson))
        {
            // Konwertuj JSON na obiekt
            daneGry = JsonUtility.FromJson<DaneGry>(daneJson);
       
            player.transform.position = new Vector3(daneGry.pozycjaX, daneGry.pozycjaY, daneGry.pozycjaZ);
            Debug.Log("Gra została wczytana.");
        }
        else
        {
            Debug.Log("Brak danych do wczytania.");
        }
    }
}
