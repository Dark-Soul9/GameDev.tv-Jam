using UnityEngine;

public class FlashLightAnimations : MonoBehaviour
{
    public Animator animator;
    public Transform flashLightHolder;
    public GameObject flashLight;
    public float yOffset = 2;

    public void FlickerAnimation()
    {
        animator.enabled = true;
        flashLight.transform.SetParent(flashLightHolder);
        flashLight.transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);
        animator.SetTrigger("Flicker");
    }
}
