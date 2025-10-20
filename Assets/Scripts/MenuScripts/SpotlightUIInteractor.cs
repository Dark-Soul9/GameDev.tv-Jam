using UnityEngine;
using UnityEngine.InputSystem;
public class SpotlightUIInteractor : MonoBehaviour
{
    [Header("Core refs")]
    public Camera mainCamera;                // assign Camera.main in inspector if needed
    public GameObject spotlightObject;       // your spotlight GameObject (the light)
    public Canvas worldSpaceCanvas;          // the world-space canvas (GraphicRaycaster on it)

    [Header("3D Interaction")]
    public LayerMask interactable3DLayer;    // layer mask for 3D hoverables
    public float physicsRayDistance = 100f;  // ray length for 3D objects
    public float physicsSphereRadius = 0.5f; // sphere radius for ray hit area

    [Header("Input")]
    public InputActionReference clickAction; // optional: InputActionReference for click - drag left click action here

    // internal
    private HoverableUIButton currentUIHoverScript;
    private GameObject current3DHover;
    private Hoverable3D current3DHoverScript;

    void Awake()
    {
        if (mainCamera == null) mainCamera = Camera.main;
    }

    void OnEnable()
    {
        if (clickAction != null) clickAction.action.Enable();
    }

    void OnDisable()
    {
        if (clickAction != null) clickAction.action.Disable();
    }

    void Update()
    {
        if (spotlightObject == null || mainCamera == null) return;

        // 1) Convert spotlight position to screen point for UI raycast
        //Vector3 screenPoint = mainCamera.WorldToScreenPoint(spotlightObject.transform.position);

        // if spotlight behind camera, treat as off-screen (no hover)
        //if (screenPoint.z < 0)
        //{
        //    ClearUIHover();
        //    Clear3DHover();
        //    return;
        //}

        //pointerEventData.position = new Vector2(screenPoint.x, screenPoint.y);

        //// 2) GraphicRaycaster UI detection (world-space UI)
        //List<RaycastResult> results = new List<RaycastResult>();
        //raycaster.Raycast(pointerEventData, results);

        //if (results.Count > 0)
        //{
        //    // pick the top-most result
        //    GameObject hitGO = results[0].gameObject;
        //    HoverableUIButton hoverScript = hitGO.GetComponentInParent<HoverableUIButton>();

        //    if (hoverScript != null)
        //    {
        //        // switch hover if changed
        //        if (currentUIHoverScript != hoverScript)
        //        {
        //            ClearUIHover();
        //            currentUIHover = hoverScript.gameObject;
        //            currentUIHoverScript = hoverScript;
        //            currentUIHoverScript.OnHoverEnter();
        //        }

        //        // handle left click via InputSystem if given, otherwise fallback to Mouse
        //        if (IsClickPressed())
        //        {
        //            currentUIHoverScript.OnClick();
        //        }

        //        // if it's UI, don't do 3D check this frame
        //        Clear3DHover();
        //        return;
        //    }
        //}

        //// no UI hit, clear UI hover
        //ClearUIHover();

        // 3) Physics raycast from spotlight into world for 3D interactables
        Ray ray = new Ray(spotlightObject.transform.position, spotlightObject.transform.forward);
        if (Physics.SphereCast(ray, physicsSphereRadius, out RaycastHit hit, physicsRayDistance, interactable3DLayer))
        {
            GameObject hitObj = hit.collider.gameObject;
            Hoverable3D hover3D = hitObj.GetComponent<Hoverable3D>();

            if (hover3D != null)
            {
                if (current3DHoverScript != hover3D)
                {
                    Clear3DHover();
                    current3DHover = hitObj;
                    current3DHoverScript = hover3D;
                    current3DHoverScript.OnHoverEnter();
                }

                if (IsClickPressed())
                {
                    current3DHoverScript.OnClick();
                }

                return;
            }
        }

        // nothing hit
        Clear3DHover();
    }

    private bool IsClickPressed()
    {
        if (clickAction != null)
        {
            return clickAction.action.WasPressedThisFrame();
        }
        else
        {
            return Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
        }
    }

    private void Clear3DHover()
    {
        if (current3DHoverScript != null)
        {
            current3DHoverScript.OnHoverExit();
            current3DHoverScript = null;
            current3DHover = null;
        }
    }
}
