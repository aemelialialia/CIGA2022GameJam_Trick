using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetObjActive : MonoBehaviour
{
    private bool m_IsTrigger;
    public GameObject target;
    public float DestroyDelay = 2;
    private float m_Tick;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole role = other.transform.GetComponent<MainRole>();
            if (role && target)
            {
                target.SetActive(true);
                m_IsTrigger = true;
            }
        }
    }

    private void Update()
    {
        if (m_IsTrigger)
        {
            m_Tick += Time.deltaTime;
            if(m_Tick>= DestroyDelay)
            {
                GameObject.Destroy(target);
            }
        }
    }
}
