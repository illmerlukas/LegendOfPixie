//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.1.1
//     from Assets/TheGame/inputs/FemalePlayerInputActions.inputactions
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

public partial class @FemalePlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FemalePlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FemalePlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""FemalePlayer"",
            ""id"": ""dd6c6413-fec8-43f0-bc09-b75252c5ad1b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""a88aedc8-25d3-4335-9be3-1535df6b1029"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cdc2498c-c05f-42c8-86e9-0e4be3e3c1b5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5b49b783-1003-47ad-b49c-0b4a6acec363"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""73bb5e9d-15ce-4aaa-8979-9617b84bc581"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19e4f98a-f045-4930-81c3-de80760abba8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0f868c11-ecd7-4aa1-9691-e0e901294b8d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FemalePlayer
        m_FemalePlayer = asset.FindActionMap("FemalePlayer", throwIfNotFound: true);
        m_FemalePlayer_Movement = m_FemalePlayer.FindAction("Movement", throwIfNotFound: true);
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

    // FemalePlayer
    private readonly InputActionMap m_FemalePlayer;
    private IFemalePlayerActions m_FemalePlayerActionsCallbackInterface;
    private readonly InputAction m_FemalePlayer_Movement;
    public struct FemalePlayerActions
    {
        private @FemalePlayerInputActions m_Wrapper;
        public FemalePlayerActions(@FemalePlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FemalePlayer_Movement;
        public InputActionMap Get() { return m_Wrapper.m_FemalePlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FemalePlayerActions set) { return set.Get(); }
        public void SetCallbacks(IFemalePlayerActions instance)
        {
            if (m_Wrapper.m_FemalePlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_FemalePlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_FemalePlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_FemalePlayerActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_FemalePlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public FemalePlayerActions @FemalePlayer => new FemalePlayerActions(this);
    public interface IFemalePlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}