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

    private Animator animator;
    void Start()
    {
        playerTag = gameObject.tag;
        animator = GetComponent<Animator>();
    }

    public void OnAnimationWalk()
    {
        animator.SetTrigger("Walk");
    }
    public void OnAnimationLeftRight(Vector2 moveDirection)
    {
        if (moveDirection == Vector2.right)
        {
            animator.SetBool("IsLeft", false);
        }
        else if (moveDirection == Vector2.left)
        {
            animator.SetBool("IsLeft", true);
        }
    }
}
