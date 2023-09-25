using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    public Vector2 inputDirection = new Vector2();
    [SerializeField] MovementController myMovementController;


  

   

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
        myMovementController.SetDirection(inputDirection);
        
    }


}
