using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImage : MonoBehaviour
{
    [SerializeField]
    Image normalGravity;
    Image antiGravity;

    private string normal;
    private string anti;

    //private bool showArrow;

    // Start is called before the first frame update
    void Start()
    {
        normal = "tutorial_arrow_1.png";
        anti = "tutorial_arrow2.png";

        normalGravity.gameObject.SetActive(true);
        antiGravity.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //{
        //    DisplayIcon();
        //}
    }

    void DisplayIcon(Image img, string imgName)
    {
        Image arr = img.GetComponent<Image>();
        Sprite sp = Resources.Load("UI/" + imgName, typeof(Sprite)) as Sprite;
        arr.sprite = sp;
        img.gameObject.SetActive(true);
    }
}   
