using ItemSystem;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] private List<ItemConfig> _dropItems;
    [SerializeField] private ItemMono _prefabItem;
    [SerializeField] private float _rangeDrop;

    [Space]
    [SerializeField] private Enemy _enemy;
    
    private IHealth _health;

    public void Init (IHealth health)
    {
        _health = health;

        _health.OnDeadEvent += OnDead;
    }

    private void OnDead(object sender)
    {
        for (int i = 0; i < _dropItems.Count; i++)
        {
            Vector2 spawnPoint = new Vector2(Random.Range(transform.position.x - _rangeDrop, transform.position.x + _rangeDrop), Random.Range(transform.position.y - _rangeDrop, transform.position.y + _rangeDrop));

            ItemMono itemMono = Instantiate(_prefabItem, spawnPoint, Quaternion.identity);
            itemMono.SetItem(_dropItems[i]);
        }

        _enemy.DeadInvoke();

        Destroy(gameObject);
    }
}
