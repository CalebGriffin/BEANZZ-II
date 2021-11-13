// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b81cea57-dd45-476f-a74f-ed5ca8e3af07"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""dac46707-6c19-4003-b5c1-d8a29c0afaaa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""01f4f059-8346-4e67-9db1-946c6c295681"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor Towards"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e480a44d-ce80-4fac-b487-7875818e0ac7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Cursor Away"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f43b6469-26c6-4ba0-bd48-2c1efa07c45e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Yeet"",
                    ""type"": ""Button"",
                    ""id"": ""9e4eb3e8-a34e-47bd-9c97-4b3722721765"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ButtonNorth"",
                    ""type"": ""Button"",
                    ""id"": ""27906ce3-de3c-4446-a5b9-ac830c8c66e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ButtonSouth"",
                    ""type"": ""Button"",
                    ""id"": ""485912cb-622a-4c38-9de8-e224278c4dc7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ButtonEast"",
                    ""type"": ""Button"",
                    ""id"": ""96099fa8-beb5-4fd3-a1a1-3ebd23ece3c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""ButtonWest"",
                    ""type"": ""Button"",
                    ""id"": ""94e63097-882a-45b0-9e34-8b45f86447e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f48f747-6a7b-4ff0-a4ed-5a254e5b3c60"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cbb80a74-c625-40a1-93c9-78440a05f987"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6f87e74b-c0cf-4eef-8eb9-4f4ed613510b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b5a4c07c-fbe0-4982-8003-b64db99651ef"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7bd07604-e1db-47fa-b640-e3018d9f13b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9519703d-5953-471e-87f2-b71c6b487aee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9e562b81-43c4-4588-b033-b5b7091edc20"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""07b83991-9efd-44eb-b9b2-addf9c2fdd2f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse;All Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9c23edb6-8940-4d29-80bd-d54a8334d32a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse;All Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f3646590-e73c-4367-af97-7be8c8dacb1b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse;All Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1beb7f07-dc7f-4f89-96d5-c9ae6c2f2117"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse;All Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8b12c43b-319d-4d41-be50-5227fb7b806d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""All Controls;Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""850838b9-f07f-451b-a46e-d46cb4c79093"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""Cursor Towards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f006e18a-6c6b-4b97-9bdd-2a944bb86c95"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""All Controls;Controller"",
                    ""action"": ""Cursor Towards"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f49fbb94-1536-4202-bdd1-48dd570f9726"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""Cursor Away"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eecd1998-f755-446b-90c2-3e69c68a9ba9"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""Cursor Away"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93177f9f-e537-42ac-a29e-317386839440"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""Yeet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9cdb86d-1fed-46fc-b6c1-31df2e4b9dfb"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""ButtonNorth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1093c124-71ad-4c4c-b2a7-7cfc2c473c87"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""ButtonSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11cf0343-b89a-40a6-bc65-d4b4d49e011d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""ButtonEast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7858019a-57fe-46cd-a06b-8225a140a7de"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;All Controls"",
                    ""action"": ""ButtonWest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
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
        },
        {
            ""name"": ""All Controls"",
            ""bindingGroup"": ""All Controls"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_CursorTowards = m_Player.FindAction("Cursor Towards", throwIfNotFound: true);
        m_Player_CursorAway = m_Player.FindAction("Cursor Away", throwIfNotFound: true);
        m_Player_Yeet = m_Player.FindAction("Yeet", throwIfNotFound: true);
        m_Player_ButtonNorth = m_Player.FindAction("ButtonNorth", throwIfNotFound: true);
        m_Player_ButtonSouth = m_Player.FindAction("ButtonSouth", throwIfNotFound: true);
        m_Player_ButtonEast = m_Player.FindAction("ButtonEast", throwIfNotFound: true);
        m_Player_ButtonWest = m_Player.FindAction("ButtonWest", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_CursorTowards;
    private readonly InputAction m_Player_CursorAway;
    private readonly InputAction m_Player_Yeet;
    private readonly InputAction m_Player_ButtonNorth;
    private readonly InputAction m_Player_ButtonSouth;
    private readonly InputAction m_Player_ButtonEast;
    private readonly InputAction m_Player_ButtonWest;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @CursorTowards => m_Wrapper.m_Player_CursorTowards;
        public InputAction @CursorAway => m_Wrapper.m_Player_CursorAway;
        public InputAction @Yeet => m_Wrapper.m_Player_Yeet;
        public InputAction @ButtonNorth => m_Wrapper.m_Player_ButtonNorth;
        public InputAction @ButtonSouth => m_Wrapper.m_Player_ButtonSouth;
        public InputAction @ButtonEast => m_Wrapper.m_Player_ButtonEast;
        public InputAction @ButtonWest => m_Wrapper.m_Player_ButtonWest;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @CursorTowards.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorTowards;
                @CursorTowards.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorTowards;
                @CursorTowards.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorTowards;
                @CursorAway.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorAway;
                @CursorAway.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorAway;
                @CursorAway.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorAway;
                @Yeet.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYeet;
                @Yeet.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYeet;
                @Yeet.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYeet;
                @ButtonNorth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonNorth;
                @ButtonNorth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonNorth;
                @ButtonNorth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonNorth;
                @ButtonSouth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonSouth;
                @ButtonSouth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonSouth;
                @ButtonSouth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonSouth;
                @ButtonEast.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonEast;
                @ButtonEast.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonEast;
                @ButtonEast.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonEast;
                @ButtonWest.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonWest;
                @ButtonWest.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonWest;
                @ButtonWest.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnButtonWest;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @CursorTowards.started += instance.OnCursorTowards;
                @CursorTowards.performed += instance.OnCursorTowards;
                @CursorTowards.canceled += instance.OnCursorTowards;
                @CursorAway.started += instance.OnCursorAway;
                @CursorAway.performed += instance.OnCursorAway;
                @CursorAway.canceled += instance.OnCursorAway;
                @Yeet.started += instance.OnYeet;
                @Yeet.performed += instance.OnYeet;
                @Yeet.canceled += instance.OnYeet;
                @ButtonNorth.started += instance.OnButtonNorth;
                @ButtonNorth.performed += instance.OnButtonNorth;
                @ButtonNorth.canceled += instance.OnButtonNorth;
                @ButtonSouth.started += instance.OnButtonSouth;
                @ButtonSouth.performed += instance.OnButtonSouth;
                @ButtonSouth.canceled += instance.OnButtonSouth;
                @ButtonEast.started += instance.OnButtonEast;
                @ButtonEast.performed += instance.OnButtonEast;
                @ButtonEast.canceled += instance.OnButtonEast;
                @ButtonWest.started += instance.OnButtonWest;
                @ButtonWest.performed += instance.OnButtonWest;
                @ButtonWest.canceled += instance.OnButtonWest;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_AllControlsSchemeIndex = -1;
    public InputControlScheme AllControlsScheme
    {
        get
        {
            if (m_AllControlsSchemeIndex == -1) m_AllControlsSchemeIndex = asset.FindControlSchemeIndex("All Controls");
            return asset.controlSchemes[m_AllControlsSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnCursorTowards(InputAction.CallbackContext context);
        void OnCursorAway(InputAction.CallbackContext context);
        void OnYeet(InputAction.CallbackContext context);
        void OnButtonNorth(InputAction.CallbackContext context);
        void OnButtonSouth(InputAction.CallbackContext context);
        void OnButtonEast(InputAction.CallbackContext context);
        void OnButtonWest(InputAction.CallbackContext context);
    }
}
