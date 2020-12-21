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
                    ""id"": ""5f892f1e-ad58-4223-acad-9b3e210486fa"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game Pad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""017932b9-8a6f-48e9-987e-60fa96946293"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
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
                    ""id"": ""cecf7e45-89a8-4c0f-8c64-8b20b49b180a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game Pad"",
                    ""action"": ""Drift"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2164fc87-942c-4b8e-8cb6-a880f3c5c3d1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
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
                    ""id"": ""a1f7e9c5-8f90-422d-a27e-753adf0a514e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game Pad"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3a582065-ce08-4654-b11e-ef7c1ca6a930"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""23d5e587-48d0-45d7-af18-786aa701a588"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""705dbefe-55e5-47aa-b323-551e4a35ddc9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""629164c7-620e-4c77-87e8-c9e74b7392c7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4db52c89-f17b-49e9-8469-73272e1db91c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                },
                {
                    ""name"": """",
                    ""id"": ""cc583f4f-23c4-4bde-9989-34777a0c8762"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game Pad"",
                    ""action"": ""Stunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e626633-5b4a-4759-acb0-88576b47d697"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard And Mouse"",
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
        },
        {
            ""name"": ""Game Pad"",
            ""bindingGroup"": ""Game Pad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard And Mouse"",
            ""bindingGroup"": ""Keyboard And Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
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
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("Game Pad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard And Mouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
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
