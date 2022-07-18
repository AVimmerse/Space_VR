using UnityEngine;
using UnityEngine.Events;

public class Event_OnEnable : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;
    private void OnEnable()
    {
        unityEvent.Invoke();    
    }
}
