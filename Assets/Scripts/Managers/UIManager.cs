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
    public TextMeshProUGUI sanityCount;
    public GameObject pickUpPrompt;
    public GameObject doorPrompt;
    public void UpdateCandyCount()
    {
        candyCount.text = GlobalVariableManager.Instance.candyCount.ToString();
    }

    public void InputPrompt(bool value, string interactableName)
    {
        switch(interactableName)
        {
            case "Door":
                doorPrompt.SetActive(value);
                break;
            case "Candy":
                pickUpPrompt.SetActive(value);
                break;
        }
    }
    
    
    public void UpdateSanity(float value)
    {
        sanityCount.text = Mathf.CeilToInt(value).ToString();
    }
}
