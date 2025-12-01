using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class ARTapInput : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("ARTapInput: Camera.main tidak ketemu! Pastikan ARCamera di-tag 'MainCamera'.");
        }
    }

    private void Update()
    {
        if (cam == null) return;

        // NEW INPUT SYSTEM
#if ENABLE_INPUT_SYSTEM
        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;
            if (touch.press.wasPressedThisFrame)
            {
                HandleTap(touch.position.ReadValue());
                return;
            }
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleTap(Mouse.current.position.ReadValue());
            return;
        }

#else
        // OLD INPUT SYSTEM
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTap(Input.mousePosition);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);
                if (t.phase == TouchPhase.Began)
                {
                    HandleTap(t.position);
                }
            }
        }
#endif
    }

    private void HandleTap(Vector2 screenPos)
    {
        Ray ray = cam.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.Log($"[Tap] Raycast kena: {hit.collider.name}");

            var selectable = hit.collider.GetComponentInParent<ARSelectableItem>();
            if (selectable != null)
            {
                selectable.ToggleActive();
            }
            else
            {
                Debug.Log("[Tap] Collider kena, tapi tidak ada ARSelectableItem di parent.");
            }
        }
        else
        {
            Debug.Log("[Tap] Raycast tidak kena apa-apa.");
        }
    }
}
