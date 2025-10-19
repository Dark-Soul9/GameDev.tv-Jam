using UnityEngine;

public class OutofBounds : MonoBehaviour, IInteractable
{
    public UIManager uiManager;
    public InteractableType interactable;
    public string interactableName;

    private void Start()
    {
        interactable = GetComponent<InteractableType>();
        interactableName = interactable.name;
        uiManager = UIManager.Instance;
        
    }
    public void Interact()
    {

    }
}
