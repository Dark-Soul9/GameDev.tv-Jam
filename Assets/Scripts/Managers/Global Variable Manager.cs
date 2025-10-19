using UnityEngine;

public class GlobalVariableManager : MonoBehaviour
{
    #region Singleton
    public static GlobalVariableManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
#endregion
    
    public int candyCount;
    public bool hasKey;
    public bool foundKey;
    public bool foundDoor;
}
