using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private PlayerCharacter playerCharacter;

    [SerializeField] private Shopkeeper shopkeeper;

    [SerializeField] private List<CollectableItem> collectableItems = new List<CollectableItem>();

    [SerializeField] private List<ShopItemUI> shopItems = new List<ShopItemUI>();

    [SerializeField] private List <ShopItemUI> sellShopItemSlots = new List<ShopItemUI>();

    [SerializeField] private GameObject buyPanel;

    [SerializeField] private GameObject sellPanel;

    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        if (buyPanel.activeSelf) 
        {
            sellPanel.SetActive(false);
        }

        RefreshMoney();
    }

    public void ToggleSellPanel(bool value)
    {
        sellPanel.SetActive(value);

        if (sellPanel.activeSelf)
        {
            RefreshSellInventory();
        }

        buyPanel.SetActive(!value);
    }

    public void ToggleShop(bool value)
    {
        shopPanel.SetActive(value);
    }

    public void RefreshMoney()
    {
        coinText.text = GameManager.Instance?.GetShopkeeperCoins().ToString();
    }

    public void RefreshSellInventory()
    {
        if (sellShopItemSlots.Count == playerCharacter.GetInventory().slots.Count)
        {
            for (int i = 0; i < sellShopItemSlots.Count; i++)
            {
                if (playerCharacter.GetInventory().slots[i].type != CollectableTypes.NONE)
                {
                    sellShopItemSlots[i].SetItem(playerCharacter.GetInventory().slots[i]);
                }
                else
                {
                    sellShopItemSlots[i].SetEmpty();
                }
            }
        }

        RefreshMoney();
    }

    public void BuyItem(int slotId)
    {
        if (!playerCharacter || !shopkeeper) return;

        if (GameManager.Instance.GetPlayerCoins() < shopItems[slotId].GetBuyPrice())
        {
            Debug.Log("Player doesn't have enough money");
            return;
        }

        GameManager.Instance?.AddCoins(shopkeeper, shopItems[slotId].GetBuyPrice());
        GameManager.Instance?.RemoveCoins(playerCharacter, shopItems[slotId].GetBuyPrice());

        AudioManager.Instance?.PlaySound("Purchase", 1);

        playerCharacter.GetInventory().Add(collectableItems[slotId]);

        RefreshMoney();
    }

    public void SellItem(int slotId)
    {
        if (!playerCharacter || !shopkeeper) return;

        if (GameManager.Instance.GetShopkeeperCoins() < sellShopItemSlots[slotId].GetSellPrice())
        {
            Debug.Log("Shopkeeper doesn't have enough money");
            return;
        }

        GameManager.Instance.AddCoins(playerCharacter, sellShopItemSlots[slotId].GetSellPrice());
        GameManager.Instance.RemoveCoins(shopkeeper, sellShopItemSlots[slotId].GetSellPrice());

        AudioManager.Instance?.PlaySound("Sell", 1);

        playerCharacter.GetInventory().Remove(slotId);
        RefreshSellInventory();
        UIManager.Instance?.GetInventoryUI().RefreshInventory();

        RefreshMoney();
    }
}
