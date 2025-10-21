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
        SceneLoader.Instance.NewScene();
    }
    public void ContinueGame()
    {
        if(SaveManager.SaveExists())
        {
            SceneLoader.Instance.ContinueScene(2);
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
