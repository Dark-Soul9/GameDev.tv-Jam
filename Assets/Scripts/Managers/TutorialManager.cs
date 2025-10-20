using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    #region Singleton
    public static TutorialManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    public void ShowFlashLightTutorial()
    {
        UIManager.Instance.ShowFlashLightTutorial(true);
        SaveManager.SaveBool("FlashLightTutorial", false);
        Time.timeScale = 0f;
    }
    public void HideFlashLightTutorial()
    {
        Time.timeScale = 1f;
        UIManager.Instance.ShowFlashLightTutorial(false);
    }
    public void ShowSanityTutorial()
    {
        UIManager.Instance.ShowSanityTutorial(true);
        SaveManager.SaveBool("SanityTutorial", false);
        Time.timeScale = 0f;
    }
    public void HideSanityTutorial()
    {
        GameManager.Instance.EndTutorial();
        Time.timeScale = 1f;
        UIManager.Instance.ShowSanityTutorial(false);
    }
    public void ShowMazeTutorial()
    {
        if(!GlobalVariableManager.Instance.mazeTutorial)
        {
            GameManager.Instance.EndTutorial();
            return;
        }
        GameManager.Instance.PlayerTutorial();
        UIManager.Instance.ShowMazeTutorial(true);
        SaveManager.SaveBool("MazeTutorial", false);
        Time.timeScale = 0f;
    }
    public void HideMazeTutorial()
    {
        Time.timeScale = 1f;
        UIManager.Instance.ShowMazeTutorial(false);
    }
}
