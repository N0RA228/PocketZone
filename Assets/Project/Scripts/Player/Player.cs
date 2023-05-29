using InventorySystem;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action<Player> OnDeadEvent;

    [SerializeField] private ItemDataBase _itemDataBase;

    [Space]
    [SerializeField] private PlayerMovable _movable;
    [SerializeField] private PlayerWeapon _weapon;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerDead _playerDead;
    [SerializeField] private Damageable _damageable;

    private int _level;
    private Inventory _inventory;

    public Inventory Inventory => _inventory;
    public IHealth Health => _health;

    public void Init (PlayerData playerData)
    {
        _inventory = new Inventory(playerData.InventoryData.GetSlots(_itemDataBase), playerData.InventoryData.MaxSlots);
        _level = playerData.Level;

        _movable.Init();
        _weapon.Init();
        _health.Init(playerData.Health, playerData.HealthMax);
        _playerDead.Init(_health);
        _damageable.Init(_health);
    }

    public PlayerData GetPlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.Health = Health.Value;
        playerData.HealthMax = Health.MaxValue;
        playerData.Level = _level;
        playerData.InventoryData = _inventory.GetInventoryData();

        return playerData;
    }

    public void DeadInvoke ()
    {
        OnDeadEvent?.Invoke(this);
    }
}
