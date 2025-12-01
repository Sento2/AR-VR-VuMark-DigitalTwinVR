using UnityEngine;

public class DT_DebugState : MonoBehaviour
{
    void Start()
    {
        if (InventoryManager.Instance == null)
        {
            Debug.LogError("[DT] InventoryManager TIDAK KETEMU!");
        }
        else
        {
            foreach (var item in InventoryManager.Instance.items)
            {
                Debug.Log($"[DT] {item.type} | visible = {item.isVisible} | active = {item.isActive}");
            }
        }
    }
}
