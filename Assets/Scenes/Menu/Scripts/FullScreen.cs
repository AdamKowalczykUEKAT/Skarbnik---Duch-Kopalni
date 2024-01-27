using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    void Update()
    {
        // Pobierz komponent Image (lub RawImage) z tego samego obiektu
        Image image = GetComponent<Image>();

        // Sprawdź, czy komponent został znaleziony
        if (image != null)
        {
            // Ustaw skalowanie obrazu na wartość, która zajmie cały ekran
            image.rectTransform.sizeDelta = new Vector2(Screen.height, Screen.width);
        }
    }
}
