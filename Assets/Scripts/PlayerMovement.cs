using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform[] _movementSlotsTransform;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _movementSpeed;
    public Controller _ControllerClass;
    private Controls _Buttons;
    private CultistController CollidedCultist;
    private int _lastPlayerIndex  = 0;

    [SerializeField] private GameObjectEvent lostCultist;
    [SerializeField] private GameObjectEvent joinedCultist;
    [SerializeField] bool _arcadeControls;

    private void Start()
    {
        SoundManager.instance.PlayClip("CrowdTalk");
        lostCultist.scriptableEvent.AddListener(OnReleaseCultist);
        joinedCultist.scriptableEvent.AddListener(OnReleaseCultist);
    }

    [SerializeField] private GameObjectEvent sacrificeEvent;

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
        if (!_arcadeControls)
        {
            _Buttons.m_Moves = _ControllerClass.AMcontrols.SquareButtons;
            _Buttons.m_Symbols = _ControllerClass.AMcontrols.Symbols;
            _Buttons.m_GoldButtons = _ControllerClass.AMcontrols.GoldButtons;
            _Buttons.m_AddCoinsButton = _ControllerClass.AMcontrols.AddCoinsButtons;
            _Buttons.m_Joystick = _ControllerClass.AMcontrols.Joystick;
        }
        else
        {
            _Buttons.m_Moves = _ControllerClass.AMcontrolsArcade.SquareButtons;
            _Buttons.m_Symbols = _ControllerClass.AMcontrolsArcade.Symbols;
            _Buttons.m_GoldButtons = _ControllerClass.AMcontrolsArcade.GoldButtons;
            _Buttons.m_AddCoinsButton = _ControllerClass.AMcontrolsArcade.AddCoinsButtons;
            _Buttons.m_Joystick = _ControllerClass.AMcontrolsArcade.Joystick;
        }
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
            SoundManager.instance.PlayClip("FootSteps");
            if (DOTween.IsTweening(_playerTransform)) _playerTransform.DOKill();
            float i = context.ReadValue<float>();
            _playerTransform.DOMove(_movementSlotsTransform[(int)i - 1].position, 10 / _movementSpeed * (0.1f + (0.1f * Mathf.Abs(_lastPlayerIndex - i))));
            _lastPlayerIndex = (int)i;
        }

    }
    private void Symbols(InputAction.CallbackContext context)
    {
        if (CollidedCultist == null)
            return;
        CollidedCultist.CorrectInput((int)context.ReadValue<float>() - 1);

    }
    private void AddCoins(InputAction.CallbackContext context)
    {
        Debug.Log("add coins");
        if (CollidedCultist == null)
            return;

        if (CollidedCultist.ID == 2)
        {
            print((int)context.ReadValue<float>());
            if ((int)context.ReadValue<float>() == 1)
            {
                SoundManager.instance.PlayClip("GoodMotif");
            }
            if ((int)context.ReadValue<float>() == 0)
            {
                CollidedCultist.CorrectInput(5);
            }
        }
        else
        {
            CollidedCultist.CorrectInput(5);
        }
    }
    private void GoldButtons(InputAction.CallbackContext context)
    {
        Debug.Log("golden");
        if (CollidedCultist == null)
            return;
        CollidedCultist.CorrectInput(4);
    }
    private void Joystick(InputAction.CallbackContext context)
    {
        sacrificeEvent?.scriptableEvent.Invoke(null);
        GameManager.Instance.ShakeCamera();
        SoundManager.instance.PlayClip("Blood");
        SoundManager.instance.PlayClip("Lever");
        SoundManager.instance.PlayClip("Slash");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            if (CollidedCultist == null)
            {
                CollidedCultist = collision.gameObject.GetComponent<CultistController>();
                CollidedCultist.StartDialog();
                _playerTransform.DOKill();
            }
        }
    }

    public void OnReleaseCultist(object obj)
    {
        CollidedCultist = null;
    }

    private void OnDestroy()
    {
        lostCultist.scriptableEvent.RemoveListener(OnReleaseCultist);
        joinedCultist.scriptableEvent.RemoveListener(OnReleaseCultist);
    }
}
