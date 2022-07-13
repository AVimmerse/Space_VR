using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToMove;
    [SerializeField] private GameObject destination;

    void Start()
    {
        if (objectsToMove == null)
            Debug.LogWarning($"{name} has no objectsToMove");
        if (destination == null)
            Debug.LogWarning($"{name} has no destination");
    }

    public void MoveObjects()
    {
        foreach (GameObject obj in objectsToMove)
            obj.transform.position = destination.transform.position;
    }
}
