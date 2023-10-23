using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
   public class Slot
    {
        public CollectableTypes type;
        public int count;
        public int maxAllowed;
        public CollectableItem slottedItem;

        public Sprite icon;

        public Slot()
        {
            type = CollectableTypes.NONE;
            count = 0;
            maxAllowed = 1;
            slottedItem = null;
        }

        public void AddItem(CollectableItem item)
        {
            slottedItem = item;
            type = item.collectableType;
            icon = item.icon;
            count++;
        }

        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;

                if (count == 0)
                {
                    slottedItem = null;
                    icon = null;
                    type = CollectableTypes.NONE;
                }
            }
        }

        public bool CanAddItem() { if (count < maxAllowed) return true; return false; }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++) 
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(CollectableItem item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == CollectableTypes.NONE)
            {
                slot.AddItem(item);
                UIManager.Instance.GetInventoryUI().RefreshInventory();
                return;
            }

            if (slot.type == item.collectableType && slot.CanAddItem())
            {
                slot.AddItem(item);
                UIManager.Instance.GetInventoryUI().RefreshInventory();
                return;
            }
        }
    }

    public void AddToSlot(int slotIndex, CollectableItem item)
    {
        if (slotIndex >= 0 && slotIndex < slots.Count)
        {
            Slot slot = slots[slotIndex];
            if (slot.type == CollectableTypes.NONE || (slot.type == item.collectableType && slot.CanAddItem()))
            {
                slot.AddItem(item);
                UIManager.Instance.GetInventoryUI().RefreshInventory();
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

    public void RemoveFromSlot(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < slots.Count)
        {
            slots[slotIndex].RemoveItem();
        }
    }
}
