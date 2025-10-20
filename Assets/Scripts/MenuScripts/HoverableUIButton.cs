using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class HoverableUIButton : MonoBehaviour
{
    [Header("UI References")]
    public Button uiButton;                 // assign the Button component (if you have one)
    public Outline uiOutline;               // optional Unity UI Outline component (assign if used)
    public GameObject alternateHighlight;   // optional: assign a child GameObject used for highlight (enable/disable)

    [Header("Events")]
    public UnityEvent onClickEvent;         // optional UnityEvent to hook in inspector

    void Reset()
    {
        uiButton = GetComponent<Button>();
        uiOutline = GetComponent<Outline>();
    }

    public void OnHoverEnter()
    {
        if (uiOutline != null) uiOutline.enabled = true;
        if (alternateHighlight != null) alternateHighlight.SetActive(true);
    }

    public void OnHoverExit()
    {
        if (uiOutline != null) uiOutline.enabled = false;
        if (alternateHighlight != null) alternateHighlight.SetActive(false);
    }

    public void OnClick()
    {
        // prefer Button.onClick if assigned
        if (uiButton != null)
        {
            uiButton.onClick.Invoke();
        }

        // additional event
        onClickEvent?.Invoke();
    }
}
