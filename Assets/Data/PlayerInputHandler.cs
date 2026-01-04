using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls inputActions;
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool DashPressed { get; private set; }

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();

        inputActions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => MoveInput = Vector2.zero;

        inputActions.Player.Jump.performed += ctx => JumpPressed = true;
        inputActions.Player.Attack.performed += ctx => AttackPressed = true;
        inputActions.Player.Dash.performed += ctx => DashPressed = true;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    public void ResetOneTimeInputs()
    {
        JumpPressed = false;
        AttackPressed = false;
        DashPressed = false;
    }
}
