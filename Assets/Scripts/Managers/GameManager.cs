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

    public PlayerManager playerManager;

    public bool isGameStarted;
    public bool isGamePaused;

    private void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }
    public void StartingArea()
    {
        //communicate with global variable manager and update it
        //load the home scene
    }
    public void MazeArea()
    {
        //load the maze scene
    }

    public void PlayerDeathSequence()
    {
        playerManager.playerMovement.enabled = false;
        playerManager.playerFlashlight.enabled = false;
        playerManager.playerInteraction.enabled = false;
        playerManager.playerStats.enabled = false;
        //Stop enemy AI
        //Stop enemy Sounds
    }
}
