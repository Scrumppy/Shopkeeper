using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Character
{
    private bool isPlayerInteracting;

    private PlayerCharacter player;

    private void Update()
    {
        if (isPlayerInteracting && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.GetShopUI().ToggleShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<PlayerCharacter>();

        if (player)
        {
            isPlayerInteracting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (player)
        {
            isPlayerInteracting = false;
            UIManager.Instance.GetShopUI().ToggleShop();
        }
    }
}
