using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager m_Instance;
    private AudioSource[] m_AudioSource;
    private string m_DefaultPath = "Audio/";
    public static AudioManager GetInstance()
    {
        return m_Instance;
    }
    private void Awake()
    {
        m_Instance = this;
        m_AudioSource = GetComponents<AudioSource>();
    }


    public void PlayCilp(string path)
    {
        if (m_AudioSource!=null)
        {
            AudioClip clip = Resources.Load(m_DefaultPath + path) as AudioClip;

            for (int i = 0; i < m_AudioSource.Length; i++)
            {
                if (m_AudioSource[i].isPlaying)
                {
                    continue;
                }
                m_AudioSource[i].PlayOneShot(clip);
                break;
            }
        }
    }

}
