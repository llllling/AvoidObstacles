using UnityEngine;
public enum PlayerStatus
{
    NONE,
    INVINCIBLE
}
public class Player : MonoBehaviour
{
    [HideInInspector]
    public static PlayerStatus status = PlayerStatus.NONE;
    [HideInInspector]
    public static string playerTag;
    void Start()
    {
        playerTag = gameObject.tag;
    }
}
