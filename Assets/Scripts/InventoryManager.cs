using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Box,
    Drum,
    Conveyor
}

[System.Serializable]
public class ItemState
{
    public ItemType type;
    public bool isVisible; // lagi ke-detect di AR atau nggak
    public bool isActive;  // misal conveyor jalan, drum terpilih, dll
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public List<ItemState> items = new List<ItemState>();

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Inisialisasi 3 item kalau list masih kosong
        if (items.Count == 0)
        {
            items.Add(new ItemState { type = ItemType.Box, isVisible = false, isActive = false });
            items.Add(new ItemState { type = ItemType.Drum, isVisible = false, isActive = false });
            items.Add(new ItemState { type = ItemType.Conveyor, isVisible = false, isActive = false });
        }
    }

    public ItemState GetItem(ItemType type)
    {
        return items.Find(i => i.type == type);
    }

    public void SetVisible(ItemType type, bool visible)
    {
        var item = GetItem(type);
        if (item != null)
        {
            item.isVisible = visible;
        }
    }

    public void ToggleActive(ItemType type)
    {
        var item = GetItem(type);
        if (item != null)
        {
            item.isActive = !item.isActive;
            Debug.Log($"Item {type} active = {item.isActive}");
        }
    }
}
