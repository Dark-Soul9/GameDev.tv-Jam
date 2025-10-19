using UnityEngine;

public class MazeDoor : MonoBehaviour, IInteractable
{
    public GlobalVariableManager globalVariableManager;
    public UIManager uiManager;
    public InteractableType interactable;
    public string interactableName;
    public string hasFoundKey;
    public string hasNotFoundKey;
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
        globalVariableManager.foundDoor = true;
        if(!globalVariableManager.hasKey)
        {
            dialogueToShow = hasNotFoundKey;
            uiManager.ShowPlayerDialogue(dialogueToShow);
            return;
        }
        uiManager.InputPrompt(false, interactableName);
        //Cutscene Start
    }
}
