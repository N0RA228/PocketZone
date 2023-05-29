using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    [SerializeField] private Player _player;


    private IHealth _health;

    public void Init (IHealth health)
    {
        _health = health;

        _health.OnDeadEvent += OnDead;
    }

    private void OnDead(object sender)
    {
        _player.DeadInvoke();
    }
}
