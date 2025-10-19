using UnityEngine;
using UnityEngine.InputSystem;

public class SpotlightMouseControl : MonoBehaviour
{
    public InputActionReference mouseDeltaAction;
    public GameObject spotlight;
    public float moveSpeed = 1f;           // screen-space multiplier (pixels per unit delta)
    public float smoothTime = 0.03f;       // smoothing; set to 0 for instant
    private Vector3 velocity = Vector3.zero;

    private Camera cam;
    private Vector3 screenPos;             // spotlight's screen position (x,y) and depth (z)

    void OnEnable()
    {
        mouseDeltaAction.action.Enable();
    }

    void Start()
    {
        cam = Camera.main;
        // initialize screenPos using current world pos
        screenPos = cam.WorldToScreenPoint(spotlight.transform.position);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // read raw mouse delta
        Vector2 mouseDelta = mouseDeltaAction.action.ReadValue<Vector2>();

        // apply delta in screen space (note: multiply by moveSpeed)
        screenPos += new Vector3(-mouseDelta.x * moveSpeed, -mouseDelta.y * moveSpeed, 0f);

        // clamp to screen bounds (0..width, 0..height)
        screenPos.x = Mathf.Clamp(screenPos.x, 0f, Screen.width);
        screenPos.y = Mathf.Clamp(screenPos.y, 0f, Screen.height);

        // Convert back to world using the same depth (z)
        Vector3 targetWorld = cam.ScreenToWorldPoint(screenPos);

        // optional smoothing so it doesn't snap
        if (smoothTime > 0f)
        {
            spotlight.transform.position = Vector3.SmoothDamp(spotlight.transform.position, targetWorld, ref velocity, smoothTime);
        }
        else
        {
            spotlight.transform.position = targetWorld;
        }
    }
}
