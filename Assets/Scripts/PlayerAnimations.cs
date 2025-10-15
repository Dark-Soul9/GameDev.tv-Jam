using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator flashLightAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    public void PlayDeathAnimation()
    {
        GameManager.Instance.PlayerDeathSequence();
        playerAnimator.SetTrigger("PlayerDeath");
    }
}
