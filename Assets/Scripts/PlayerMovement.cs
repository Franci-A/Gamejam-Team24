using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform[] _movementSlotsTransform;
    [SerializeField] Transform _playerTransform;
    private Controller _ControllerClass;
    private List<InputAction> _SquareButtons;

    void Awake()
    {
        _ControllerClass = new Controller();
        #region AddingSquareButtonsToList
        _SquareButtons = new List<InputAction>();
        _SquareButtons.Add(_ControllerClass.AMcontrols.SquareButton1);
        _SquareButtons.Add(_ControllerClass.AMcontrols.SquareButton2);
        _SquareButtons.Add(_ControllerClass.AMcontrols.SquareButton3);
        _SquareButtons.Add(_ControllerClass.AMcontrols.SquareButton4);
        #endregion
    }

    private void OnEnable()
    {
        EnableInputAction(true);
        
    }
    private void OnDisable()
    {
        EnableInputAction(false);
    }
    void Update()
    {
        
    }
    private void SquareButtons(InputAction.CallbackContext context)
    {
        float i = context.ReadValue<float>();
        _playerTransform.position = _movementSlotsTransform[(int)i-1].position;
    }

    private void EnableInputAction(bool enable)
    {
        foreach(InputAction IA in _SquareButtons)
        {
            if (enable)
            {
                
                IA.Enable();
                IA.performed += SquareButtons;
            }
            else
            {
                IA.Disable();
            }
        }
    }
}
