using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchInputHandler : MonoBehaviour
{
    public static event System.Action<Vector2> OnTouchedScreen;

    void OnEnable() => EnhancedTouchSupport.Enable();
    void OnDisable() => EnhancedTouchSupport.Disable();

    void Update()
    {
#if UNITY_EDITOR

        CheckMouseInput();

#else

        CheckTouchInput();

#endif
    }
    private void CheckMouseInput()
    {
        // Check if the mouse is currently available
        if (Mouse.current == null) return;

        // Get the current mouse position
        var mousePosition = Mouse.current.position.ReadValue();

        // Check if the left mouse button was pressed
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            OnTouchedScreen?.Invoke(mousePosition);
        }
    }

    private void CheckTouchInput()
    {
        // Check if there are any active touches
        if (Touch.activeTouches.Count == 0) return;

        // Get the first active touch and invoke the event
        var touch = Touch.activeTouches[0];
        OnTouchedScreen?.Invoke(touch.screenPosition);
    }
}
