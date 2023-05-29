using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageableDetecter : MonoBehaviour
{
    public event Action<IDamageable> OnDetectEnterEvent;
    public event Action<IDamageable> OnDetectExitEvent;

    private HashSet<IDamageable> _damageables;

    public List<IDamageable> Damageables => _damageables.ToList();
    public int Count => _damageables.Count;
    public bool IsEmpty => _damageables.Count < 1;


    private void Awake()
    {
        _damageables = new HashSet<IDamageable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            _damageables.Add(damageable);

            OnDetectEnterEvent?.Invoke(damageable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            _damageables.Remove(damageable);

            OnDetectExitEvent?.Invoke(damageable);
        }
    }
}
