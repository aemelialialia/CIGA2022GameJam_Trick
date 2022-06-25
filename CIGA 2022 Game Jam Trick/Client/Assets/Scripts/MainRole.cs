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
    public float Speed = 5;
    public int m_PlayerId = 0;
    public float JumpForce = 1;
    public float JumpInterval = 1;
    #endregion

    private ECharacterState m_State;
    private Rigidbody m_Rigidbody;
    private Transform CacheTransform;
    private InputManager Input;
    private int m_MoveX; // Variable to store the horizontal Input each frame
    private int m_MoveY; // Variable to store the vectical Input each frame
    private float m_RayLength = 1;

    private bool m_ReverseJump;
    // Start is called before the first frame update
    void Start()
    {
        m_State = ECharacterState.Idle;
        Input = InputManager.GetInstance();
        CacheTransform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_ReverseJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the moveX Variable and assign the current vertical input for this frame
        m_MoveX = (int)Input.GetAxis(m_PlayerId, InputAction.MoveX);

        // Update the moveY Variable and assign the current vertical input for this frame
        m_MoveY = (int)Input.GetAxis(m_PlayerId, InputAction.MoveY);
        bool Jump = Input.GetButtonDown(m_PlayerId, InputAction.Jump);
        if (Jump && m_State == ECharacterState.Idle)
        {
            m_Rigidbody.AddForce(new Vector3(0, m_ReverseJump? -JumpForce: JumpForce, 0));
            m_Rigidbody.velocity = Vector3.zero;
            m_State = ECharacterState.Jump;
            StartCoroutine(JumpToIdle());
        }
        UpdatePhysics();

        //Debug.DrawLine(transform.position, transform.position + new Vector3(0, -m_RayLength, 0),Color.red);
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
}
