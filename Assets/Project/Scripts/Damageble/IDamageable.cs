
using System;
using UnityEngine;

public interface IDamageable
{
    event Action OnTakeDamageEvent;

    Vector3 Position { get; }

    public void TakeDamage(object sender, int damage);
}
