using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput
{
    public PlayerInputActions _inputActions;

    public Vector2 Axis => _inputActions.Player.Movement.ReadValue<Vector2>();
    public bool Dash => _inputActions.Player.Dash.WasPerformedThisFrame();
    public void OnEnable()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
    }

    public void OnDisable()
    {
        _inputActions.Disable();
    }

    public void DisableActionFor(InputAction action,float seconds)
    {
        DisableAction(action,seconds);
    }

    private async void DisableAction(InputAction action, float seconds)
    {
        action.Disable();

        await UniTask.Delay(TimeSpan.FromSeconds(seconds));
        
        action.Enable();
    }
}
