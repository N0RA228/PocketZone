using ItemSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public class InventoryData
    {
        public List<InventorySlotData> SlotsData;
        public int MaxSlots;

        public InventoryData(List<InventorySlot> slots, int maxSlots)
        {
            SlotsData = new List<InventorySlotData>();
            foreach (var slot in slots)
            {
                SlotsData.Add(slot.GetSlotData());
            }

            MaxSlots = maxSlots;
        }

        public InventoryData(int maxSlots = -1)
        {
            SlotsData = new List<InventorySlotData>();
            MaxSlots = maxSlots;
        }

        public List<InventorySlot> GetSlots (ItemDataBase itemDataBase)
        {
            List<InventorySlot> slots = new List<InventorySlot>();

            foreach (var slotData in SlotsData) 
            {
                Item item = itemDataBase.GetItem(slotData.ItemID);
                
                if(item != null)
                {
                    InventorySlot slot = new InventorySlot(item, slotData.Amount);
                    slots.Add(slot);
                }
                else
                {
                    Debug.LogWarning("Item not found");
                }
            }

            return slots;
        }
    }
}