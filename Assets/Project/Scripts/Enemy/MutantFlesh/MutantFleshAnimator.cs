using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MutantFleshAnimator : MonoBehaviour
{
    public event Action OnAttackAnimationEvent;

    private const string ANIMATION_Idle = "MutantFlesh_IdleAnimation";
    private const string ANIMATION_RUN = "MutantFlesh_RunAnimation";
    private const string ANIMATION_Attack = "MutantFlesh_AttackAnimation";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation()
    {
        _animator.StopPlayback();
        _animator.CrossFade(ANIMATION_Idle, 0.1f);
    }

    public void PlayRunAnimation()
    {
        _animator.StopPlayback();
        _animator.CrossFade(ANIMATION_RUN, 0.1f);
    }

    public void PlayAttackAnimation()
    {
        _animator.StopPlayback();
        _animator.CrossFade(ANIMATION_Attack, 0.1f);
    }


    private void Handler_AttackAnimationEvent ()
    {
        OnAttackAnimationEvent?.Invoke();
    }
}
