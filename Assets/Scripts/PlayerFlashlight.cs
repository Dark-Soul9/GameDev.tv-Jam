using StarterAssets;
using System.Collections;
using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    private StarterAssetsInputs _input;

    [Header("Custom Settings")]
    public GameObject flashLight;
    public EnemyManager enemyManager;
    public bool flashLightOn;

    // Flashlight Fade System
    private Light flashLightSource;
    private bool isFading = false;
    [SerializeField] private bool canUseFlashlight = true;
    private float originalIntensity;
    [SerializeField] private float fadeDuration = 1.5f; // Slow fade

    //Flashlight Audio
    public AudioClip on;
    public AudioClip off;
    public AudioClip flicker;

    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        playerStats = GetComponent<PlayerStats>();
        flashLightSource = flashLight.GetComponentInChildren<Light>();
        originalIntensity = flashLightSource.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        Flashlight();
        flashLightOn = flashLight.activeInHierarchy;
    }

    private void Flashlight()
    {
        if(_input.flashLight && isFading)
        {
            _input.flashLight = false;
        }
        if (_input.flashLight && canUseFlashlight && !isFading)
        {
            // If flashlight is already ON, Fade it OFF
            if (flashLight.activeInHierarchy)
            {
                _input.flashLight = false;
                SoundManager.Instance.PlayOneShot(flashLight.GetComponent<AudioSource>(), off);
                StartCoroutine(FadeOutFlashlight());
            }
            else
            {
                _input.flashLight = false;
                // Turn ON instantly
                flashLightOn = true;
                flashLight.SetActive(true);
                SoundManager.Instance.PlayOneShot(flashLight.GetComponent<AudioSource>(), on);
                flashLightSource.intensity = originalIntensity;
            }        
        }

        // Your enemy logic stays untouched
        if (flashLight.activeInHierarchy)
        {
            enemyManager.TrySpawnEnemy();
        }
        enemyManager.EnemyStateHandler(flashLightOn);
    }
    private IEnumerator FadeOutFlashlight()
    {
        //flashLightOn = false;
        isFading = true;
        canUseFlashlight = false;

        float startIntensity = flashLightSource.intensity;
        float time = 0f;

        while (time < fadeDuration)
        {
            flashLightOn = false;
            time += Time.deltaTime;
            float t = time / fadeDuration;
            flashLightSource.intensity = Mathf.Lerp(startIntensity, 0f, t);
            yield return null;
        }

        flashLightSource.intensity = 0f;
        flashLight.SetActive(false);

        //Lock small delay so user can't insta-toggle
        yield return new WaitForSeconds(0.2f);

        canUseFlashlight = true;
        isFading = false;
    }
}
