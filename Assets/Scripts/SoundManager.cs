using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [HideInInspector]
    public bool isMute = false;

    public AudioClip button;
    public AudioClip die;
    public AudioClip addScore;
    public AudioClip obstacleWhenInvincible;
    public AudioClip invincibleItem;
    [HideInInspector]
    public AudioSource audioSource;

    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();

                if (instance == null)
                {
                    GameObject managerObject = new("SoundManager");
                    instance = managerObject.AddComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        } else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        audioSource.Play();
    }

    public void Mute(bool isMute)
    {
        audioSource.mute = isMute;

    }

    public void ReplayBGM()
    {
        audioSource.Stop();
        audioSource.Play();
    }
    public void PlayObstacleWhenInvincible()
    {
        audioSource.PlayOneShot(obstacleWhenInvincible);
    }
    public void PlayAddScore() {
        audioSource.PlayOneShot(addScore);
    }
    public void PlayDie()
    {
        audioSource.PlayOneShot(die);
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(button);
    }

    public void PlayInvincibleItem()
    {
        audioSource.PlayOneShot(invincibleItem);
    }
}
