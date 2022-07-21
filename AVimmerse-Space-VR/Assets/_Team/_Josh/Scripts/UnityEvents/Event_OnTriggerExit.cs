using UnityEngine;
using UnityEngine.Events;

public class Event_OnTriggerExit : MonoBehaviour
{
    [SerializeField] private string colliderTagRequirement = "";
    [SerializeField] private UnityEvent events;

    private void OnTriggerExit(Collider other)
    {
        if (colliderTagRequirement == "" || other.CompareTag(colliderTagRequirement))
            events.Invoke();
    }
}
