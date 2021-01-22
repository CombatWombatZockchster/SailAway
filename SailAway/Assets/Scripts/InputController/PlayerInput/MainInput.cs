// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputController/PlayerInput/MainInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInput"",
    ""maps"": [
        {
            ""name"": ""OpenSea"",
            ""id"": ""8fa93e56-7d9c-44ff-b47d-5970e75443b0"",
            ""actions"": [
                {
                    ""name"": ""SailDirection"",
                    ""type"": ""Value"",
                    ""id"": ""823f41f8-c893-449d-9f28-76d2db0f27b0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShipDirection"",
                    ""type"": ""Value"",
                    ""id"": ""3a8ece7b-155e-4198-bc52-b82ef99ba2f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SailIntensity"",
                    ""type"": ""Value"",
                    ""id"": ""4cf2fc76-e448-40dd-bc79-5392c6d6dc57"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b501aae1-77d1-434e-a4e6-4f77d53d3fac"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SailDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""c52aed83-050c-49d5-8c46-4e1e88d16b6f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SailDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""25d1f54e-2692-4abb-8bd2-15d1284c8fbc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SailDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""78d9784c-d05c-4621-af24-26a619b1ee3f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SailDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ec24ba44-b070-4f2a-8919-67eb4ecaa6b8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SailDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0ed5ddaa-eb64-41d0-82a4-1fcf4d9d90d9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SailDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b6bb96cd-473e-41e7-bc79-7ce993005bf1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShipDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASDKeys"",
                    ""id"": ""f9df764f-7b24-481c-b00f-e3b302829a19"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShipDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""45b1b7d6-2a89-4393-9421-3a41bd3fd69c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShipDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""12ee9f18-194d-4d79-8340-93127b95e685"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShipDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""71c36113-c374-42dd-92e5-90c1a06de396"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShipDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6556dea2-ed0b-4e76-b5ae-61bfbd9dbaa0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShipDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""08e2858e-98c9-4b45-b89f-616da63acb7d"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SailIntensity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3df7f8d1-b0c1-4451-b45d-880ad2b814cb"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SailIntensity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // OpenSea
        m_OpenSea = asset.FindActionMap("OpenSea", throwIfNotFound: true);
        m_OpenSea_SailDirection = m_OpenSea.FindAction("SailDirection", throwIfNotFound: true);
        m_OpenSea_ShipDirection = m_OpenSea.FindAction("ShipDirection", throwIfNotFound: true);
        m_OpenSea_SailIntensity = m_OpenSea.FindAction("SailIntensity", throwIfNotFound: true);
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

    // OpenSea
    private readonly InputActionMap m_OpenSea;
    private IOpenSeaActions m_OpenSeaActionsCallbackInterface;
    private readonly InputAction m_OpenSea_SailDirection;
    private readonly InputAction m_OpenSea_ShipDirection;
    private readonly InputAction m_OpenSea_SailIntensity;
    public struct OpenSeaActions
    {
        private @MainInput m_Wrapper;
        public OpenSeaActions(@MainInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SailDirection => m_Wrapper.m_OpenSea_SailDirection;
        public InputAction @ShipDirection => m_Wrapper.m_OpenSea_ShipDirection;
        public InputAction @SailIntensity => m_Wrapper.m_OpenSea_SailIntensity;
        public InputActionMap Get() { return m_Wrapper.m_OpenSea; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OpenSeaActions set) { return set.Get(); }
        public void SetCallbacks(IOpenSeaActions instance)
        {
            if (m_Wrapper.m_OpenSeaActionsCallbackInterface != null)
            {
                @SailDirection.started -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnSailDirection;
                @SailDirection.performed -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnSailDirection;
                @SailDirection.canceled -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnSailDirection;
                @ShipDirection.started -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnShipDirection;
                @ShipDirection.performed -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnShipDirection;
                @ShipDirection.canceled -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnShipDirection;
                @SailIntensity.started -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnSailIntensity;
                @SailIntensity.performed -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnSailIntensity;
                @SailIntensity.canceled -= m_Wrapper.m_OpenSeaActionsCallbackInterface.OnSailIntensity;
            }
            m_Wrapper.m_OpenSeaActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SailDirection.started += instance.OnSailDirection;
                @SailDirection.performed += instance.OnSailDirection;
                @SailDirection.canceled += instance.OnSailDirection;
                @ShipDirection.started += instance.OnShipDirection;
                @ShipDirection.performed += instance.OnShipDirection;
                @ShipDirection.canceled += instance.OnShipDirection;
                @SailIntensity.started += instance.OnSailIntensity;
                @SailIntensity.performed += instance.OnSailIntensity;
                @SailIntensity.canceled += instance.OnSailIntensity;
            }
        }
    }
    public OpenSeaActions @OpenSea => new OpenSeaActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IOpenSeaActions
    {
        void OnSailDirection(InputAction.CallbackContext context);
        void OnShipDirection(InputAction.CallbackContext context);
        void OnSailIntensity(InputAction.CallbackContext context);
    }
}
