using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static CameraController m_Instance;
    public static CameraController GetInstance()
    {
        return m_Instance;
    }
    public MainRole MainRole;
    private Vector3 m_CacheCameraPos;
    private void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_CacheCameraPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 rolePos = MainRole.transform.position;
        //  Vector3 targetPos = new Vector3(rolePos.x + 4, m_CacheCameraPos.y, m_CacheCameraPos.z);
        //  this.transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime * 3);
        transform.position = new Vector3(rolePos.x + 4, m_CacheCameraPos.y, m_CacheCameraPos.z);
    }
}
