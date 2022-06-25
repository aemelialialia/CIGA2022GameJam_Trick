using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColorTrigger : MonoBehaviour
{
    GameObject m_BackGround;

    private void Start()
    {
        m_BackGround = GameObject.Find("PureBackGround");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole mainRole = other.transform.GetComponent<MainRole>();
            if (mainRole)
            {
                if (m_BackGround)
                {
                    MeshRenderer thisMesh = GetComponent<MeshRenderer>();
                    if (thisMesh != null)
                    {
                        Color color = thisMesh.sharedMaterial.GetColor("_Color");
                        MeshRenderer mesh = m_BackGround.GetComponent<MeshRenderer>();
                        if (mesh != null)
                        {
                            mesh.material.SetColor("_Color", color);
                            GameManager.GetInstance().CurrentPureBGColor = color;
                            GameObject.Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
