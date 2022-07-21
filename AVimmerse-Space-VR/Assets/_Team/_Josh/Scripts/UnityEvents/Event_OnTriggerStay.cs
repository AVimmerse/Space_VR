using UnityEngine;
using UnityEngine.Events;

public class Event_OnTriggerStay : MonoBehaviour
{
    [SerializeField] private string colliderTagRequirement = "";
    [SerializeField] private UnityEvent events;

    private void OnTriggerStay(Collider other)
    {
        if (colliderTagRequirement == "" || other.CompareTag(colliderTagRequirement))
            events.Invoke();
    }
}
