using UnityEngine;

public class HauntedDoor : MonoBehaviour, IInteractable
{
    UIManager uiManager;
    public bool unlocked;
    public bool isPickupItem = false;
    public string interactableName;
    public InteractableType interactable;
    public Animator animator;


    private void Start()
    {
        interactable = GetComponent<InteractableType>();
        interactableName = interactable.interactableName;
        uiManager = UIManager.Instance;
    }
    public void Interact()
    {
        animator.SetTrigger("HauntedHouse");
        SoundManager.Instance.PlayOneShot(GetComponent<AudioSource>(), interactable.interactableSound);
        uiManager.InputPrompt(false, interactableName);
        gameObject.GetComponent<MeshCollider>().enabled = false;
        Debug.Log($"Interacted with: {gameObject.name}");
    }
}
