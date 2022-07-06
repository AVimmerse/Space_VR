using UnityEngine;
using UnityEngine.Events;
public class Event_OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string colliderTagRequirement = "";
    [SerializeField] private UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (colliderTagRequirement == "" || colliderTagRequirement == other.tag)
            onTriggerEnter.Invoke();
    }
}
