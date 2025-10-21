using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouseTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GlobalVariableManager.Instance.gameEnd = true;
            SceneLoader.Instance.NewScene();
        }
    }
}
