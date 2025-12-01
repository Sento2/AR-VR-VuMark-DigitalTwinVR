using UnityEngine;

public class DigitalTwinItem : MonoBehaviour
{
    public ItemType itemType;

    [Header("Visual")]
    public Renderer[] renderers;
    public Color inactiveColor = Color.gray;
    public Color activeColor = Color.green;

    [Header("Optional Animator (misal conveyor)")]
    public Animator animator;
    public string activeBoolName = "IsActive";

    private void Start()
    {
        if (renderers == null || renderers.Length == 0)
        {
            renderers = GetComponentsInChildren<Renderer>();
        }

        UpdateVisual();
    }

    private void Update()
    {
        // Tiap frame sync dengan InventoryManager
        UpdateVisual();
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

        if (animator != null && !string.IsNullOrEmpty(activeBoolName))
        {
            animator.SetBool(activeBoolName, active);
        }
    }
}
