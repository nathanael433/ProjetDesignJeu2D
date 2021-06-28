using UnityEngine;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{
    private int contentCurrentIndex = 0;

    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la sc�ne");
            return;
        }

        instance = this;
    }

    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems", "").Split(',');

        for (int i = 0; i < itemsSaved.Length; i++)
        {
            if(itemsSaved[i] != "")
            {
                int id = int.Parse(itemsSaved[i]);
                Item currentItem = ItemsDataBase.instance.allItems.Single(x => x.id == id);
                Inventory.instance.content.Add(currentItem);
            }
        }

        Inventory.instance.UpdateInventoryUI(contentCurrentIndex);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        
        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);
    }
}
