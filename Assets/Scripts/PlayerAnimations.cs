using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    public FallDirectionDetector fallDirectionDetector;
    public bool deathCheck;
    
    private void Start()
    {

    }
    public void PlayDeathAnimation()
    {
        fallDirectionDetector.DetermineFallDirection();
        deathCheck = fallDirectionDetector.fallLeft;
        GameManager.Instance.PlayerDeathSequence();
        
        playerAnimator.enabled = true;
        if(deathCheck)
        {
            playerAnimator.SetTrigger("LeftDeath");
        }
        else
        {
            playerAnimator.SetTrigger("RightDeath");
        }
        
    }
}
