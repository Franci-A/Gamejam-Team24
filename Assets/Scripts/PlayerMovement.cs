using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.InputSystem.Android;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform[] _movementSlotsTransform;
    [SerializeField] Transform _playerTransform;
    private Controller _ControllerClass;
    private Controls _Buttons;

    class Controls
    {
        public InputAction m_Moves = new InputAction();
        public InputAction m_Symbols = new InputAction();
        private List<InputAction> _actions = new List<InputAction>();

        public void EnableInputAction(bool enable)
        {
            List<InputAction> actions = new List<InputAction>();
            actions.Add(m_Moves);
            actions.Add(m_Symbols);
            foreach (InputAction IA in actions)
            {
                if (enable)
                {
                    IA.Enable();
                }
                else
                {
                    IA.Disable();
                }
            }
        }
    }
    void Awake()
    {
        _ControllerClass = new Controller();
        _Buttons = new Controls();
        _Buttons.m_Moves = _ControllerClass.AMcontrols.SquareButtons;
        _Buttons.m_Symbols = _ControllerClass.AMcontrols.Symbols;
    }

    private void OnEnable()
    {
        _Buttons.EnableInputAction(true);
        _Buttons.m_Moves.performed += SquareButtons;
        _Buttons.m_Symbols.performed += Symbols;


    }
    private void OnDisable()
    {
        _Buttons.EnableInputAction(false);
    }
    private void SquareButtons(InputAction.CallbackContext context)
    {
        float i = context.ReadValue<float>();
        _playerTransform.DOMove(_movementSlotsTransform[(int)i - 1].position,0.1f);
    }
    private void Symbols(InputAction.CallbackContext context)
    {
        // Retourner la bonne valeur, BlablaFonctions(context.ReadValue<float>());
    }
}
