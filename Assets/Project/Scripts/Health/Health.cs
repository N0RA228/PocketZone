using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public event OnChangeHealth OnChangeHealthEvent;
    public event OnDead OnDeadEvent;

    private int _maxValue;
    private int _value;
    private bool _isDead;


    public int MaxValue => _maxValue;
    public int Value => _value;

    public bool IsDead => _isDead;


    public void Init (int value, int maxValue)
    {
        _value = value;
        _maxValue = maxValue;
        _isDead = false;
    }

    public void AddHealth(object sender, int add)
    {
        if (add < 0)
        {
            Debug.LogError($"Added health < 0!");
            return;
        }

        _value += add;

        if(_value > _maxValue)
            _value = _maxValue;
        
        OnChangeHealthEvent?.Invoke(sender);
    }

    public void DeleteHealth(object sender, int delete)
    {
        if (delete < 0)
        {
            Debug.LogError($"Deleted health < 0!");
            return;
        }

        _value -= delete;

        if (_value < 0)
            _value = 0;

        OnChangeHealthEvent?.Invoke(sender);

        if(_value <= 0)
        {
            _isDead = true;
            OnDeadEvent?.Invoke(sender);
        }
    }

    public void Kill(object sender)
    {
        DeleteHealth(sender, MaxValue);
    }
}
