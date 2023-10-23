using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public CollectableTypes collectableType;

    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCharacter player = collision.GetComponent<PlayerCharacter>();

        if (player)
        {
            player.GetInventory().Add(this);

            //if (EquipManager.Instance != null)
            //{
            //    EquipManager.Instance.EquipItem(collectableType);
            //}

            Destroy(gameObject);
        }
    }
}
