using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/InputReader")]
public class InputReader : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions gameInput;

    public Action<Vector2> moveEvent;
    public Action<Vector2> lookEvent;

    public Action pauseEvent;

    void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new InputSystem_Actions();
            gameInput.Player.SetCallbacks(this);
        }
        setPlayer();
    }

    void setUI()
    {
        gameInput.Player.Disable();
        gameInput.UI.Enable();
    }

    public void setPlayer()
    {
        gameInput.Player.Enable();
        gameInput.UI.Disable();
    }

    void OnDisable()
    {
        gameInput.Player.Disable();
        gameInput.UI.Disable();
        gameInput.Dispose();
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        lookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveEvent?.Invoke(context.ReadValue<Vector2>());
        }
        else if (context.canceled)
        {
            moveEvent?.Invoke(Vector2.zero);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        pauseEvent?.Invoke();
    }
}
