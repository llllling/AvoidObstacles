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
    public static string playerTag = "Player";

    private Animator animator;
    void Awake()
    {
        playerTag = gameObject.tag;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance == null) return;
        if ( GameManager.instance.IsGameover)
        {
            OnAnimationDie();
            return;
        }
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
    
    public void OnAnimationDie()
    {
        animator.SetTrigger("Die");
    }
}
