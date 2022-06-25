using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacle : MonoBehaviour
{
    public float DownForce = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.transform != null)
        {
            Rigidbody rigidbody = other.transform.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                if (rigidbody.velocity.y > 0)
                {
                    rigidbody.velocity = Vector3.zero;
                }
                rigidbody.velocity += new Vector3(0, -DownForce, 0);
                Destroy(gameObject);
            }
        }
    }
}
