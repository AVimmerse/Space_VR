using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// System which creats orbiting objects using Rigidbodies
/// Note:orbiting objects must have RIgidBody and to be tagged "Celestial"
/// </summary>
public class SolarSystem : MonoBehaviour
{
    readonly private float G = 100f;
    private GameObject[] celestials;

    private void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    private void Gravity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * 
                        (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

    private void InitialVelocity()
    {
        foreach (GameObject a in celestials)
        {
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }
}

// Source: https://www.youtube.com/watch?v=kUXskc76ud8&ab_channel=Coderious