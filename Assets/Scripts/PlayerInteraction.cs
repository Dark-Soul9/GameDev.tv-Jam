using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    private Camera playerCam;

    void Start()
    {
        playerCam = Camera.main;
    }

    void Update()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                //UI, "Press E"
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
