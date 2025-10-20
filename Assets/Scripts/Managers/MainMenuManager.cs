#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void NewGame()
    {
        SaveManager.StartNewGame();
        GlobalVariableManager.Instance.NewGameData();
        SceneLoader.Instance.NextScene();
    }
    public void ContinueGame()
    {
        if(SaveManager.SaveExists())
        {
            SceneLoader.Instance.NextScene();
        }
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
