using ItemSystem;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour, IShot, IProjectilePool
{
    [SerializeField] private int _damage;
    [SerializeField] private ItemConfig _itemForShot;

    [Space]
    [SerializeField] private Player _player;
    [SerializeField] private Projectile _prefabProjectile;
    [SerializeField] private PlayerMovable _playerMovable;
    [SerializeField] private DamageableDetecter _enemyDetecter;

    private List<Projectile> _poolProjectiles;

    public void Init ()
    {
        _poolProjectiles = new List<Projectile>();
    }

    public void InPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.transform.position = transform.position;
        _poolProjectiles.Add(projectile);
    }

    public void Shot()
    {
        if (_enemyDetecter.IsEmpty)
            return;

        if (!_player.Inventory.Delete(_itemForShot.GetItem()))
            return;

        _enemyDetecter.Damageables[0].TakeDamage(this, _damage);


        /*
        Projectile projectile = null;

        if(_poolProjectiles.Count < 1)
        {
            projectile = Instantiate(_prefabProjectile);
        }
        else
        {
            projectile = _poolProjectiles[_poolProjectiles.Count - 1];
            _poolProjectiles.RemoveAt(_poolProjectiles.Count - 1);
        }

        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);

        projectile.Init(_playerMovable.Direction.normalized, _damage, this);
        */
    }
}
