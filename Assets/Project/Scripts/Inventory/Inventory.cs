using ItemSystem;
using System;
using System.Collections.Generic;

namespace InventorySystem
{
    public class Inventory
    {
        public event Action OnChangeEvent;


        private List<InventorySlot> _slots = new List<InventorySlot>();
        private int _maxSlots;


        public IEnumerable<InventorySlot> Slots => _slots.AsReadOnly();
        public int CountItemsSlots => _slots.Count;
        public int MaxSlots => _maxSlots;

        public InventoryData GetInventoryData () => new InventoryData(new List<InventorySlot>(_slots), _maxSlots);

        public Inventory(List<InventorySlot> slots, int maxSlots = -1)
        {
            _slots = slots;
            _maxSlots = maxSlots;
        }

        public Inventory(int maxSlots = -1)
        {
            _slots = new List<InventorySlot>();
            _maxSlots = maxSlots;
        }

        public bool Add(Item item, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if(!Add(item))
                    return false;
            }

            return true;
        }

        public bool Add (Item item)
        {
            foreach (InventorySlot slot in _slots)
            {
                if(slot.item.Type == item.Type)
                {
                    if(slot.AmountMax == -1 || slot.amount < slot.AmountMax)
                    {
                        slot.amount++;

                        slot.ChangeEvetInvoke();
                        OnChangeEvent?.Invoke();

                        return true;
                    }
                }
            }

            if (MaxSlots != -1 && CountItemsSlots < MaxSlots)
                return false;


            _slots.Add(new InventorySlot(item));


            OnChangeEvent?.Invoke();

            return true;
        }

        public bool Delete(Item item)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot.item.Type == item.Type)
                {
                    slot.amount--;

                    slot.ChangeEvetInvoke();

                    if (slot.amount <= 0)
                    {
                        slot.DeleteSlotEvetInvoke();
                        _slots.Remove(slot);
                    }

                    
                    OnChangeEvent?.Invoke();
                    return true;
                }
            }

            return false;
        }

        public bool Contains(Item item)
        {
            foreach (InventorySlot slot in _slots)
            {
                if (slot.item == item)
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryContains(Item item, out InventorySlot inventorySlot)
        {
            inventorySlot = null;

            foreach (InventorySlot slot in _slots)
            {
                if (slot.item.Type == item.Type)
                {
                    inventorySlot = slot;
                    return true;
                }
            }

            return false;
        }
    }
}