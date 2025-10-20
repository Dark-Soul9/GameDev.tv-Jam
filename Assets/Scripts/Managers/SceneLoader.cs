using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    #region Singleton
    public static SceneLoader Instance;

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

    public int sceneToLoad;
    public int loadDelay;
    public Animator animator;

    public void NextScene()
    {
        GlobalVariableManager.Instance.SetSaveData();
        animator.SetTrigger("LoadOut");
        StartCoroutine(LoadDelay(loadDelay));
    }
    IEnumerator LoadDelay(float delay)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneToLoad);
    }
}
