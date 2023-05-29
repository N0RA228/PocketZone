using System;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamageEvent;

    
    private IHealth _health;

    public Vector3 Position => transform.position;


    public void Init (IHealth health)
    {
        _health = health;
    }

    public void TakeDamage(object sender, int damage)
    {
        _health.DeleteHealth(sender, damage);

        OnTakeDamageEvent?.Invoke();
    }
}
