using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_test: MonoBehaviour
{
    //碰障碍物音效
    public static AudioSource audioSource;
    public static AudioClip touchobstacle;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        touchobstacle = Resources.Load<AudioClip>("DM-CGS-32");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaytouchobstacleClip()
    {
        audioSource.PlayOneShot(touchobstacle);
    }
}
