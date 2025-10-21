using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float chaseSpeed;
    public float roamSpeed;
    public float despawnRange;
    public Transform player;
    public AudioSource enemyAudio;
    public AudioSource enemyMouth;
    public AudioClip enemyScreech;
    public AudioClip enemySteps;
    public AudioClip chaseMusic;
    public AudioClip roamMusic;

    public enum EnemyStates
    {
        Waiting, Roaming, Chasing, Caught
    }

    public EnemyStates currentState;
    private EnemyStates lastState;

    private void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if(GlobalVariableManager.Instance.gameEnd)
        {
            Destroy(gameObject);
        }
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayOneShot(enemyMouth, enemyScreech);
        SoundManager.Instance.FeedAudioSources(enemyMouth, enemyAudio);
    }

    private void Update()
    {
        if (currentState != lastState)
        {
            HandleStateAudio();   // Trigger audio only when state changes
            lastState = currentState;
        }
        if(GameManager.Instance.isGamePaused)
        {
            SoundManager.Instance.StopLoop(enemyMouth);
            SoundManager.Instance.StopLoop(enemyAudio);
        }
        switch (currentState)
        {
            case EnemyStates.Waiting:
                break;
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

    void HandleStateAudio()
    {
        switch (currentState)
        {
            case EnemyStates.Waiting:
                //SoundManager.Instance.StopMusic();
                //SoundManager.Instance.PlayOneShot(enemyAudio, enemyScreech);
                break;

            case EnemyStates.Roaming:
                SoundManager.Instance.PlayMusic(roamMusic);
                SoundManager.Instance.StopLoop(enemyAudio); // No footsteps while roaming
                break;

            case EnemyStates.Chasing:
                SoundManager.Instance.PlayMusic(chaseMusic);
                SoundManager.Instance.PlayLoop(enemyAudio, enemySteps);
                break;

            case EnemyStates.Caught:
                SoundManager.Instance.StopMusic();
                SoundManager.Instance.StopLoop(enemyAudio);
                break;
        }
    }

    private void GetPlayerPosition()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerAnimations>().PlayDeathAnimation();
            GameManager.Instance.DestroyEnemy(gameObject);
        }
    }
    private void OnDestroy()
    {
        SoundManager.Instance.StopMusic();
    }
}
