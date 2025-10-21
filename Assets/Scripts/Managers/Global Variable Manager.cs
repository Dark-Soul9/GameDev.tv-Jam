using UnityEngine;

public class GlobalVariableManager : MonoBehaviour
{
    #region Singleton
    public static GlobalVariableManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if(SaveManager.SaveExists())
        {
            GetSaveData();
        }
    }
    #endregion

    public bool gameEnd;
    public int candyCount;
    public bool hasKey;
    public bool foundKey;
    public bool foundDoor;
    public bool flashLightTutorial = true;
    public bool sanityTutorial = true;
    public bool mazeTutorial = true;

    public GameObject continueButton;

    public void Start()
    {
        if (continueButton != null)
        {
            continueButton.GetComponent<BoxCollider>().enabled = SaveManager.SaveExists();
        }
    }

    public void GetSaveData()
    {
        candyCount = SaveManager.LoadInt("CandyCount");
        flashLightTutorial = SaveManager.LoadBool("FlashLightTutorial");
        sanityTutorial = SaveManager.LoadBool("SanityTutorial");
        mazeTutorial = SaveManager.LoadBool("MazeTutorial");
    }
    public void SetSaveData()
    {
        SaveManager.SaveInt("CandyCount", candyCount);
        SaveManager.SaveBool("FlashLightTutorial", flashLightTutorial);
        SaveManager.SaveBool("SanityTutorial", sanityTutorial);
        SaveManager.SaveBool("MazeTutorial", mazeTutorial);
    }
    public void NewGameData()
    {
        SaveManager.SaveInt("CandyCount", 0);
        SaveManager.SaveBool("FlashLightTutorial", true);
        SaveManager.SaveBool("SanityTutorial", true);
        SaveManager.SaveBool("MazeTutorial", true);
    }
}
