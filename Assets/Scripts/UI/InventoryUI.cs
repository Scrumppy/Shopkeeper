using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private PlayerCharacter playerCharacter;

    [SerializeField] private List<SlotsUI> slots = new List<SlotsUI>();

    [SerializeField] private List<EquipSlotUI> equipSlots = new List<EquipSlotUI>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        RefreshInventory();
    }

    public void RefreshInventory()
    {
        if (slots.Count == playerCharacter.GetInventory().slots.Count) 
        {
            for (int i = 0; i < slots.Count; i++) 
            {
                if (playerCharacter.GetInventory().slots[i].type != CollectableTypes.NONE)
                {
                    slots[i].SetItem(playerCharacter.GetInventory().slots[i]);
                }
                else 
                {
                    slots[i].SetEmpty();
                }
            }
        }

        if (equipSlots.Count == playerCharacter.GetEquipInventory().slots.Count)
        {
            for (int i = 0; i < equipSlots.Count; i++)
            {
                if (playerCharacter.GetEquipInventory().slots[i].type != CollectableTypes.NONE)
                {
                    equipSlots[i].SetItem(playerCharacter.GetEquipInventory().slots[i]);
                }
                else
                {
                    equipSlots[i].SetEmpty();
                }
            }
        }
    }

    public void EquipItem(int slotID)
    {
        CollectableTypes itemType = playerCharacter.GetInventory().slots[slotID].type;

        if (!EquipManager.Instance.HasItemEquipped(itemType))
        {
            EquipManager.Instance.EquipItem(playerCharacter.GetInventory().slots[slotID].slottedItem);

            switch (itemType)
            {
                case CollectableTypes.NONE:
                    break;
                case CollectableTypes.OUTFIT:
                    playerCharacter.GetEquipInventory().AddToSlot(0, playerCharacter.GetInventory().slots[slotID].slottedItem);
                    break;
                case CollectableTypes.HAT:
                    playerCharacter.GetEquipInventory().AddToSlot(1, playerCharacter.GetInventory().slots[slotID].slottedItem);
                    break;
            }
          
            playerCharacter.GetInventory().Remove(slotID);

            RefreshInventory();
        }
    }

    public void UnequipItem(int slotID)
    {
        EquipManager.Instance.UnequipItem(playerCharacter.GetEquipInventory().slots[slotID].slottedItem);
        playerCharacter.GetInventory().Add(playerCharacter.GetEquipInventory().slots[slotID].slottedItem);
        playerCharacter.GetEquipInventory().Remove(slotID);
        RefreshInventory();
    }
}
