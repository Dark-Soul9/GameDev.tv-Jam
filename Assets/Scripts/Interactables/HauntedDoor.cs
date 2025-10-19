using UnityEngine;

public class HauntedDoor : MonoBehaviour, IInteractable
{
    UIManager uiManager;
    public bool unlocked;
    public bool isPickupItem = false;
    public string interactableName;
    public Animator animator;


    private void Start()
    {
        interactableName = GetComponent<InteractableType>().interactableName;
        animator = GetComponent<Animator>();
        uiManager = UIManager.Instance;
    }
    public void Interact()
    {
        if(animator != null)
        {
            animator.SetTrigger("Open");
        }
        uiManager.InputPrompt(false, interactableName);
        Debug.Log($"Interacted with: {gameObject.name}");
    }
}
