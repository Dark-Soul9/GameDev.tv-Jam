using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Hoverable3D : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent onClickEvent;
    public MeshRenderer highlightMesh;
    public void OnHoverEnter()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        highlightMesh.enabled = true;
    }

    public void OnHoverExit()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        highlightMesh.enabled = false;
    }

    public void OnClick()
    {
        onClickEvent?.Invoke();
        // add any custom behavior here
    }
}
