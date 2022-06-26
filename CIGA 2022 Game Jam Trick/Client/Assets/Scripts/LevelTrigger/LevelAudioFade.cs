using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LevelAudioFade : MonoBehaviour
{

    public float MaxDistance;
    public float MinDistance;

    private AudioSource m_AudioSource;
    private MainRole mainRole;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainRole == null)
        {
            mainRole = GameManager.GetInstance().m_MainRole;
        }
        if (mainRole != null)
        {
            float distance = Vector3.Distance(transform.position, mainRole.transform.position);
            float t = (distance - MinDistance) / (MaxDistance - MinDistance);
            float value = Mathf.Lerp(0, 1, 1-t);
            m_AudioSource.volume = value;

        }
    }
}
