using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string ANIMATION_Idle = "Player_IdleAnimation";
    private const string ANIMATION_RUN = "Player_RunAnimation";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        _animator.StopPlayback();
        _animator.CrossFade(ANIMATION_Idle, 0.01f);
    }

    public void PlayRunAnimation ()
    {
        _animator.StopPlayback();
        _animator.CrossFade(ANIMATION_RUN, 0.01f);
    }
}
