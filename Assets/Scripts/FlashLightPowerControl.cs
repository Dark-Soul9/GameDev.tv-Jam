using UnityEngine;
using System.Collections;

public class FlashLightPowerControl : MonoBehaviour
{
    public Light flashlight;             // Your Spot light
    public float fadeOutTime = 1.5f;     // Time to fully fade off
    private float originalIntensity;     // To restore full power
    private bool isFading = false;       // Lock toggle while fading
    private bool isOn = true;            // Flashlight state

    void Start()
    {
        originalIntensity = flashlight.intensity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isFading) // Change key if needed
        {
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        if (isOn)
        {
            // TURN OFF,  Fade Out
            StartCoroutine(FadeOff());
        }
        else
        {
            // TURN ON,  Restore instantly
            flashlight.gameObject.SetActive(true);
            flashlight.intensity = originalIntensity;
            isOn = true;
        }
    }

    IEnumerator FadeOff()
    {
        isFading = true;
        float startIntensity = flashlight.intensity;
        float t = 0f;

        while (t < fadeOutTime)
        {
            t += Time.deltaTime;
            flashlight.intensity = Mathf.Lerp(startIntensity, 0f, t / fadeOutTime);
            yield return null;
        }

        flashlight.intensity = 0f;
        flashlight.gameObject.SetActive(false); // Optional: disable for performance
        isOn = false;
        isFading = false;
    }
}
