using UnityEngine;

public class InvincibleItemUI : MonoBehaviour
{

    public InvincibleItemSpanwer spanwer;
 
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
