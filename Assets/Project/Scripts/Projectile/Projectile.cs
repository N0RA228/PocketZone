using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _timeFly;
    [SerializeField] private float _speed;

    private int _damage;
    private Vector2 _disrection;

    private float _currentTimeFly;

    private IProjectilePool _projectilePool;

    public Projectile Insta { get; internal set; }

    public void Init(Vector2 disrection, int damage, IProjectilePool projectilePool = null)
    {
        _damage = damage;
        _disrection = disrection;
        _projectilePool = projectilePool;
        _currentTimeFly = _timeFly;
    }

    private void FixedUpdate()
    {
        transform.Translate(_disrection * _speed * Time.fixedDeltaTime);

        _currentTimeFly -= Time.fixedDeltaTime;

        if (_currentTimeFly <= 0)
            Destroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(this, _damage);
        }

        Destroy();
    }

    public void Destroy ()
    {
        if(_projectilePool != null)
        {
            _projectilePool.InPool(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
