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

    public Inventory GetInventory() { return inventory; }
    public Inventory GetEquipInventory() { return equipInventory; }
}
