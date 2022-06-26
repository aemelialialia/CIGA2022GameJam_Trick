using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAntiGravity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole mainRole = other.transform.GetComponent<MainRole>();
            if (mainRole)
            {
                Physics.gravity = new Vector3(0, 9.8f, 0);
                GameManager.GetInstance().OnEnterAntiGravityArea();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole mainRole = other.transform.GetComponent<MainRole>();
            if (mainRole)
            {
                Physics.gravity = new Vector3(0, -9.8f, 0);
                GameManager.GetInstance().OnExitAntiGravityArea();
            }
        }
    }
}
