using UnityEngine;

public class Lantern : MonoBehaviour
{
    private bool isPlayerInRangeLantern = false;
    private bool isShining = false;
    public Light lanternLight;
    public ParticleSystem ParticleSystem;

    Stats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    void Update()
    {
       //Sprawdź, czy naciśnięto przycisk "E"
        if (isPlayerInRangeLantern && Input.GetKeyDown(KeyCode.E))
        {
            if (isShining)
            {
                DeactivateLightAndParticleSystem();
            }
            else if (HasEnoughFuel())
            {
                Stats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
                playerStats.currentFuel -= playerStats.fuelAdds;
                ActivateLightAndParticleSystem();
            }

            isShining = !isShining;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Sprawdź, czy obiekt zderzający się posiada tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jesteś kolo latarni");
            isPlayerInRangeLantern = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Nie jesteś koło latarni");
            isPlayerInRangeLantern = false;
        }
    }

    void ActivateLightAndParticleSystem()
    {
        // Wykryj światło punktowe na tym obiekcie
        if (lanternLight != null)
        {
            lanternLight.enabled = true;
        }

        // Wykryj ParticleSystem na tym obiekcie
        if (ParticleSystem != null)
        {
            ParticleSystem.Play();
            ParticleSystem.gameObject.SetActive(true);
        }
    }
    void DeactivateLightAndParticleSystem()
    {
        // Wykryj światło punktowe na tym obiekcie
        if (lanternLight != null)
        {
            lanternLight.enabled = false;
        }

        // Wykryj ParticleSystem na tym obiekcie
        if (ParticleSystem != null)
        {
            ParticleSystem.Stop();
            ParticleSystem.gameObject.SetActive(false);
        }
    }
    bool HasEnoughFuel()
    {
        Stats playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        // Sprawdź, czy skrypt został znaleziony i czy mamy wystarczającą ilość paliwa
        return playerStats != null && playerStats.currentFuel >= 20f;
    }
}
