using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public List<Transform> spawnPositions = new List<Transform>();
    public GameObject keyPrefab;
    public List<Quaternion> spawnRotations = new List<Quaternion>();

    private void Start()
    {
        Instantiate(keyPrefab, spawnPositions[Random.Range(0, spawnPositions.Count)].position, spawnRotations[Random.Range(0, spawnRotations.Count)]);
    }
}
