using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager GetInstance()
    {
        return m_Instance;
    }
    static InputManager m_Instance;
    [SerializeField]
    private string _playerAxisPrefix = "Player";

    [SerializeField]
    private int _maxNumberOfPlayers = 1;

    [Header("Unity Axis Mapping")]
    [SerializeField]
    private string _useItem = "UseItem";

    [SerializeField]
    private string _putItem = "PutItem";

    [SerializeField]
    private string _jumpAxis = "Jump";

    [SerializeField]
    private string _interactAxis = "Interact";

    [SerializeField]
    private string _moveXAxis = "Horizontal";

    [SerializeField]
    private string _moveYAxis = "Vertical";

    private Dictionary<int, string>[] _actions;

    private bool m_Active;
    private void Awake()
    {
        m_Instance = this;
    }
    public void Start()
    {
        _actions = new Dictionary<int, string>[_maxNumberOfPlayers];

        for (int i = 0; i < _maxNumberOfPlayers; i++)
        {
            Dictionary<int, string> playerActions = new Dictionary<int, string>();
            _actions[i] = playerActions;
            string prefix = !string.IsNullOrEmpty(_playerAxisPrefix) ? _playerAxisPrefix + i : string.Empty;
            AddAction(InputAction.Jump, prefix + _jumpAxis, playerActions);
            AddAction(InputAction.MoveX, prefix + _moveXAxis, playerActions);
            AddAction(InputAction.MoveY, prefix + _moveYAxis, playerActions);
            //Debug.Log (prefix);
        }
        m_Active = true;
    }

    public void SetActive(bool active)
    {
        m_Active = active;
    }

    private static void AddAction(InputAction action, string actionName, Dictionary<int, string> actions)
    {
        if (string.IsNullOrEmpty(actionName))
        {
            return;
        }

        actions.Add((int)action, actionName);
    }

    public bool GetButton(int playerId, InputAction action)
    {
        if (!m_Active)
        {
            return false;
        }
        bool value = Input.GetButton(_actions[playerId][(int)action]);
        return value;
    }

    public bool GetButtonDown(int playerId, InputAction action)
    {
        if (!m_Active)
        {
            return false;
        }
        bool value = Input.GetButtonDown(_actions[playerId][(int)action]);
        return value;
    }

    public bool GetButtonUp(int playerId, InputAction action)
    {
        if (!m_Active)
        {
            return false;
        }
        bool value = Input.GetButtonUp(_actions[playerId][(int)action]);
        return value;
    }

    public float GetAxis(int playerId, InputAction action)
    {
        if (!m_Active)
        {
            return 0;
        }
        float value = Input.GetAxisRaw(_actions[playerId][(int)action]);
        return value;
    }
}
