using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private PlayerCharacter playerCharacter;

    [SerializeField] private List<SlotsUI> slots = new List<SlotsUI>();

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
    }

    public void EquipItem(int slotID)
    {
        EquipManager.Instance.EquipItem(playerCharacter.GetInventory().slots[slotID].type);
        playerCharacter.GetInventory().Remove(slotID);
        RefreshInventory();
    }
}
