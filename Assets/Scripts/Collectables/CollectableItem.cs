using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public CollectableTypes collectableType;

    public string itemName;

    public Sprite icon;

    public int sellPrice;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCharacter player = collision.GetComponent<PlayerCharacter>();

        if (player)
        {
            player.GetInventory().Add(this);

            Destroy(gameObject);
        }
    }
}
