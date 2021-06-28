using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    private int contentCurrentIndex = 0;

    public Item item;

    public void BuyItem()
    {
        Inventory inventory = Inventory.instance;

        if(Inventory.instance.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI(contentCurrentIndex);
            inventory.coinsCount -= item.price;
            inventory.UpdateTextUI();
        }
    }
}
