using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

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

    public bool isGameStarted;
    public bool isGamePaused;
    public void BackToHome()
    {
        //communicate with global variable manager and update it
        //load the home scene
    }
    public void IntoTheMaze()
    {
        //load the maze scene
    }
}
