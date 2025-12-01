using UnityEngine;
using Vuforia;

public class ARItemTracker : MonoBehaviour
{
    public ItemType itemType;

    private ObserverBehaviour observer;

    private void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();
    }

    private void OnEnable()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    private void OnDisable()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool visible =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.SetVisible(itemType, visible);
        }

        Debug.Log($"{itemType} visible = {visible}");
    }
}
