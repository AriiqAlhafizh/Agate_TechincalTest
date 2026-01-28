using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/InputReader")]
public class InputReader : ScriptableObject, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions gameInput;

    public Action<Vector2> moveEvent;
    public Action<Vector2> lookEvent;

    void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new InputSystem_Actions();
            gameInput.Player.SetCallbacks(this);
        }
        setPlayer();
    }

    void setPlayer()
    {
        gameInput.Player.Enable();
    }

    void OnDisable()
    {
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
        throw new System.NotImplementedException();
    }
}
