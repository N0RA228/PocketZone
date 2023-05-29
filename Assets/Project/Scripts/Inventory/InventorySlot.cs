using ItemSystem;
using System;

namespace InventorySystem
{
    public class InventorySlot
    {
        public event Action OnChangeEvent;
        public event Action OnDeleteSlotEvent;

        public Item item;
        public int amount;

        public int AmountMax => item.MaxInSlot;

        public InventorySlot(Item item, int amount = 1)
        {
            this.item = item;
            this.amount = amount;
        }

        public InventorySlotData GetSlotData() => new InventorySlotData(item.ID, amount);

        public void ChangeEvetInvoke()
        {
            OnChangeEvent?.Invoke();
        }

        public void DeleteSlotEvetInvoke()
        {
            OnDeleteSlotEvent?.Invoke();
        }
    }
}