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

    public void NewScene()
    {
        GlobalVariableManager.Instance.SetSaveData();
        animator.SetTrigger("LoadOut");
        StartCoroutine(LoadDelay(sceneToLoad,loadDelay));
    }
    public void ContinueScene(int sceneIndex)
    {
        GlobalVariableManager.Instance.SetSaveData();
        animator.SetTrigger("LoadOut");
        StartCoroutine(LoadDelay(sceneIndex, loadDelay));
    }
    IEnumerator LoadDelay(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneToLoad);
    }
}
