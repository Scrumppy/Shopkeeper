using System.Collections.Generic;
using UnityEngine;

public class EquipManager : BaseManager<EquipManager> 
{
    [SerializeField] private List<GameObject> itemPrefabs;

    [SerializeField] private PlayerCharacter player;

    [SerializeField] private GameObject equippedOutfit;
    [SerializeField] private GameObject equippedHat;

    public void EquipItem(CollectableItem itemToEquip)
    {
        GameObject itemPrefab = null;
        Transform targetTransform = null;


        CheckItemTypeAndEquip(itemToEquip, itemPrefab, targetTransform);

        //switch (itemToEquip.collectableType)
        //{
        //    case CollectableTypes.OUTFIT:
        //        itemPrefab = itemPrefabs[0];
        //        targetTransform = GetOutfitTransform();
        //        equippedOutfit = InstantiateItem(itemPrefab, targetTransform);
        //        break;
        //    case CollectableTypes.HAT:
        //        itemPrefab = itemPrefabs[1];
        //        targetTransform = GetHatTransform();
        //        equippedHat = InstantiateItem(itemPrefab, targetTransform);
        //        break;
        //}
    }

    public void UnequipItem(CollectableItem itemToUnequip)
    {
        GameObject equippedItem = null;
        switch (itemToUnequip.collectableType)
        {
            case CollectableTypes.OUTFIT:
                equippedItem = equippedOutfit;
                equippedOutfit = null;
                break;
            case CollectableTypes.HAT:
                equippedItem = equippedHat;
                equippedHat = null;
                break;
        }

        if (equippedItem != null)
        {
            Debug.Log(equippedItem.name);
            Destroy(equippedItem);
            Debug.Log("Unequipped Item");
        }
        else
        {
            Debug.Log("No item to unequip");
        }
    }

    private void CheckItemTypeAndEquip(CollectableItem itemToEquip, GameObject itemPrefab, Transform targetTransform)
    {
        if (itemToEquip.collectableType == CollectableTypes.OUTFIT)
        {
            HandleOutfit(itemToEquip, itemPrefab, targetTransform);
        }

        if (itemToEquip.collectableType == CollectableTypes.HAT)
        {
            HandleHat(itemToEquip, itemPrefab, targetTransform);
        }
    }

    private void HandleOutfit(CollectableItem itemToEquip, GameObject itemPrefab, Transform targetTransform)
    {
        if (itemToEquip.itemName == "Fisher")
        {
            itemPrefab = itemPrefabs[0];
            targetTransform = GetOutfitTransform();
            equippedOutfit = InstantiateItem(itemPrefab, targetTransform);

        }
        else if (itemToEquip.itemName == "Armor")
        {
            itemPrefab = itemPrefabs[1];
            targetTransform = GetOutfitTransform();
            equippedOutfit = InstantiateItem(itemPrefab, targetTransform);
        }

        Debug.Log("Equipped " + equippedOutfit.name);
    }

    private void HandleHat(CollectableItem itemToEquip, GameObject itemPrefab, Transform targetTransform)
    {
        if (itemToEquip.itemName == "Wizard")
        {
            itemPrefab = itemPrefabs[2];
            targetTransform = GetHatTransform();
            equippedHat = InstantiateItem(itemPrefab, targetTransform);

        }
        else if (itemToEquip.itemName == "Beanie")
        {
            itemPrefab = itemPrefabs[3];
            targetTransform = GetOutfitTransform();
            equippedHat = InstantiateItem(itemPrefab, targetTransform);
        }

        Debug.Log("Equipped " + equippedHat.name);
    }

    private GameObject InstantiateItem(GameObject itemPrefab, Transform targetTransform)
    {
        if (itemPrefab != null && targetTransform != null)
        {
            return Instantiate(itemPrefab, targetTransform);
        }
        else
        {
            Debug.Log("Couldn't find the required transform on player");
            return null;
        }
    }

    private Transform GetOutfitTransform()
    {
        if (player != null)
        {
            Transform clothingTransform = player.transform.Find("Clothing");
            if (clothingTransform != null)
            {
                return clothingTransform.Find("Outfit");
            }
        }
        return null;
    }

    private Transform GetHatTransform()
    {
        if (player != null)
        {
            Transform clothingTransform = player.transform.Find("Clothing");
            if (clothingTransform != null)
            {
                return clothingTransform.Find("Head");
            }
        }
        return null;
    }

    public bool HasItemEquipped(CollectableTypes itemType)
    {
        foreach (var slot in player.GetEquipInventory().slots) 
        {
            if (slot.type == itemType)
            {
                Debug.Log("Item type " + itemType.ToString() + " is already equipped");
                return true;
            }
        }

        return false;
    }
}
