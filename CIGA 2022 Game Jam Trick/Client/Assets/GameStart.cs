using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private bool canFade;
    //private Image img;
    private float fadeSpeed;
    private CanvasGroup group;
    private int currentScene;
    

    // Start is called before the first frame update
    void Start()
    {
        canFade = false;
        fadeSpeed = 5.0f;
        group = this.GetComponent<CanvasGroup>();

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene != 0)
        {
            ContinueGame();
        }
        //checking for SPACE input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space bar pressed.");
            canFade = true;
        }

        if (canFade == true && group.alpha != 0.0f)
        {
            group.alpha = Mathf.Lerp(group.alpha, 0.0f, fadeSpeed * Time.deltaTime);
            //Debug.Log("Fading");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        void ContinueGame()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //Debug.Log("Space bar pressed.");
                canFade = true;
            }

            if (canFade == true && group.alpha != 0.0f)
            {
                group.alpha = Mathf.Lerp(group.alpha, 0.0f, fadeSpeed * Time.deltaTime);
                //Debug.Log("Fading");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
