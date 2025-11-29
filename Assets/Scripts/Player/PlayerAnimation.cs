using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] RigBuilder rigBuilder;
    private Animator _animator;
    private bool deathPlayer;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("isEnableGun", false);
    }

    public void PlayIdle()
    {
        _animator.SetBool("Idle", true);
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", false);
    }

    public void PlayWalk()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", false);
        _animator.SetBool("Walk", true);
    }

    public void PlayRun()
    {
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", true);
        _animator.SetBool("Walk", false);
    }

    public void PlayIdleGun()
    {
        _animator?.SetFloat("idleGun", 1);
        _animator.SetBool("isEnableGun", true);
    }

    public void PlayFireGun()
    {
        _animator.SetBool("IsFire", true );
    }

    public void CanceledFireGun()
    {
        _animator.SetBool("IsFire",false);
    }

    public void PlayDeathPlayer()
    {
        if (deathPlayer == true) return;
        deathPlayer = true;
        rigBuilder.enabled = false;
        _animator.SetLayerWeight(1, 0f);
        _animator.SetTrigger("Death");
    }
}
