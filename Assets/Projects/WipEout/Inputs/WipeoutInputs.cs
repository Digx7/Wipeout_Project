// GENERATED AUTOMATICALLY FROM 'Assets/Projects/WipEout/Inputs/WipeoutInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @WipeoutInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @WipeoutInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""WipeoutInputs"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""d3fd124c-c99a-4861-a436-5ba64a8d0263"",
            ""actions"": [
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3b27003d-99f6-4ca8-803f-97304e1630c3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drift"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b70d79bf-4581-4b50-a7bd-8aadf7bfa8a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4ff6adfc-2fd9-4066-be2c-3f233bbc32b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stunt"",
                    ""type"": ""PassThrough"",
                    ""id"": ""87bb12b3-a1b7-4364-aeb7-724b8c756dfa"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4eb522be-8660-4cbe-b791-eade5c01e42a"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""X Box"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9d9c1cf-4339-479d-92a3-3a47d68e18e8"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""X Box"",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""655720af-2b80-4bae-ba3e-60202acb0c1d"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""X Box"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e19c873-68b1-417a-914c-77e5455b5468"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""X Box"",
                    ""action"": ""Stunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""X Box"",
            ""bindingGroup"": ""X Box"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Accelerate = m_Ship.FindAction("Accelerate", throwIfNotFound: true);
        m_Ship_Drift = m_Ship.FindAction("Drift", throwIfNotFound: true);
        m_Ship_Steering = m_Ship.FindAction("Steering", throwIfNotFound: true);
        m_Ship_Stunt = m_Ship.FindAction("Stunt", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_Accelerate;
    private readonly InputAction m_Ship_Drift;
    private readonly InputAction m_Ship_Steering;
    private readonly InputAction m_Ship_Stunt;
    public struct ShipActions
    {
        private @WipeoutInputs m_Wrapper;
        public ShipActions(@WipeoutInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accelerate => m_Wrapper.m_Ship_Accelerate;
        public InputAction @Drift => m_Wrapper.m_Ship_Drift;
        public InputAction @Steering => m_Wrapper.m_Ship_Steering;
        public InputAction @Stunt => m_Wrapper.m_Ship_Stunt;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @Accelerate.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnAccelerate;
                @Drift.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnDrift;
                @Drift.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnDrift;
                @Drift.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnDrift;
                @Steering.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnSteering;
                @Steering.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnSteering;
                @Steering.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnSteering;
                @Stunt.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnStunt;
                @Stunt.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnStunt;
                @Stunt.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnStunt;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Drift.started += instance.OnDrift;
                @Drift.performed += instance.OnDrift;
                @Drift.canceled += instance.OnDrift;
                @Steering.started += instance.OnSteering;
                @Steering.performed += instance.OnSteering;
                @Steering.canceled += instance.OnSteering;
                @Stunt.started += instance.OnStunt;
                @Stunt.performed += instance.OnStunt;
                @Stunt.canceled += instance.OnStunt;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);
    private int m_XBoxSchemeIndex = -1;
    public InputControlScheme XBoxScheme
    {
        get
        {
            if (m_XBoxSchemeIndex == -1) m_XBoxSchemeIndex = asset.FindControlSchemeIndex("X Box");
            return asset.controlSchemes[m_XBoxSchemeIndex];
        }
    }
    public interface IShipActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnDrift(InputAction.CallbackContext context);
        void OnSteering(InputAction.CallbackContext context);
        void OnStunt(InputAction.CallbackContext context);
    }
}
