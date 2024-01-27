using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private bool isPlayerInRangeFood = false;
    private bool isPlayerInRangeWater = false;
    private bool isPlayerInRangeFuel = false;
    private bool isPlayerInRangeLantern = false;

    GameObject lastDetectedObjectFood = null;
    GameObject lastDetectedObjectDrink = null;

    //public float timeInDarkness;

    public Slider healthSlider;
    public Slider staminaSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Slider fuelSlider;
    //public Slider PsyhicSlider;

    public float foodAdds = 20f;
    public float waterAdds = 20f;
    public float fuelAdds = 20f;

    public float maxHealth = 100f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;

    public float maxHunger = 100f;
    public float currentHunger;

    public float maxThirst = 100f;
    public float currentThirst;

    public float maxfuel = 100f;
    public float currentFuel;

    //public float psychicState;
    //public float maxPsychicState = 100f;

    public float staminaDepletionRate = 5f;
    public float hungerDepletionRate = 0.000001f;
    public float thirstDepletionRate = 0.000001f;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            DecreaseStamina(staminaDepletionRate * Time.deltaTime);
        }
        else if (currentStamina < maxStamina)
        {
            IncreaseStamina(staminaDepletionRate * Time.deltaTime);
        }
        if (currentStamina <= 0)
        {
            // Pobierz komponent FirstPersonMovement z tego samego obiektu
            FirstPersonMovement firstPersonMovement = GetComponent<FirstPersonMovement>();

            // Jeśli komponent został znaleziony, ustaw canRun na false
            if (firstPersonMovement != null)
            {
                firstPersonMovement.canRun = false;
            }
        }
        else
        {
            // Pobierz komponent FirstPersonMovement z tego samego obiektu
            FirstPersonMovement firstPersonMovement = GetComponent<FirstPersonMovement>();

            // Jeśli komponent został znaleziony, ustaw canRun na true
            if (firstPersonMovement != null)
            {
                firstPersonMovement.canRun = true;
            }
        }

        if (isPlayerInRangeFood && Input.GetKeyDown(KeyCode.E))
        {
            if (lastDetectedObjectFood != null)
            {
                currentHunger += foodAdds;
                currentHealth += foodAdds;
                Destroy(lastDetectedObjectFood);
                lastDetectedObjectFood = null; // Reset to null after interaction
            }
        }
        if (isPlayerInRangeWater && Input.GetKeyDown(KeyCode.E))
        {
            if (lastDetectedObjectDrink != null)
            {
                currentThirst += waterAdds;
                currentHealth += waterAdds;
                //lastDetectedObject.tag = null;
                Destroy(lastDetectedObjectDrink);
                lastDetectedObjectDrink = null; // Reset to null after interaction
            }
        }
        if (isPlayerInRangeFuel && Input.GetKeyDown(KeyCode.E))
        {
            currentFuel += fuelAdds;
        }
        if (isPlayerInRangeLantern && Input.GetKeyDown(KeyCode.E))
        {
            currentFuel -= fuelAdds;
        }
        //DarknessDetector darkness = GetComponent<DarknessDetector>();
        //if (darkness.IsInDarkness())
        //{
        //    timeInDarkness += Time.deltaTime;
        //    DecreasePsyhicState(timeInDarkness);
        //}
        //else
        //{
        //    InscresePsyhicState(timeInDarkness);
        //}
        // Depleting hunger and thirst over time
        DecreaseHunger((hungerDepletionRate * Time.deltaTime)/10);
        DecreaseThirst((thirstDepletionRate * Time.deltaTime)/10);

        UpdateHealth();
        UpdateSliders();
    }
    void IncreaseStamina(float amount)
    {
        currentStamina += amount;
        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
    }
    void DecreaseStamina(float amount)
    {
        currentStamina -= amount;

        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
    }

    void DecreaseHunger(float amount)
    {
        currentHunger -= amount;
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
    }

    void DecreaseThirst(float amount)
    {
        currentThirst -= amount;
        currentThirst = Mathf.Clamp(currentThirst, 0, maxThirst);
    }
    //void DecreasePsyhicState(float amount)
    //{
    //    psychicState -= amount;
    //    psychicState = Mathf.Clamp(psychicState, 0, maxPsychicState);
    //}
    //void InscresePsyhicState(float amount)
    //{
    //    psychicState += amount;
    //    psychicState = Mathf.Clamp(psychicState, 0, maxPsychicState);
    //}
    void UpdateHealth()
    {      
        float healthMultiplier = (currentHunger + currentThirst) / (maxHunger + maxThirst);
        currentHealth = maxHealth * healthMultiplier;
 
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("DeathScene");
        }
    }
    void UpdateSliders()
    {
        // Aktualizuj wartości sliderów na podstawie bieżących statystyk gracza
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }

        if (staminaSlider != null)
        {
            staminaSlider.value = currentStamina / maxStamina;
        }

        if (hungerSlider != null)
        {
            hungerSlider.value = currentHunger / maxHunger;
        }

        if (thirstSlider != null)
        {
            thirstSlider.value = currentThirst / maxThirst;
        }
        if (fuelSlider != null)
        {
            thirstSlider.value = currentThirst / maxThirst;
        }
        //if (PsyhicSlider != null)
        //{
        //    PsyhicSlider.value = psychicState / maxPsychicState;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jedzenie"))
        {
            isPlayerInRangeFood = true;
            lastDetectedObjectFood = other.gameObject;
        }
        if (other.CompareTag("Woda"))
        {
            isPlayerInRangeWater = true;
            lastDetectedObjectDrink = other.gameObject;
        }
        if (other.CompareTag("Paliwo"))
        {
            isPlayerInRangeFuel = true;
        }
        if (other.CompareTag("Latarnia"))
        {
            isPlayerInRangeLantern = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Jedzenie"))
        {
            isPlayerInRangeFood = false;
            lastDetectedObjectFood = null;
        }
        if (other.CompareTag("Woda"))
        {
            isPlayerInRangeWater = false;
            lastDetectedObjectDrink = null;
        }
        if (other.CompareTag("Paliwo"))
        {
            isPlayerInRangeFuel = false;
        }
        if (other.CompareTag("Latarnia"))
        {
            isPlayerInRangeLantern = false;
        }
    }

   
}
