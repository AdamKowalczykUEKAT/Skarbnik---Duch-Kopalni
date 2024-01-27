using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZarzadzanieDzwiekiemPrzycisku : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip dźwiękNajechania;
    private AudioSource audioSource;

    void Start()
    {
        // Pobierz komponent AudioSource przypisany do obiektu
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Odtwórz dźwięk, gdy kursor najedzie na przycisk
        if (dźwiękNajechania != null && audioSource != null)
        {
            audioSource.PlayOneShot(dźwiękNajechania);
        }
    }
}
