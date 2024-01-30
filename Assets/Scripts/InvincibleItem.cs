using UnityEngine;

public class InvincibleItem : Item
{
    public override void Use()
    {
        InvincibleItemSpanwer spanwer = GameObject.Find("InvincibleItemSpanwer").GetComponent<InvincibleItemSpanwer>();
        spanwer.uiImage.gameObject.SetActive(true);
        spanwer.isUsingItem = true;
        spanwer.HideAllItems();

        Player.status = PlayerStatus.INVINCIBLE;
    }
}
