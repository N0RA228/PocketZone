using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public event Action OnDeadAllEnemyEvent;

    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Enemy _prefabEnemy;

    public List<Transform> SpawnPoints => _spawnPoints;

    private List<Enemy> _enemys;

    public void Init ()
    {
        _enemys = new List<Enemy>();
    }

    private void OnEnable()
    {
        Enemy.OnDeadEvent += OnDeadEvent;
    }

    private void OnDisable()
    {
        Enemy.OnDeadEvent -= OnDeadEvent;
    }

    public void Spawn (int count)
    {
        List<Transform> spawnPoints = new List<Transform>(_spawnPoints);

        for (int i = 0; i < count; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Enemy enemy = Create(_prefabEnemy, spawnPoint.position);
            _enemys.Add(enemy);

            spawnPoints.Remove(spawnPoint);
        }
    }

    private Enemy Create (Enemy prefab, Vector2 position)
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }

    private void OnDeadEvent(Enemy enemy)
    {
        _enemys.Remove(enemy);

        if (_enemys.Count < 1)
            OnDeadAllEnemyEvent?.Invoke();
    }
}
