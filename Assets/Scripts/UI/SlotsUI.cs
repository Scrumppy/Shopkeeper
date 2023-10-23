using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Inventory;

public class SlotsUI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null) 
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty() 
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }
}
