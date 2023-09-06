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
    [SerializeField] float _movementSpeed;
    private Controller _ControllerClass;
    private Controls _Buttons;
    private CultistController CollidedCultist;
    private int _lastPlayerIndex  = 0;

    class Controls
    {
        #region InputActions
        public InputAction m_Moves = new InputAction();
        public InputAction m_Symbols = new InputAction();
        public InputAction m_GoldButtons = new InputAction();
        public InputAction m_AddCoinsButton = new InputAction();
        public InputAction m_Joystick = new InputAction();
        private List<InputAction> _actions = new List<InputAction>();
        #endregion

        public void EnableInputAction(bool enable)
        {
            #region ListOfInputs
            _actions.Add(m_Moves);
            _actions.Add(m_Symbols);
            _actions.Add(m_GoldButtons);
            _actions.Add(m_AddCoinsButton);
            _actions.Add(m_Joystick);
            #endregion
            foreach (InputAction IA in _actions)
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
        #region Assign Inputs
        _Buttons.m_Moves = _ControllerClass.AMcontrols.SquareButtons;
        _Buttons.m_Symbols = _ControllerClass.AMcontrols.Symbols;
        _Buttons.m_GoldButtons = _ControllerClass.AMcontrols.GoldButtons;
        _Buttons.m_AddCoinsButton = _ControllerClass.AMcontrols.AddCoinsButtons;
        _Buttons.m_AddCoinsButton = _ControllerClass.AMcontrols.Joystick;
        #endregion
    }

    private void OnEnable()
    {
        _Buttons.EnableInputAction(true);
        #region Assign Functions To Buttons
        _Buttons.m_Moves.performed += SquareButtons;
        _Buttons.m_Symbols.performed += Symbols;
        _Buttons.m_AddCoinsButton.performed += AddCoins;
        _Buttons.m_GoldButtons.performed += GoldButtons;
        _Buttons.m_Joystick.performed += Joystick;
        #endregion
    }
    private void OnDisable()
    {
        _Buttons.EnableInputAction(false);
    }
    private void SquareButtons(InputAction.CallbackContext context)
    {
        if (!(CollidedCultist != null && CollidedCultist.isInDialog))
        {
            if (DOTween.IsTweening(_playerTransform)) _playerTransform.DOKill();
            float i = context.ReadValue<float>();
            _playerTransform.DOMove(_movementSlotsTransform[(int)i - 1].position, 10 / _movementSpeed * (0.1f + (0.1f * Mathf.Abs(_lastPlayerIndex - i))));
            _lastPlayerIndex = (int)i;
        }

    }
    private void Symbols(InputAction.CallbackContext context)
    {
        if (CollidedCultist!=null)
        CollidedCultist.WaitInput((int)context.ReadValue<float>()-1);
    }
    private void AddCoins(InputAction.CallbackContext context)
    {
        //AddCoins
    }
    private void GoldButtons(InputAction.CallbackContext context)
    {
        //Gold Buttons
    }
    private void Joystick(InputAction.CallbackContext context)
    {
        //Joystick
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {

            CollidedCultist = collision.gameObject.GetComponent<CultistController>();
            CollidedCultist.StartDialog();
            _playerTransform.DOKill();
        }
    }


}
