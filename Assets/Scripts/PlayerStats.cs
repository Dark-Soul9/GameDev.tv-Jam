using StarterAssets;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float sanity = 100f;
    public float maxSanity = 100f;
    public float minSanity = 0f;
    
    public float increaseRate = 10f;
    public float increaseInterval;
    public float increaseTime;
    
    public float decreaseRate = 0.5f;
    public float decreaseInterval;
    public float decreaseTime;

    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }
    private void Update()
    {
        if(sanity < maxSanity && GetComponent<PlayerFlashlight>().flashLightOn)
        {
            if(increaseTime > increaseInterval)
            {
                if(sanity + increaseRate > maxSanity)
                {
                    sanity += maxSanity - sanity;
                }
                else
                {
                    sanity += increaseRate;
                }
                uiManager.UpdateSanity(sanity);
                increaseTime = 0;
            }
            increaseTime += Time.deltaTime;
        }
        else if(sanity > minSanity && !GetComponent<PlayerFlashlight>().flashLightOn)
        {
            if (decreaseTime > decreaseInterval)
            {
                if(sanity - decreaseRate < minSanity)
                {
                    sanity -= sanity - minSanity;
                }
                else
                {
                    sanity -= decreaseRate;
                }
                uiManager.UpdateSanity(sanity);
                decreaseTime = 0;
            }
            decreaseTime += Time.deltaTime;
        }
    }
}
