using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; 
    public Toggle fullscreenToggle;
    public TMP_Dropdown qualityDropdown;
    public Toggle vsyncToggle;

    private Resolution[] resolutions;

    void Start()
    {
        // Inicjalizacja jakości grafiki
        string[] qualityLevels = QualitySettings.names;
        qualityDropdown.ClearOptions();

        foreach (var level in qualityLevels)
        {
            qualityDropdown.options.Add(new TMP_Dropdown.OptionData(level));
        }

        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();

        // Inicjalizacja rozdzielczości
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        foreach (var resolution in resolutions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution.ToString()));
        }

        resolutionDropdown.value = FindCurrentResolutionIndex();
        resolutionDropdown.RefreshShownValue();

        // Inicjalizacja pozostałych opcji
        fullscreenToggle.isOn = Screen.fullScreen;
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        vsyncToggle.isOn = QualitySettings.vSyncCount > 0;
    }

    public void ApplySettings()
    {
        // Zastosowanie zmian w rozdzielczości
        Resolution selectedResolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullscreenToggle.isOn);
        QualitySettings.vSyncCount = vsyncToggle.isOn ? 1 : 0;
        // Zastosowanie zmian w jakości grafiki
        QualitySettings.SetQualityLevel(qualityDropdown.value);
    }

    private int FindCurrentResolutionIndex()
    {
        Resolution currentResolution = Screen.currentResolution;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i;
            }
        }
        return 0; // Domyślnie ustawiamy pierwszą dostępną rozdzielczość
    }
}
