using UnityEngine;

public class InvincibleItemUI : MonoBehaviour
{
    private InvincibleItemSpanwer spanwer;
    private void Start()
    {
        spanwer = GameObject.Find("InvincibleItemSpanwer").GetComponent<InvincibleItemSpanwer>();
    }
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameover)
        {
            EndItemEffect();
        }
    }
    public void EndItemEffect()
    {
        gameObject.SetActive(false);
        spanwer.isUsingItem = false;
        Player.status = PlayerStatus.NONE;
    }
}
