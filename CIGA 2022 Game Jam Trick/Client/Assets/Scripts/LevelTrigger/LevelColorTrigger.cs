using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColorTrigger : MonoBehaviour
{
    GameObject m_BackGround;

    private void Start()
    {
        m_BackGround = GameObject.Find("PureBackGround");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            MainRole mainRole = other.transform.GetComponent<MainRole>();
            if (mainRole)
            {
                if (m_BackGround)
                {
                    MeshRenderer thisMesh = GetComponent<MeshRenderer>();
                    if (thisMesh != null)
                    {
                        Color color = Color.white;

                        switch (gameObject.tag)
                        {
                            case "Blue":
                                color = new Color(47/255f, 93/255f, 178/255f);
                                break;
                            case "Red":
                                color = new Color(1, 0, 0);
                                break;
                            case "Yellow":
                                color = new Color(255/255f, 184/255f, 52/255f);
                                break;
                        }

                        Renderer mesh = m_BackGround.GetComponent<Renderer>();
                        if (mesh != null)
                        {
                            mesh.material.SetColor("_Color", color);
                            GameManager.GetInstance().CurrentPureBGColor = color;
                            GameObject.Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
