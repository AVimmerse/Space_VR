using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalar : MonoBehaviour
{
    public void ScaleBy(float scaleChange)
    {
        transform.localScale = new Vector3(transform.localScale.x + scaleChange, transform.localScale.x + scaleChange, transform.localScale.x + scaleChange);
    }
}