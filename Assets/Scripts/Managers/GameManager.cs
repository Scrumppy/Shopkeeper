using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager<GameManager>
{
    [SerializeField] private int playerCoins;
    [SerializeField] private int shopkeeperCoins;

    [SerializeField] private float shopKeeperSellModifier;

    public void AddCoins(Character character, int amount)
    {
        if (!character) return;

        if (character is PlayerCharacter) 
        {
            playerCoins += amount;
        }
        else if (character is Shopkeeper)
        {
            shopkeeperCoins += amount;
        }
    }

    public void RemoveCoins(Character character, int amount)
    {
        if (!character) return;

        if (character is PlayerCharacter)
        {
            playerCoins = Mathf.Max(0, playerCoins - amount);

        }
        else if (character is Shopkeeper)
        {
            shopkeeperCoins = Mathf.Max(0, shopkeeperCoins - amount);
        }
    }

    public int GetPlayerCoins() { return playerCoins; } 
    public int GetShopkeeperCoins() { return shopkeeperCoins; }

    public float GetShopkeeperSellModifier() { return shopKeeperSellModifier; }
}
