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
    public ECharacterState m_State;
    private Rigidbody m_Rigidbody;
    private Transform CacheTransform;
    public float Speed = 5;
    public int m_PlayerId = 0;
    public float JumpForce = 5;
    private InputManager Input;
    public float m_MoveX; // Variable to store the horizontal Input each frame
    public float m_MoveY; // Variable to store the vectical Input each frame
    private int GroundLayer;
    private float m_RayLength = 1;
    // Start is called before the first frame update
    
    // force to right, moveX ++
    public float RightForce = 10;
    void Start()
    {
        m_State = ECharacterState.Idle;
        Input = InputManager.GetInstance();
        CacheTransform = transform;
        m_Rigidbody = GetComponent<Rigidbody>();
        GroundLayer = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        // Update the moveX Variable and assign the current vertical input for this frame
        
        //m_MoveX = (int)Input.GetAxis(m_PlayerId, InputAction.MoveX);
        m_MoveX = Input.GetAxis(m_PlayerId, InputAction.MoveX);
        m_MoveX = (float)(m_MoveY + (RightForce * 0.1));

        // Update the moveY Variable and assign the current vertical input for this frame
        m_MoveY = (int)Input.GetAxis(m_PlayerId, InputAction.MoveY);
        bool Jump = Input.GetButtonDown(m_PlayerId, InputAction.Jump);
        if (Jump && m_State == ECharacterState.Idle)
        {
            m_Rigidbody.AddForce(new Vector3(0, JumpForce, 0));
            m_State = ECharacterState.Jump;
            StartCoroutine(GroundRayCastCheck());
        }
        UpdatePhysics();

        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -m_RayLength, 0),Color.red);
    }

    IEnumerator GroundRayCastCheck()
    {
        yield return new WaitForSeconds(1);
        while (m_State == ECharacterState.Jump)
        {
            if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), m_RayLength))
            {
                m_State = ECharacterState.Idle;
            }
            yield return 0;
        }
    }




    void UpdatePhysics()
    {
        Vector3 move = new Vector3(m_MoveX,0, m_MoveY) * Speed * Time.deltaTime;
        CacheTransform.position = CacheTransform.position + move;
    }
}
