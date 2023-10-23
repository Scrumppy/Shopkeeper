using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;

public class EquipSlotUI : InventorySlotUI
{
    [SerializeField] private CollectableTypes type;

    [SerializeField] private List<Sprite> placeHolderImages = new List<Sprite>();

    [SerializeField] private Image placeHolderImage;

    private void Awake()
    {
        switch (type)
        {
            case CollectableTypes.NONE:
                break;
            case CollectableTypes.OUTFIT:
                placeHolderImage.sprite = placeHolderImages[0];
                break;
            case CollectableTypes.HAT:
                placeHolderImage.sprite = placeHolderImages[1];
                break;
        }
    }

    private void EnablePlaceHolderImage(bool value)
    {
        switch (type)
        {
            case CollectableTypes.NONE:
                break;
            case CollectableTypes.OUTFIT:
                placeHolderImage.enabled = value;
                break;
            case CollectableTypes.HAT:
                placeHolderImage.enabled = value;
                break;
        }
    }

    public override void SetItem(Inventory.Slot slot) 
    {
        EnablePlaceHolderImage(false);

        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
        }
    }

    public override void SetEmpty()
    {
        EnablePlaceHolderImage(true);

        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
    }
}
