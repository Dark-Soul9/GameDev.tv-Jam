using StarterAssets;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    public LayerMask interactionLayer;
    private Camera playerCam;
    private StarterAssetsInputs _input;

    void Start()
    {
        playerCam = Camera.main;
        _input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactionLayer))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                UIManager.Instance.InputPrompt(true, hit.collider.GetComponent<InteractableType>().interactableName);
                if (_input.interact)
                {
                    _input.interact = false;
                    interactable.Interact();
                }
            }
        }
    }
}
