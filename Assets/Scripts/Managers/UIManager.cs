using UnityEngine;

public class UIManager : BaseManager<UIManager>
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ShopUI shopUI;
    [SerializeField] private PauseMenuUI pauseMenuUI;

    public InventoryUI GetInventoryUI() { return inventoryUI; }
    public ShopUI GetShopUI() { return shopUI; }
    public PauseMenuUI GetPauseMenuUI() { return pauseMenuUI; }
}
