using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed;
    public float roamSpeed;
    public float despawnRange;
    public Transform player;
    public AudioSource enemyAudio;
    public enum EnemyStates
    {
        Roaming, Chasing, Caught
    }

    public EnemyStates currentState;

    private void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        switch(currentState)
        {
            case EnemyStates.Roaming:
                GetPlayerPosition();
                Vector3 oppositeDirection = (transform.position - player.position).normalized;
                transform.position += oppositeDirection * roamSpeed * Time.deltaTime;
                enemyAudio.Stop();
                if (Vector3.Distance(player.position, transform.position) > despawnRange)
                {
                    Destroy(gameObject);
                }
                break;
            case EnemyStates.Chasing:
                GetPlayerPosition();
                float stepChase = chaseSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.position, stepChase);
                if(!enemyAudio.isPlaying)
                {
                    enemyAudio.Play();
                }
                if (Vector3.Distance(transform.position, player.position) < 0.1f)
                {
                    currentState = EnemyStates.Caught;
                }
                break;
            case EnemyStates.Caught:
                enemyAudio.Stop();
                break;
        }
    }

    private void GetPlayerPosition()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
