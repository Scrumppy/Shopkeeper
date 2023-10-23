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

        public Sprite icon;

        public Slot()
        {
            type = CollectableTypes.NONE;
            count = 0;
            maxAllowed = 1;
        }

        public void AddItem(CollectableItem item)
        {
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

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }
}
