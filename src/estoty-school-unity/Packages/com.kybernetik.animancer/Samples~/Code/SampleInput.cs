// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2025 Kybernetik //

using UnityEngine;

#if UNITY_UGUI
using UnityEngine.EventSystems;
#endif

#if UNITY_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Animancer.Samples
{
    /// <summary>
    /// A standard wrapper for receiving input from the
    /// <see href="https://docs.unity3d.com/Packages/com.unity.inputsystem@latest">Input System</see> package or the
    /// <see href="https://docs.unity3d.com/Manual/class-InputManager.html">Legacy Input Manager</see>.
    /// <remarks>
    /// <strong>Documentation:</strong>
    /// <see href="https://kybernetik.com.au/animancer/docs/samples/basics/input">
    /// Input</see>
    /// </remarks>
    /// https://kybernetik.com.au/animancer/api/Animancer.Samples/SampleInput
    /// 
    [AnimancerHelpUrl(typeof(SampleInput))]
    public static class SampleInput
    {
        /************************************************************************************************************************/

        /// <summary>The current screen position of the mouse pointer.</summary>
        public static Vector2 MousePosition
#if UNITY_INPUT_SYSTEM
            => Mouse.current.position.ReadValue();
#else
            => Input.mousePosition;
#endif

        /// <summary>The amount that the mouse has moved since last frame.</summary>
        public static Vector2 MousePositionDelta
#if UNITY_INPUT_SYSTEM
            => Mouse.current.delta.ReadValue();
#else
            => new(Input.GetAxisRaw("Mouse X") * 20, Input.GetAxisRaw("Mouse Y") * 20);
#endif

        /// <summary>The amount that the mouse scroll value has changed since last frame.</summary>
        public static Vector2 MouseScrollDelta
#if UNITY_INPUT_SYSTEM
            => Mouse.current.scroll.ReadValue() * 0.01f;
#else
            => Input.mouseScrollDelta;
#endif

        /************************************************************************************************************************/

        /// <summary>Is the mouse pointer currently over a UI object?</summary>
        public static bool IsPointerOverUI
#if UNITY_UGUI
            => EventSystem.current != null
            && EventSystem.current.IsPointerOverGameObject();
#else
            => false;
#endif

        /************************************************************************************************************************/

        /// <summary>Was the left mouse button pressed this frame?</summary>
        public static bool LeftMouseDown
#if UNITY_INPUT_SYSTEM
            => !IsPointerOverUI
            && Mouse.current.leftButton.wasPressedThisFrame;
#else
            => Input.GetMouseButtonDown(0);
#endif

        /// <summary>Is the left mouse button currently being held down?</summary>
        public static bool LeftMouseHold
#if UNITY_INPUT_SYSTEM
            => Mouse.current.leftButton.isPressed;
#else
            => Input.GetMouseButton(0);
#endif

        /// <summary>Was the left mouse button released this frame?</summary>
        public static bool LeftMouseUp
#if UNITY_INPUT_SYSTEM
            => !IsPointerOverUI
            && Mouse.current.leftButton.wasReleasedThisFrame;
#else
            => !IsPointerOverUI
            && Input.GetMouseButtonUp(0);
#endif

        /************************************************************************************************************************/

        /// <summary>Was the right mouse button pressed this frame?</summary>
        public static bool RightMouseDown
#if UNITY_INPUT_SYSTEM
            => !IsPointerOverUI
            && Mouse.current.rightButton.wasPressedThisFrame;
#else
            => !IsPointerOverUI
            && Input.GetMouseButtonDown(1);
#endif

        /// <summary>Is the right mouse button currently being held down?</summary>
        public static bool RightMouseHold
#if UNITY_INPUT_SYSTEM
            => Mouse.current.rightButton.isPressed;
#else
            => Input.GetMouseButton(1);
#endif

        /************************************************************************************************************************/

        /// <summary>Was <see cref="KeyCode.Space"/> pressed this frame?</summary>
        public static bool SpaceDown
#if UNITY_INPUT_SYSTEM
            => Keyboard.current.spaceKey.wasPressedThisFrame;
#else
            => Input.GetKeyDown(KeyCode.Space);
#endif

        /// <summary>Is <see cref="KeyCode.Space"/> currently being held down?</summary>
        public static bool SpaceHold
#if UNITY_INPUT_SYSTEM
            => Keyboard.current.spaceKey.isPressed;
#else
            => Input.GetKey(KeyCode.Space);
#endif

        /// <summary>Was <see cref="KeyCode.Space"/> released this frame?</summary>
        public static bool SpaceUp
#if UNITY_INPUT_SYSTEM
            => Keyboard.current.spaceKey.wasReleasedThisFrame;
#else
            => Input.GetKeyUp(KeyCode.Space);
#endif

        /************************************************************************************************************************/

        /// <summary>Is <see cref="KeyCode.LeftShift"/> currently being held down?</summary>
        public static bool LeftShiftHold
#if UNITY_INPUT_SYSTEM
            => Keyboard.current.leftShiftKey.isPressed;
#else
            => Input.GetKey(KeyCode.LeftShift);
#endif

        /************************************************************************************************************************/

        /// <summary>Was <see cref="KeyCode.Alpha1"/> released this frame?</summary>
        public static bool Number1Up
#if UNITY_INPUT_SYSTEM
            => Keyboard.current.digit1Key.wasReleasedThisFrame;
#else
            => Input.GetKeyUp(KeyCode.Alpha1);
#endif

        /// <summary>Was <see cref="KeyCode.Alpha2"/> released this frame?</summary>
        public static bool Number2Up
#if UNITY_INPUT_SYSTEM
            => Keyboard.current.digit2Key.wasReleasedThisFrame;
#else
            => Input.GetKeyUp(KeyCode.Alpha2);
#endif

        /************************************************************************************************************************/

#if UNITY_INPUT_SYSTEM
        private static InputAction _WasdAction;
#endif

        /// <summary>WASD Controls.</summary>
        public static Vector2 WASD
#if UNITY_INPUT_SYSTEM
        {
            get
            {
                if (_WasdAction == null)
                {
                    _WasdAction = new(nameof(WASD), InputActionType.Value);
                    _WasdAction.AddCompositeBinding("2DVector")
                        .With("Up", "<Keyboard>/w")
                        .With("Down", "<Keyboard>/s")
                        .With("Left", "<Keyboard>/a")
                        .With("Right", "<Keyboard>/d");
                }

                _WasdAction.Enable();

                return _WasdAction.ReadValue<Vector2>();
            }
        }
#else
            => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#endif

        /************************************************************************************************************************/
    }
}
