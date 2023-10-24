using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Inventory equipInventory;

    private void Awake()
    {
        inventory = new Inventory(7);
        equipInventory = new Inventory(2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.Instance?.GetInventoryUI().ToggleInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            UIManager.Instance?.GetPauseMenuUI().Pause();
        }
    }

    public Inventory GetInventory() { return inventory; }
    public Inventory GetEquipInventory() { return equipInventory; }
}
