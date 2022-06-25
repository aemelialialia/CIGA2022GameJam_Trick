using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReverseJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole role = other.transform.GetComponent<MainRole>();
            if (role)
            {
                role.SetReverseJump(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole role = other.transform.GetComponent<MainRole>();
            if (role)
            {
                role.SetReverseJump(false);
            }
        }
    }
}
