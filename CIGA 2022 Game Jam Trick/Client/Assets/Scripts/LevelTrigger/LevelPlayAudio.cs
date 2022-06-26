using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LevelPlayAudio : MonoBehaviour
{
    public AudioClip AudioClip;
    private AudioSource m_CurrentAudioSource;
    private void Start()
    {
        m_CurrentAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole role = other.transform.GetComponent<MainRole>();
            if (role && AudioClip && m_CurrentAudioSource)
            {
                m_CurrentAudioSource.PlayOneShot(AudioClip);
            }
        }
    }

}
