using UnityEngine;

public class PickupInteract : MonoBehaviour, IInteractable
{
    public int amount;
    public GlobalVariableManager globalVariableManager;
    public UIManager uiManager;
    public string interactableName;


    private void Start()
    {
        interactableName = GetComponent<InteractableType>().interactableName;
        globalVariableManager = GlobalVariableManager.Instance;
        uiManager = UIManager.Instance;
    }
    public void Interact()
    {
        globalVariableManager.candyCount += amount;
        uiManager.UpdateCandyCount();
        uiManager.InputPrompt(false, interactableName);
        Destroy(gameObject);
    }
}
