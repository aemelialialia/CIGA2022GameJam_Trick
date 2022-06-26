using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacle : MonoBehaviour
{
    public float DownForce = 5;
    private GameObject m_PureGoBg;
    private Color m_CurrentColor;
    private void Start()
    {
        m_PureGoBg = GameObject.Find("PureBackGround");
        GetCurrentColor();
    }

    private void GetCurrentColor()
    {
        MeshRenderer thisMesh = GetComponent<MeshRenderer>();
        if (thisMesh != null)
        {
            m_CurrentColor = thisMesh.sharedMaterial.GetColor("_Color");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            if(m_CurrentColor == GameManager.GetInstance().CurrentPureBGColor)
            {
                return;
            }
            Rigidbody rigidbody = other.transform.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                if (rigidbody.velocity.y > 0)
                {
                    rigidbody.velocity = Vector3.zero;
                }
                rigidbody.velocity += new Vector3(0, -DownForce, 0);
                Destroy(gameObject);
            }
        }
    }

}
