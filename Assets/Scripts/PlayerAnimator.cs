using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private Player player;
    private Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsWalking",player.IsWalking());

    }
}
