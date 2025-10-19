using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    #region Singleton
    public static CutsceneManager Instance;

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

    PlayerManager playerManager;
    private void Start()
    {
        //playerManager = GameObject.Find("PlayerCapsule").GetComponent<PlayerManager>();
    }
    public void StartCutscene(Cutscene cutscene)
    {
        cutscene.GetComponent<Animator>().enabled = true;
        //playerManager.AtCutsceneStart();
    }
    public void EndCutscene()
    {
        playerManager.AtCutsceneEnd();
    }
}
