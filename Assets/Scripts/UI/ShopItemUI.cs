using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : InventorySlotUI
{
    [SerializeField] private int buyPrice;

    [SerializeField] private bool isBuyable;

    [SerializeField] private int sellPrice;

    public TextMeshProUGUI priceText;

    private void Awake()
    {
        if (isBuyable)
        {
            priceText.text = buyPrice.ToString();
        }
    }

    public override void SetItem(Inventory.Slot slot)
    {
        if (slot != null && !isBuyable)
        {
            sellPrice = slot.itemPrice;
            priceText.text = (slot.itemPrice * GameManager.Instance.GetShopkeeperSellModifier()).ToString();
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    public override void SetEmpty()
    {
        sellPrice = 0;
        priceText.text = "0";
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }

    public int GetBuyPrice() {  return buyPrice; }

    public int GetSellPrice() { return sellPrice; }
}
