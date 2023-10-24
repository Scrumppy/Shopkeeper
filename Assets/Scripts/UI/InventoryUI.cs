using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private PlayerCharacter playerCharacter;

    [SerializeField] private List<SlotsUI> slots = new List<SlotsUI>();

    [SerializeField] private List<EquipSlotUI> equipSlots = new List<EquipSlotUI>();

    [SerializeField] private TextMeshProUGUI coinText;

    public void ToggleInventory()
    {
        AudioManager.Instance?.PlaySound("OpenInventory", 1);
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

        coinText.text = GameManager.Instance?.GetPlayerCoins().ToString();
    }

    public void EquipItem(int slotID)
    {
        CollectableTypes itemType = playerCharacter.GetInventory().slots[slotID].type;

        if (!EquipManager.Instance.HasItemEquipped(itemType))
        {
            EquipManager.Instance?.EquipItem(playerCharacter.GetInventory().slots[slotID].slottedItem);

            AudioManager.Instance?.PlaySound("Equip", 1);

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
            UIManager.Instance?.GetShopUI().RefreshSellInventory();
        }
    }

    public void UnequipItem(int slotID)
    {
        EquipManager.Instance?.UnequipItem(playerCharacter.GetEquipInventory().slots[slotID].slottedItem);
        AudioManager.Instance?.PlaySound("Equip", 1.2f);
        playerCharacter.GetInventory().Add(playerCharacter.GetEquipInventory().slots[slotID].slottedItem);
        playerCharacter.GetEquipInventory().Remove(slotID);
        RefreshInventory();
        UIManager.Instance.GetShopUI().RefreshSellInventory();
    }
}
