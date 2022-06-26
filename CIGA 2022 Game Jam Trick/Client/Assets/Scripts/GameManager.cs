using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int DeathCount = 0;
    public Color CurrentPureBGColor = Color.black;

    private static GameManager m_Instance;
    public MainRole m_MainRole;
    public Vector3 DiePos;
    private Vector3 oriPos;
    private int m_PlayerId = 0;
    private InputManager Input;

    public MainView MainView;

    public RebornView RebornView;

    public static GameManager GetInstance()
    {
        return m_Instance;
    }
    private void Awake()
    {
        m_Instance = this;
        CurrentPureBGColor = Color.black;
    }
    // Start is called before the first frame update
    void Start()
    {
        Input = InputManager.GetInstance();
        if (m_MainRole != null)
        {
            oriPos = m_MainRole.transform.position;
        }
        //CreateRole(0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MainRole == null)
        {
            if(Input.GetButtonDown(m_PlayerId, InputAction.Reborn))
            {
                CreateRole();
                if (RebornView != null)
                {
                    RebornView.gameObject.SetActive(false);
                }
            }
        }
    }

    public float GetDieDistance()
    {
        return DiePos.x - oriPos.x;
    }

    public float GetCurrentDistance()
    {
        if (m_MainRole != null)
        {
            return m_MainRole.transform.position.x - oriPos.x;
        }
        return 0;
    }

    public void NotifyDie()
    {
        DeathCount++;
        if (RebornView != null)
        {
            RebornView.RefreshText();
            RebornView.gameObject.SetActive(true);
        }
    }

    public void OnEnterAntiGravityArea()
    {
        if (MainView)
        {
            MainView.ReverseSpace();
        }
    }
    public void OnExitAntiGravityArea()
    {
        if (MainView)
        {
            MainView.ReverseSpace();
        }
    }
    public void CreateRole()
    {
        GameObject go = Resources.Load("MainRole") as GameObject;
        if (go != null)
        {
            go = GameObject.Instantiate(go);
            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.6f, 0));
            go.transform.position = new Vector3(DiePos.x - 0.5f, pos.y,0);

            MainRole mainRole = go.GetComponent<MainRole>();
            if (mainRole != null)
            {
                CameraController.GetInstance().MainRole = mainRole;
            }
        }
    }
}
