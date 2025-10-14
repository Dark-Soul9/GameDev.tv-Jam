using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance;

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

    public bool isUIActive;
    public TextMeshProUGUI candyCount;
    public GameObject pickUpPrompt;
    public void UpdateCandyCount()
    {
        candyCount.text = GlobalVariableManager.Instance.candyCount.ToString();
    }

    public void Prompt(bool value)
    {
        pickUpPrompt.SetActive(value);
    }
}
