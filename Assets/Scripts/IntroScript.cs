using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string fullText;
    public float typingSpeed = 0.05f;
    public float fontSizeMultiplier = 0.02f;
    public float widthMultiplier = 0.8f; 
    public float heightMultiplier = 0.8f;
    public AudioSource sound;
    public string nextSceneName;

    private void Start()
    {
        textMeshPro.fontSize = Screen.height * fontSizeMultiplier;

        RectTransform textRectTransform = textMeshPro.rectTransform;
        textRectTransform.sizeDelta = new Vector2(Screen.width * widthMultiplier, Screen.height * heightMultiplier);

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            // Ustaw tekst do aktualnej długości 'i'
            textMeshPro.text = fullText.Substring(0, i);

            // Poczekaj przez określony czas, aby uzyskać efekt animacji
            yield return new WaitForSeconds(typingSpeed);
            if (Input.GetKeyDown(KeyCode.E))
            {
                break;
            }
        }
        PlaySound(sound);

        // Poczekaj chwilę po zakończeniu animacji dźwięku, a następnie przejdź do kolejnej sceny
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextSceneName);
    }
    private void PlaySound(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
