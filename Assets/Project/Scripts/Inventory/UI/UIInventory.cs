using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIInventorySlot _prefabUIInventorySlot;

    [Space]
    [SerializeField] private UIInventoryAboutItem _aboutItem;
    
    [Space]
    [SerializeField] private Transform _parentUISlots;
    [SerializeField] private Transform _inventoryPanel;

    private Inventory _inventory;

    private List<UIInventorySlot> _activeUISlots;
    private List<UIInventorySlot> _poolUISlots;

    public void SetInventory(Inventory inventory)
    {
        _inventory = inventory;

        _inventory.OnChangeEvent += OnChange;

        if (_activeUISlots == null)
            _activeUISlots = new List<UIInventorySlot>();

        if(_poolUISlots == null)
            _poolUISlots = new List<UIInventorySlot>();


        Clear();
        Display();
    }

    private void OnChange()
    {
        Clear();
        Display();
    }

    private void Display ()
    {
        foreach (var slot in _inventory.Slots)
        {
            UIInventorySlot uiInventorySlot = null;

            if (_poolUISlots.Count > 0)
            {
                uiInventorySlot = _poolUISlots[_poolUISlots.Count - 1];
                _poolUISlots.RemoveAt(_poolUISlots.Count - 1);
            }
            else
            {
                uiInventorySlot = Instantiate(_prefabUIInventorySlot, _parentUISlots);
            }

            uiInventorySlot.gameObject.SetActive(true);
            uiInventorySlot.Display(slot, this);

            _activeUISlots.Add(uiInventorySlot);
        }
    }

    private void Clear ()
    {
        while(_activeUISlots.Count > 0)
        {
            UIInventorySlot uiInventorySlot = _activeUISlots[_activeUISlots.Count - 1];
            _activeUISlots.RemoveAt(_activeUISlots.Count - 1);
            uiInventorySlot.gameObject.SetActive(false);

            _poolUISlots.Add(uiInventorySlot);
        }
    }

    public void ClickToSlot (UIInventorySlot uiInventorySlot, InventorySlot inventorySlot)
    {
        _aboutItem.Display(inventorySlot, _inventory);
    }

    public void SwichOpen ()
    {
        _inventoryPanel.gameObject.SetActive(!_inventoryPanel.gameObject.activeSelf);
    }

    public void Open()
    {
        _inventoryPanel.gameObject.SetActive(true);
    }

    public void Close ()
    {
        _inventoryPanel.gameObject.SetActive(false);
    }
}
