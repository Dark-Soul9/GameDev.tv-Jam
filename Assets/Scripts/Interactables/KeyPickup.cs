using UnityEngine;

public class KeyPickup : MonoBehaviour, IInteractable
{
    public GlobalVariableManager globalVariableManager;
    public UIManager uiManager;
    public InteractableType interactable;
    public string interactableName;
    public string hasFoundDoor;
    public string hasNotFoundDoor;
    public string dialogueToShow;

    private void Start()
    {
        interactable = GetComponent<InteractableType>();
        interactableName = interactable.name;
        globalVariableManager = GlobalVariableManager.Instance;
        uiManager = UIManager.Instance;
    }
    public void Interact()
    {
        SoundManager.Instance.PlayOneShot(interactable.interactableSound);
        globalVariableManager.hasKey = true;
        uiManager.InputPrompt(false, interactableName);
        if(globalVariableManager.foundDoor)
        {
            dialogueToShow = hasFoundDoor;
        }
        else
        {
            dialogueToShow = hasNotFoundDoor;
        }
        uiManager.ShowPlayerDialogue(dialogueToShow);
        Destroy(gameObject);
    }
}
