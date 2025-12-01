using UnityEngine;

public class ARSelectableItem : MonoBehaviour
{
    public ItemType itemType;

    [Header("Visual")]
    public Renderer[] renderers;
    public Color inactiveColor = Color.white;
    public Color activeColor = Color.green;

    private void Start()
    {
        if (renderers == null || renderers.Length == 0)
        {
            renderers = GetComponentsInChildren<Renderer>();
        }

        UpdateVisual();
    }

    public void ToggleActive()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.ToggleActive(itemType);
            UpdateVisual();
            Debug.Log($"[AR] {itemType} di-tap, active = {InventoryManager.Instance.GetItem(itemType).isActive}");
        }
    }


    private void UpdateVisual()
    {
        if (InventoryManager.Instance == null) return;

        var state = InventoryManager.Instance.GetItem(itemType);
        bool active = state != null && state.isActive;

        foreach (var r in renderers)
        {
            if (r != null)
            {
                r.material.color = active ? activeColor : inactiveColor;
            }
        }
    }
}
