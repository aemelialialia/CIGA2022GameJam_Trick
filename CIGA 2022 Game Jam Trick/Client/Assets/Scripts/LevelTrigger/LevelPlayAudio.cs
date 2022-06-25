using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlayAudio : MonoBehaviour
{
    public AudioClip AudioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole role = other.transform.GetComponent<MainRole>();
            if (role && AudioClip)
            {
                AudioManager.GetInstance().PlayCilp(AudioClip);
            }
        }
    }
}
