using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Przypisz Audio Mixer z Unity Inspector

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider ambienceSlider;
    public Slider sfxSlider;

    private void Start()
    {
        // Inicjalizacja wartości sliderów na podstawie aktualnych ustawień Audio Mixer
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", GetMixerVolume("MasterVolume"));
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", GetMixerVolume("MusicVolume"));
        ambienceSlider.value = PlayerPrefs.GetFloat("AmbienceVolume", GetMixerVolume("AmbienceVolume"));
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", GetMixerVolume("SFXVolume"));
    }

    // Metoda do zmiany głośności dla danego dźwięku w Audio Mixer
    public void SetMixerVolume(string parameterName, float volume)
    {
        audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(parameterName, volume);
    }

    // Metoda do pobierania aktualnej głośności dla danego dźwięku z Audio Mixer
    public float GetMixerVolume(string parameterName)
    {
        float volume;
        audioMixer.GetFloat(parameterName, out volume);
        return Mathf.Pow(10, volume / 20);
    }

    // Metody wywoływane przez slidery
    public void SetMasterVolume(float volume)
    {
        SetMixerVolume("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        SetMixerVolume("MusicVolume", volume);
    }

    public void SetAmbienceVolume(float volume)
    {
        SetMixerVolume("AmbienceVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        SetMixerVolume("SFXVolume", volume);
    }
}
