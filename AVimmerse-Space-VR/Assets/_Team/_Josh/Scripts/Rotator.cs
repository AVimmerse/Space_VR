using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float xAngle;
    [SerializeField] private float yAngle;
    [SerializeField] private float zAngle;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);       
    }
}
