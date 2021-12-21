using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Hero hero;
    private Vector2 inputVector;

    private void OnStroke()
    {
        if (gameObject.name == "Hero")
            hero.performAction();
    }

    private void OnMovement(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();
    }

    private void Update()
    {
        if (inputVector.x != 0)
        {
            inputVector.y = 0;
            if (inputVector.x < 0 && inputVector.x > -1)
                hero.change.x = -1;
            else if (inputVector.x > 0 && inputVector.x < 1)
                hero.change.x = 1;
            else
                hero.change.x = inputVector.x;
        }

        if (inputVector.y != 0)
        {
            if (inputVector.y < 0 && inputVector.y > -1)
                hero.change.y = -1;
            else if (inputVector.y > 0 && inputVector.y < 1)
                hero.change.y = 1;
            else
                hero.change.y = inputVector.y;
        }
    }
}
