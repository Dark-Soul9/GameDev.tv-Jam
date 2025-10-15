using StarterAssets;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public FirstPersonController playerMovement;
    public PlayerFlashlight playerFlashlight;
    public PlayerInteraction playerInteraction;
    public PlayerStats playerStats;
    public PlayerAnimations playerAnimations;

    private void Start()
    {
        playerMovement = GetComponent<FirstPersonController>();
        playerFlashlight = GetComponent<PlayerFlashlight>();
        playerInteraction = GetComponent<PlayerInteraction>();
        playerStats = GetComponent<PlayerStats>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }
}
