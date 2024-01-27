using UnityEngine;

public class DarknessDetector : MonoBehaviour
{
    public float darknessThreshold = 0f; // Wartość progowa określająca, kiedy jest ciemno

    void Update()
    {
        if (IsInDarkness())
        {
            // Gracz jest w ciemnościach
            //Debug.Log("Jesteś w ciemnościach!");
        }
        else
        {
            // Gracz jest w świetle
            //Debug.Log("Jesteś w świetle!");
        }
    }

    public bool IsInDarkness()
    {
        // Pobierz informacje o oświetleniu w miejscu gracza
        float lightLevel = CalculateLightLevel();
        //Debug.Log(CalculateLightLevel());

        // Sprawdź, czy oświetlenie jest poniżej wartości progowej
        return lightLevel < darknessThreshold;
    }

    float CalculateLightLevel()
    {
        // Pobierz kolor oświetlenia w miejscu gracza
        Color lightColor = RenderSettings.ambientLight;
        //Debug.Log(lightColor);

        // Oblicz jasność oświetlenia (wartość średnia koloru)
        float lightLevel = (lightColor.r + lightColor.g + lightColor.b) / 3f;

        return lightLevel;
    }
}
