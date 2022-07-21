using UnityEngine;
using UnityEngine.Events;

public class Event_OnAwake : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;
    private void Awake()
    {
        unityEvent.Invoke();
    }
}
