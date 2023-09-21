using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{

    public Vector2 inputDirection = new Vector2();
    public MovementController myMovementController = new MovementController();
    public InputAction.CallbackContext myInputAction = new InputAction.CallbackContext();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        OnMove(myInputAction);
       
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
        myMovementController.SetDirection(inputDirection);
        
    }


}
