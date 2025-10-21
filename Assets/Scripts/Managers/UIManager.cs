using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider sanityCount;
    public GameObject pickUpPrompt;
    public GameObject doorPrompt;
    public GameObject outofBounds;
    public GameObject skipPrompt;
    public TextMeshProUGUI dialogue;
    public Collider currentCollider;

    public string[] dialoguesToShow;
    public string dialogueToShow;

    public GameObject mazeTutorial;
    public GameObject flashLightTutorial;
    public GameObject sanityTutorial;

    public GameObject pauseMenu;

    public void Start()
    {
        UpdateCandyCount();
    }
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
            case "OutofBounds":
                if (outofBounds.activeInHierarchy)
                    return;
                dialogueToShow = dialoguesToShow[Random.Range(0, dialoguesToShow.Length)];
                outofBounds.GetComponent<TextMeshProUGUI>().text = dialogueToShow;
                outofBounds.SetActive(value);
                break;
        }
    }
    public void ShowSkipPrompt(bool value)
    {
        skipPrompt.SetActive(value);
    }
    public void HidePrompt(Collider collider)
    {
        doorPrompt.SetActive(false);
        pickUpPrompt.SetActive(false);
        currentCollider = collider;
        Invoke("EnableCollider", 2.5f);
    }
    void EnableCollider()
    {
        currentCollider.enabled = true;
    }
    public void HidePrompt()
    {
        doorPrompt.SetActive(false);
        pickUpPrompt.SetActive(false);
        if(outofBounds!=null)
        {
            outofBounds.SetActive(false);
        }
    }

    public void ShowPlayerDialogue(string text)
    {
        dialogue.gameObject.SetActive(true);
        dialogue.text = text;
        Invoke("HidePlayerDialogue", 2.5f); 
    }
    public void HidePlayerDialogue()
    {
        dialogue.text = "";
    }
    public void UpdateSanity(float value)
    {
        sanityCount.value = value;
    }
    public void ShowFlashLightTutorial(bool value)
    {
        flashLightTutorial.SetActive(value);
    }
    public void ShowSanityTutorial(bool value)
    {
        sanityTutorial.SetActive(value);
    }    
    public void ShowMazeTutorial(bool value)
    {
        mazeTutorial.SetActive(value);
    }

    public void PauseMenu(bool value)
    {
        pauseMenu.SetActive(value);
    }
}
