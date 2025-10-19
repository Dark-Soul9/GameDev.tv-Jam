using UnityEngine;

public class PickupInteract : MonoBehaviour, IInteractable
{
    public int amount;
    public GlobalVariableManager globalVariableManager;
    public UIManager uiManager;
    public InteractableType interactable;
    public string interactableName;


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
        globalVariableManager.candyCount += amount;
        uiManager.UpdateCandyCount();
        uiManager.InputPrompt(false, interactableName);
        Destroy(gameObject);
    }
}
