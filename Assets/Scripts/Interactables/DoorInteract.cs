using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    UIManager uiManager;
    public bool unlocked;
    public bool isPickupItem = false;
    public string interactableName;


    private void Start()
    {
        interactableName = GetComponent<InteractableType>().interactableName;
        uiManager = UIManager.Instance;
    }
    public void Interact()
    {
        uiManager.InputPrompt(false, interactableName);
        Debug.Log($"Interacted with: {gameObject.name}");
    }
}
