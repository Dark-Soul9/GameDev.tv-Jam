using UnityEngine;

public class PickupInteract : MonoBehaviour, IInteractable
{
    public int amount;
    public GlobalVariableManager globalVariableManager;
    public UIManager uiManager;

    private void Start()
    {
        globalVariableManager = GlobalVariableManager.Instance;
        uiManager = UIManager.Instance;
    }
    public void Interact()
    {
        globalVariableManager.candyCount += amount;
        uiManager.UpdateCandyCount();
        uiManager.Prompt(false);
        Destroy(gameObject);
    }
}
