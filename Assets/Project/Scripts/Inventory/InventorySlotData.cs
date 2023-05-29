using System;

namespace InventorySystem
{
    [Serializable]
    public class InventorySlotData
    {
        public string ItemID;
        public int Amount;

        public InventorySlotData(string itemID, int amount)
        {
            ItemID = itemID;
            Amount = amount;
        }
    }
}