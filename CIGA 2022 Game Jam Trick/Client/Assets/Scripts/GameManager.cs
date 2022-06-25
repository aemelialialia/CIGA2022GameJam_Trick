using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int DeathCount = 0;

    private static GameManager m_Instance;
    private MainRole m_MainRole;
    private int m_PlayerId = 0;
    private InputManager Input;
    public static GameManager GetInstance()
    {
        return m_Instance;
    }
    private void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Input = InputManager.GetInstance();
        CreateRole(0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MainRole == null)
        {
            if(Input.GetButtonDown(m_PlayerId, InputAction.Reborn))
            {
                CreateRole(0.05f);
            }
        }
    }

    public void CreateRole(float rebornX)
    {
        GameObject go = Resources.Load("MainRole") as GameObject;
        if (go != null)
        {
            go = GameObject.Instantiate(go);
            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(rebornX, 0.6f, 0));
            go.transform.position = new Vector3(pos.x,pos.y,0);

            MainRole mainRole = go.GetComponent<MainRole>();
            if (mainRole != null)
            {
                CameraController.GetInstance().MainRole = mainRole;
            }
        }
    }
}
