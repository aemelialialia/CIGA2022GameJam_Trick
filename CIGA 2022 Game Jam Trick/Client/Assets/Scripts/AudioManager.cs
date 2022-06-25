using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager m_Instance;
    private AudioSource m_AudioSource;
    private string m_DefaultPath = "Audio/";
    public static AudioManager GetInstance()
    {
        return m_Instance;
    }
    private void Awake()
    {
        m_Instance = this;
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void PlayCilp(AudioClip clip)
    {
        if (m_AudioSource && clip)
        {
            m_AudioSource.clip = clip;
            m_AudioSource.Play();
        }
    }
    public void PlayCilp(string path)
    {
        if (m_AudioSource)
        {
            AudioClip clip = Resources.Load(m_DefaultPath + path) as AudioClip;

            m_AudioSource.clip = clip;
            m_AudioSource.Play();
        }
    }

}
