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
    public Animator animator;

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
        animator.SetTrigger("MazeDoor");
        SoundManager.Instance.PlayOneShot(GetComponent<AudioSource>(), interactable.interactableSound);
        uiManager.InputPrompt(false, interactableName);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log($"Interacted with: {gameObject.name}");
        //Cutscene Start
    }
}
