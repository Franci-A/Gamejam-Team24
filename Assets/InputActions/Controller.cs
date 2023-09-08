//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputActions/Controller.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controller: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""AMcontrols"",
            ""id"": ""6e4037ce-3fdf-42c3-abb6-293150ca1bc5"",
            ""actions"": [
                {
                    ""name"": ""GoldButtons"",
                    ""type"": ""Button"",
                    ""id"": ""bf8375c9-d843-4d87-aaca-e873b7c23ed7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Symbols"",
                    ""type"": ""Button"",
                    ""id"": ""f722655f-8a49-4377-b803-ef3ece2c4dcb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SquareButtons"",
                    ""type"": ""Button"",
                    ""id"": ""cf6f98d9-89f1-4473-87e1-b10f7eb3695d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AddCoinsButtons"",
                    ""type"": ""Button"",
                    ""id"": ""b1741229-fd88-43e8-b3ff-018badd06b0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""type"": ""Button"",
                    ""id"": ""8271b94b-5678-42bc-9fbc-213cf1b348d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8071148-0def-4822-a2fe-5bb37ee67d1b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoldButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7715cc4-aa71-4719-9299-f2d282745229"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""GoldButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a85e026-549e-4d1f-a5ad-563b82af7ed1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""83c156dc-ea09-4911-86d1-cca317e88345"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35b6f848-56f3-423c-8a82-7d8664832cee"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31413e1f-6c4e-4834-9975-9604eb156d1b"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd0eb146-9750-4d9e-85e5-382f6cebbaa4"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c5d2550-50c4-4d41-94cb-f0559d47f312"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36192c38-cf1f-48ab-a68e-fc2294ecb528"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40ed0f33-ab29-4dc4-8bfa-f206eeaa922d"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""190246ba-9386-4c84-87a8-6ac8c0d69d97"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddCoinsButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""882caaa1-f8e9-433d-adbc-b9cf7a49ee0b"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddCoinsButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5ef1e8c-6799-4150-8f02-62d70d798620"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f5d1727-e9d5-4186-9685-a311f0b702ac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9da983fb-4239-434e-adb0-e6c7576469e0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a79ad6b8-ad5f-4369-9cf0-0763e2be76f4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""AMcontrolsArcade"",
            ""id"": ""168938e5-e212-4b41-a861-6ea065402dbd"",
            ""actions"": [
                {
                    ""name"": ""GoldButtons"",
                    ""type"": ""Button"",
                    ""id"": ""a6bc59ca-d1e6-4a5e-b615-25f24fb354d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Symbols"",
                    ""type"": ""Button"",
                    ""id"": ""ce5eaa61-486e-4146-b112-8d99a15969a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SquareButtons"",
                    ""type"": ""Button"",
                    ""id"": ""f80dc660-2e8f-4f9c-9445-7a48504a9aa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AddCoinsButtons"",
                    ""type"": ""Button"",
                    ""id"": ""07773fa4-c639-4309-9ed5-61169e247819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""type"": ""Button"",
                    ""id"": ""2a71c240-bddd-4ac7-a4a7-5afa64150561"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""288ad02b-89d6-4060-97ca-1e766aa46172"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoldButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d19033e5-04fa-4fdc-ba36-99fd9ea33958"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""GoldButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1781dfd-dd63-4cf1-a933-5cabe773163f"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4c6b373-c94f-489d-8e26-4f01b3bd0f58"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2892c88-88c9-4c5f-8d6f-3c3b74a25ad1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a78b170-6df9-4936-86b8-b22c0be202c7"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""Symbols"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6797797c-18f3-40f5-a67f-cb5af807829d"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58856b42-187d-462f-b6cf-f14cc86f65cf"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfa65401-1c77-42ad-93fe-446a7a5e2bb6"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""116c3e04-e272-4ac5-93ce-3313f0b5bf9d"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""SquareButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ec379d4-ab34-42e0-8714-27ddbb84b1c4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AddCoinsButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d2d571-1a95-4178-a445-48a056bd71da"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""AddCoinsButtons"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b30ee0b9-341f-416c-b497-5c12a9decd10"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f286264-8e30-4cc0-86ca-ffcef09293a1"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5552fbd7-97b4-4215-b22e-09457ee8aa10"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e081ab76-25e6-4b74-b324-9977707a2074"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AMcontrols
        m_AMcontrols = asset.FindActionMap("AMcontrols", throwIfNotFound: true);
        m_AMcontrols_GoldButtons = m_AMcontrols.FindAction("GoldButtons", throwIfNotFound: true);
        m_AMcontrols_Symbols = m_AMcontrols.FindAction("Symbols", throwIfNotFound: true);
        m_AMcontrols_SquareButtons = m_AMcontrols.FindAction("SquareButtons", throwIfNotFound: true);
        m_AMcontrols_AddCoinsButtons = m_AMcontrols.FindAction("AddCoinsButtons", throwIfNotFound: true);
        m_AMcontrols_Joystick = m_AMcontrols.FindAction("Joystick", throwIfNotFound: true);
        // AMcontrolsArcade
        m_AMcontrolsArcade = asset.FindActionMap("AMcontrolsArcade", throwIfNotFound: true);
        m_AMcontrolsArcade_GoldButtons = m_AMcontrolsArcade.FindAction("GoldButtons", throwIfNotFound: true);
        m_AMcontrolsArcade_Symbols = m_AMcontrolsArcade.FindAction("Symbols", throwIfNotFound: true);
        m_AMcontrolsArcade_SquareButtons = m_AMcontrolsArcade.FindAction("SquareButtons", throwIfNotFound: true);
        m_AMcontrolsArcade_AddCoinsButtons = m_AMcontrolsArcade.FindAction("AddCoinsButtons", throwIfNotFound: true);
        m_AMcontrolsArcade_Joystick = m_AMcontrolsArcade.FindAction("Joystick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // AMcontrols
    private readonly InputActionMap m_AMcontrols;
    private List<IAMcontrolsActions> m_AMcontrolsActionsCallbackInterfaces = new List<IAMcontrolsActions>();
    private readonly InputAction m_AMcontrols_GoldButtons;
    private readonly InputAction m_AMcontrols_Symbols;
    private readonly InputAction m_AMcontrols_SquareButtons;
    private readonly InputAction m_AMcontrols_AddCoinsButtons;
    private readonly InputAction m_AMcontrols_Joystick;
    public struct AMcontrolsActions
    {
        private @Controller m_Wrapper;
        public AMcontrolsActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoldButtons => m_Wrapper.m_AMcontrols_GoldButtons;
        public InputAction @Symbols => m_Wrapper.m_AMcontrols_Symbols;
        public InputAction @SquareButtons => m_Wrapper.m_AMcontrols_SquareButtons;
        public InputAction @AddCoinsButtons => m_Wrapper.m_AMcontrols_AddCoinsButtons;
        public InputAction @Joystick => m_Wrapper.m_AMcontrols_Joystick;
        public InputActionMap Get() { return m_Wrapper.m_AMcontrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AMcontrolsActions set) { return set.Get(); }
        public void AddCallbacks(IAMcontrolsActions instance)
        {
            if (instance == null || m_Wrapper.m_AMcontrolsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AMcontrolsActionsCallbackInterfaces.Add(instance);
            @GoldButtons.started += instance.OnGoldButtons;
            @GoldButtons.performed += instance.OnGoldButtons;
            @GoldButtons.canceled += instance.OnGoldButtons;
            @Symbols.started += instance.OnSymbols;
            @Symbols.performed += instance.OnSymbols;
            @Symbols.canceled += instance.OnSymbols;
            @SquareButtons.started += instance.OnSquareButtons;
            @SquareButtons.performed += instance.OnSquareButtons;
            @SquareButtons.canceled += instance.OnSquareButtons;
            @AddCoinsButtons.started += instance.OnAddCoinsButtons;
            @AddCoinsButtons.performed += instance.OnAddCoinsButtons;
            @AddCoinsButtons.canceled += instance.OnAddCoinsButtons;
            @Joystick.started += instance.OnJoystick;
            @Joystick.performed += instance.OnJoystick;
            @Joystick.canceled += instance.OnJoystick;
        }

        private void UnregisterCallbacks(IAMcontrolsActions instance)
        {
            @GoldButtons.started -= instance.OnGoldButtons;
            @GoldButtons.performed -= instance.OnGoldButtons;
            @GoldButtons.canceled -= instance.OnGoldButtons;
            @Symbols.started -= instance.OnSymbols;
            @Symbols.performed -= instance.OnSymbols;
            @Symbols.canceled -= instance.OnSymbols;
            @SquareButtons.started -= instance.OnSquareButtons;
            @SquareButtons.performed -= instance.OnSquareButtons;
            @SquareButtons.canceled -= instance.OnSquareButtons;
            @AddCoinsButtons.started -= instance.OnAddCoinsButtons;
            @AddCoinsButtons.performed -= instance.OnAddCoinsButtons;
            @AddCoinsButtons.canceled -= instance.OnAddCoinsButtons;
            @Joystick.started -= instance.OnJoystick;
            @Joystick.performed -= instance.OnJoystick;
            @Joystick.canceled -= instance.OnJoystick;
        }

        public void RemoveCallbacks(IAMcontrolsActions instance)
        {
            if (m_Wrapper.m_AMcontrolsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAMcontrolsActions instance)
        {
            foreach (var item in m_Wrapper.m_AMcontrolsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AMcontrolsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AMcontrolsActions @AMcontrols => new AMcontrolsActions(this);

    // AMcontrolsArcade
    private readonly InputActionMap m_AMcontrolsArcade;
    private List<IAMcontrolsArcadeActions> m_AMcontrolsArcadeActionsCallbackInterfaces = new List<IAMcontrolsArcadeActions>();
    private readonly InputAction m_AMcontrolsArcade_GoldButtons;
    private readonly InputAction m_AMcontrolsArcade_Symbols;
    private readonly InputAction m_AMcontrolsArcade_SquareButtons;
    private readonly InputAction m_AMcontrolsArcade_AddCoinsButtons;
    private readonly InputAction m_AMcontrolsArcade_Joystick;
    public struct AMcontrolsArcadeActions
    {
        private @Controller m_Wrapper;
        public AMcontrolsArcadeActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoldButtons => m_Wrapper.m_AMcontrolsArcade_GoldButtons;
        public InputAction @Symbols => m_Wrapper.m_AMcontrolsArcade_Symbols;
        public InputAction @SquareButtons => m_Wrapper.m_AMcontrolsArcade_SquareButtons;
        public InputAction @AddCoinsButtons => m_Wrapper.m_AMcontrolsArcade_AddCoinsButtons;
        public InputAction @Joystick => m_Wrapper.m_AMcontrolsArcade_Joystick;
        public InputActionMap Get() { return m_Wrapper.m_AMcontrolsArcade; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AMcontrolsArcadeActions set) { return set.Get(); }
        public void AddCallbacks(IAMcontrolsArcadeActions instance)
        {
            if (instance == null || m_Wrapper.m_AMcontrolsArcadeActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AMcontrolsArcadeActionsCallbackInterfaces.Add(instance);
            @GoldButtons.started += instance.OnGoldButtons;
            @GoldButtons.performed += instance.OnGoldButtons;
            @GoldButtons.canceled += instance.OnGoldButtons;
            @Symbols.started += instance.OnSymbols;
            @Symbols.performed += instance.OnSymbols;
            @Symbols.canceled += instance.OnSymbols;
            @SquareButtons.started += instance.OnSquareButtons;
            @SquareButtons.performed += instance.OnSquareButtons;
            @SquareButtons.canceled += instance.OnSquareButtons;
            @AddCoinsButtons.started += instance.OnAddCoinsButtons;
            @AddCoinsButtons.performed += instance.OnAddCoinsButtons;
            @AddCoinsButtons.canceled += instance.OnAddCoinsButtons;
            @Joystick.started += instance.OnJoystick;
            @Joystick.performed += instance.OnJoystick;
            @Joystick.canceled += instance.OnJoystick;
        }

        private void UnregisterCallbacks(IAMcontrolsArcadeActions instance)
        {
            @GoldButtons.started -= instance.OnGoldButtons;
            @GoldButtons.performed -= instance.OnGoldButtons;
            @GoldButtons.canceled -= instance.OnGoldButtons;
            @Symbols.started -= instance.OnSymbols;
            @Symbols.performed -= instance.OnSymbols;
            @Symbols.canceled -= instance.OnSymbols;
            @SquareButtons.started -= instance.OnSquareButtons;
            @SquareButtons.performed -= instance.OnSquareButtons;
            @SquareButtons.canceled -= instance.OnSquareButtons;
            @AddCoinsButtons.started -= instance.OnAddCoinsButtons;
            @AddCoinsButtons.performed -= instance.OnAddCoinsButtons;
            @AddCoinsButtons.canceled -= instance.OnAddCoinsButtons;
            @Joystick.started -= instance.OnJoystick;
            @Joystick.performed -= instance.OnJoystick;
            @Joystick.canceled -= instance.OnJoystick;
        }

        public void RemoveCallbacks(IAMcontrolsArcadeActions instance)
        {
            if (m_Wrapper.m_AMcontrolsArcadeActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAMcontrolsArcadeActions instance)
        {
            foreach (var item in m_Wrapper.m_AMcontrolsArcadeActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AMcontrolsArcadeActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AMcontrolsArcadeActions @AMcontrolsArcade => new AMcontrolsArcadeActions(this);
    public interface IAMcontrolsActions
    {
        void OnGoldButtons(InputAction.CallbackContext context);
        void OnSymbols(InputAction.CallbackContext context);
        void OnSquareButtons(InputAction.CallbackContext context);
        void OnAddCoinsButtons(InputAction.CallbackContext context);
        void OnJoystick(InputAction.CallbackContext context);
    }
    public interface IAMcontrolsArcadeActions
    {
        void OnGoldButtons(InputAction.CallbackContext context);
        void OnSymbols(InputAction.CallbackContext context);
        void OnSquareButtons(InputAction.CallbackContext context);
        void OnAddCoinsButtons(InputAction.CallbackContext context);
        void OnJoystick(InputAction.CallbackContext context);
    }
}
