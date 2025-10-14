using StarterAssets;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
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
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                //UI, "Press E"
                if (_input.interact)
                {
                    interactable.Interact();
                    _input.interact = false;
                }
            }
        }
    }
}
