using UnityEngine;

public class MutantFlesh : Enemy
{
    [SerializeField] private int _healthCurrent;
    [SerializeField] private int _healthMax;

    [Space]
    [SerializeField] private float _attackRange;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    [Space]
    [SerializeField] private Health _health;
    [SerializeField] private GUIHealth _guiHealth;
    [SerializeField] private Damageable _damageable;
    [SerializeField] private EnemyDead _enemyDead;
    [SerializeField] private MutantFleshAnimator _mutantFleshAnimator;
    [SerializeField] private EnemyMovable _movable;
    [SerializeField] private DamageableDetecter _damageableDetecter;

    private bool _isAttack;
    private bool _isMove;
    private bool _isIdle;

    private float _errorRangeToPoint = 0.1f;

    private Vector2 _defaultPosition;

    public void Awake()
    {
        _health.Init(_healthCurrent, _healthMax);
        _damageable.Init(_health);
        _guiHealth.SetHealth(_health);
        _enemyDead.Init(_health);

        _mutantFleshAnimator.OnAttackAnimationEvent += OnAttack;
        _defaultPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (_isAttack)
            return;

        if (_damageableDetecter.IsEmpty)
        {
            Idle();
        }
        else
        {
            Aggressive();
        }
    }

    private void Idle ()
    {
        if (Vector2.Distance(transform.position, _defaultPosition) < _errorRangeToPoint)
        {
            if (!_isIdle)
            {
                _isIdle = true;
                _mutantFleshAnimator.PlayIdleAnimation();
            }
            
        }
        else
        {
            _movable.MoveTo(_defaultPosition, _speed, Time.deltaTime);

            if (!_isMove)
            {
                _isMove = true;
                _mutantFleshAnimator.PlayRunAnimation();
            }
        }
    }

    private void Aggressive ()
    {
        _isIdle = false;

        _movable.MoveTo(_damageableDetecter.Damageables[0].Position, _speed, Time.deltaTime);

        if(!_isMove)
        {
            _isMove = true;
            _mutantFleshAnimator.PlayRunAnimation();
        }
        else
        {
            if (Vector2.Distance(transform.position, _damageableDetecter.Damageables[0].Position) < _attackRange)
            {
                _isAttack = true;
                _isMove = false;

                _mutantFleshAnimator.PlayAttackAnimation();
            }
        }
    }

    private void OnAttack()
    {
        _isAttack = false;
        
        if (!_damageableDetecter.IsEmpty && Vector2.Distance(transform.position, _damageableDetecter.Damageables[0].Position) < _attackRange)
        {
            _damageableDetecter.Damageables[0].TakeDamage(this, _damage);
        }
    }
}
