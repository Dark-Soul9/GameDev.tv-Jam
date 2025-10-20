using UnityEngine;

public class Maze : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator.SetTrigger("StartingMaze");
    }
}
