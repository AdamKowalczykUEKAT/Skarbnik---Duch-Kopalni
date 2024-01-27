using UnityEngine;
using UnityEngine.SceneManagement;

public class NieNiszczObiektuNaSettings : MonoBehaviour
{
    public GameObject audioMusic;

    void Start()
    {
        // Sprawdź, czy już istnieje obiekt z tym skryptem
        NieNiszczObiektuNaSettings[] obiektyNaSettings = FindObjectsOfType<NieNiszczObiektuNaSettings>();
        if (obiektyNaSettings.Length > 1)
        {
            // Jeśli już istnieje, zniszcz ten obiekt
            Destroy(gameObject);
        }
        else
        {
            // W przeciwnym razie, oznacz obiekt do nieusuwalności
            DontDestroyOnLoad(audioMusic);
        }
    }

    private void Update()
    {
        // Sprawdź nazwę bieżącej sceny
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Gra")
        {
            // Jeśli jesteśmy na scenie "Gra", zniszcz obiekt
            Destroy(audioMusic);
        }
    }
}
