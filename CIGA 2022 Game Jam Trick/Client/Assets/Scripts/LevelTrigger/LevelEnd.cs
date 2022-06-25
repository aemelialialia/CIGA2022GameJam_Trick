using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole role = other.transform.GetComponent<MainRole>();
            if (role)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
