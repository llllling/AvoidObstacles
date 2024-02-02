using UnityEngine;

public class SoundControll : MonoBehaviour
{
    [HideInInspector]
    public bool isSoundOn = true;
    public static SoundControll instance;

    public AudioClip button;
    public AudioClip die;
    public AudioClip addScore;
    public AudioClip obstacleWhenInvincible;
    public AudioClip invincibleItem;
    [HideInInspector]
    public AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void OnEnable()
    {
        if (audioSource == null || !audioSource.isActiveAndEnabled) return;
        audioSource.Play();
    }
    public void PlayObstacleWhenInvincible()
    {
        if (audioSource == null || !audioSource.isActiveAndEnabled) return;
        audioSource.PlayOneShot(obstacleWhenInvincible);
    }
    public void PlayAddScore() {
        if (audioSource == null || !audioSource.isActiveAndEnabled) return;
        audioSource.PlayOneShot(addScore);
    }
    public void PlayDie()
    {
        if (audioSource == null || !audioSource.isActiveAndEnabled) return;
        audioSource.PlayOneShot(die);
    }

    public void PlayButton()
    {
        if (audioSource == null || !audioSource.isActiveAndEnabled) return;
        audioSource.PlayOneShot(button);
    }

    public void PlayInvincibleItem()
    {
        if (audioSource == null || !audioSource.isActiveAndEnabled) return;
        audioSource.PlayOneShot(invincibleItem);
    }
}
