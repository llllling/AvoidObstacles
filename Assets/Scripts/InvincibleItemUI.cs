using UnityEngine;

public class InvincibleItemUI : MonoBehaviour
{

    private InvincibleItemSpanwer spanwer;
    void Start()
    {
        spanwer = GameObject.Find("InvincibleItemSpanwer").GetComponent<InvincibleItemSpanwer>();
    }
    void OnEnable()
    {
        SoundManager.Instance.PlayInvincibleItem();
    }
    void Update()
    {
        if (GameManager.Instance.IsGameover)
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
