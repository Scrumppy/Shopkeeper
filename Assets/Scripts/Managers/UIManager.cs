using UnityEngine;

public class UIManager : BaseManager<UIManager>
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ShopUI shopUI;

    public InventoryUI GetInventoryUI() { return inventoryUI; }
    public ShopUI GetShopUI() { return shopUI; }
}
