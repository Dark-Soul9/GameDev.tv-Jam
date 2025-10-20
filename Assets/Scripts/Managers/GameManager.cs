using Unity.VisualScripting;
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
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        GlobalVariableManager.Instance.GetSaveData();
    }
    #endregion

    public PlayerManager playerManager;

    public bool isGameStarted;
    public bool isGamePaused;

    private void Start()
    {
        //playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        //GlobalVariableManager.Instance.GetSaveData();
    }
    public void Update()
    {
        if(GlobalVariableManager.Instance.gameEnd)
        {
            SoundManager.Instance.StopAllSounds();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
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
        SoundManager.Instance.PlayOneShot(playerManager.GetComponent<PlayerSounds>().audioSource, playerManager.GetComponent<PlayerSounds>().playerDeath);
        SoundManager.Instance.StopLoop(playerManager.GetComponent<AudioSource>());
        SoundManager.Instance.PlayOneShot(playerManager.playerFlashlight.flashLight.GetComponent<AudioSource>(), playerManager.playerFlashlight.flicker);
        playerManager.playerMovement.enabled = false;
        playerManager.playerFlashlight.enabled = false;
        playerManager.playerInteraction.enabled = false;
        playerManager.playerStats.enabled = false;
        //Stop enemy AI
        //Stop enemy Sounds
    }
    public void PlayerCutscene()
    {
        playerManager.playerMovement.enabled = false;
        playerManager.playerFlashlight.enabled = false;
        playerManager.playerInteraction.enabled = false;
        playerManager.playerStats.enabled = false;
    }
    public void PlayerCutsceneEnd()
    {
        playerManager.playerMovement.enabled = true;
        playerManager.playerFlashlight.enabled = true;
        playerManager.playerInteraction.enabled = true;
        playerManager.playerStats.enabled = true;
    }
    public void PlayerCutsceneEndOutside()
    {
        playerManager.playerMovement.enabled = true;
        playerManager.playerInteraction.enabled = true;
    }
    public void PlayerTutorial()
    {
        playerManager.playerMovement.enabled = false;
        playerManager.playerFlashlight.enabled = false;
        playerManager.playerInteraction.enabled = false;
        playerManager.playerStats.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void EndTutorial()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerManager.playerMovement.enabled = true;
        playerManager.playerFlashlight.enabled = true;
        playerManager.playerInteraction.enabled = true;
        playerManager.playerStats.enabled = true;
    }
    
    public void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
    public void PauseGame()
    {
        UIManager.Instance.PauseMenu(true);
        SoundManager.Instance.PauseAllSounds();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UIManager.Instance.PauseMenu(false);
        SoundManager.Instance.UnPauseAllSounds();
    }
}
