using UnityEngine;

public class InvincibleItemUI : MonoBehaviour
{
    public AudioClip itemSound;
    private AudioSource audioSource;

    private InvincibleItemSpanwer spanwer;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spanwer = GameObject.Find("InvincibleItemSpanwer").GetComponent<InvincibleItemSpanwer>();
    }
    void OnEnable()
    {
        audioSource.PlayOneShot(itemSound);
    }
    void Update()
    {
        if (GameManager.instance == null && GameManager.instance.IsGameover)
        {
            EndItemEffect();
            return;
        }

    }
    public void EndItemEffect()
    {
        gameObject.SetActive(false);
        spanwer.isUsingItem = false;
        Player.status = PlayerStatus.NONE;
    }

}
