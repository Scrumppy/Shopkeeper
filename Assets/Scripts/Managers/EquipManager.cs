using System.Collections.Generic;
using UnityEngine;

public class EquipManager : BaseManager<EquipManager> 
{
    [SerializeField] private List<GameObject> itemPrefabs;

    [SerializeField] private GameObject playerObject;

    public void EquipItem(CollectableTypes collectableType)
    {
        GameObject itemPrefab = null;
        Transform targetTransform = null;

        switch (collectableType)
        {
            case CollectableTypes.OUTFIT_FISHER:
                itemPrefab = itemPrefabs[0];
                targetTransform = GetOutfitTransform();
                break;
            case CollectableTypes.OUTFIT_ARMOR:
                itemPrefab = itemPrefabs[1]; 
                targetTransform = GetOutfitTransform(); 
                break;
            case CollectableTypes.HAT:
                itemPrefab = itemPrefabs[2];
                targetTransform = GetHatTransform(); 
                break;
        }

        Debug.Log(itemPrefab.name);

        if (itemPrefab != null && targetTransform != null)
        {
            Instantiate(itemPrefab, targetTransform);
            Debug.Log("Equipped Item");
        }
        else
        {
            Debug.Log("Couldn't find the required transform on player");
        }
    }

    private Transform GetOutfitTransform()
    {
        if (playerObject != null)
        {
            Transform clothingTransform = playerObject.transform.Find("Clothing");
            if (clothingTransform != null)
            {
                return clothingTransform.Find("Outfit");
            }
        }
        return null;
    }

    private Transform GetHatTransform()
    {
        if (playerObject != null)
        {
            return playerObject.transform.Find("Hat");
        }
        return null;
    }
}
