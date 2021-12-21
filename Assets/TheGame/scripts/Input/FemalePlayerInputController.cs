using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FemalePlayerInputController : MonoBehaviour
{
    public Hero hero;
    private PlayerInput playerInput;
    private FemalePlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new FemalePlayerInputActions();
        playerInputActions.FemalePlayer.Enable();
    }

    private void Update()
    {
        Vector2 inputVector = playerInputActions.FemalePlayer.Movement.ReadValue<Vector2>();

        if (inputVector.x != 0)
        {
            hero.change.y = 0;
            
            if (inputVector.x < 0 && inputVector.x > -1)
                hero.change.x = -1;
            else if (inputVector.x > 0 && inputVector.x < 1)
                hero.change.x = 1;
            else
                hero.change.x = inputVector.x;
        }
        else if (inputVector.y != 0)
        {
            hero.change.x = 0;
            
            if (inputVector.y < 0 && inputVector.y > -1)
                hero.change.y = -1;
            else if (inputVector.y > 0 && inputVector.y < 1)
                hero.change.y = 1;
            else
                hero.change.y = inputVector.y;

        }
    }
}
