using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECharacterState
{
    Idle,
    Jump,
}
public class MainRole : MonoBehaviour
{
    #region Public
    public float Speed = 2;
    public float JumpForce = 300;
    public float JumpInterval = 0.8f;
    #endregion

    private ECharacterState m_State;
    private Rigidbody m_Rigidbody;
    private Transform CacheTransform;
    private InputManager Input;
    private Camera m_Camera;
    private Transform m_CamTransform;
    private int m_PlayerId = 0;

    private bool m_ReverseJump;
    // Start is called before the first frame update
    
    void Start()
    {
        m_State = ECharacterState.Idle;
        Input = InputManager.GetInstance();
        CacheTransform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_ReverseJump = false;
        m_Camera = Camera.main;
        m_CamTransform = m_Camera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        bool Jump = Input.GetButtonDown(m_PlayerId, InputAction.Jump);
        if (Jump && m_State == ECharacterState.Idle)
        {
            m_Rigidbody.AddForce(new Vector3(0, m_ReverseJump ? -JumpForce : JumpForce, 0));
            m_Rigidbody.velocity = Vector3.zero;
            m_State = ECharacterState.Jump;
            AudioManager.GetInstance().PlayCilp("jump");
            StartCoroutine(JumpToIdle());
        }
        UpdatePhysics();
        if (!IsInCamera())
        {
            Die();
        }
        //Debug.DrawLine(transform.position, transform.position + new Vector3(0, -m_RayLength, 0),Color.red);
    }


    private bool IsInCamera()
    {
        Vector3 pos = CacheTransform.position;
        Vector2 viewPos = m_Camera.WorldToViewportPoint(pos);

        //判断物体是否在相机前面  
        Vector3 dir = (pos - m_CamTransform.position).normalized;
        float dot = Vector3.Dot(m_CamTransform.forward, dir);

        if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetReverseJump(bool active)
    {
        m_ReverseJump = active;
    }

    IEnumerator JumpToIdle()
    {
        yield return new WaitForSeconds(JumpInterval);
        m_State = ECharacterState.Idle;
    }

    void UpdatePhysics()
    {
        Vector3 move = Vector3.right * Speed * Time.deltaTime;
        CacheTransform.position = CacheTransform.position + move;
    }

    private void Die()
    {
        GameManager.GetInstance().DiePos = transform.position;
        AudioManager.GetInstance().PlayCilp("dead");

        GameManager.GetInstance().NotifyDie();
        GameObject.Destroy(gameObject);
    }
}
