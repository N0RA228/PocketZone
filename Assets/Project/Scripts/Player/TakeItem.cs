using ItemSystem;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ItemMono itemMono))
        {
            _player.Inventory.Add(itemMono.GetItem());
            itemMono.Destroy();
        }
    }
}
