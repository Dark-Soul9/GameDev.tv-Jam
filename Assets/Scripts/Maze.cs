using UnityEngine;

public class Maze : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        GlobalVariableManager.Instance.gameEnd = false;
        animator.SetTrigger("StartingMaze");
    }
}
