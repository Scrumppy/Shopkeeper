using UnityEngine;

public class UIManager : BaseManager<UIManager>
{
    [SerializeField] private InventoryUI inventoryUI;

    public InventoryUI GetInventoryUI() { return inventoryUI; } 
}
