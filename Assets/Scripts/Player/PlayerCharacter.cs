using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(7);
    }

    public Inventory GetInventory() { return inventory; }
}
