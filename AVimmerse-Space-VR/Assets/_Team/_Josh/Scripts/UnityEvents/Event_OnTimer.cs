using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Event_OnTimer : MonoBehaviour
{
    [SerializeField] private float timerDuration;
    [SerializeField] private UnityEvent events;

    private void OnEnable() => StartCoroutine(nameof(BeginTimer));

    private IEnumerator BeginTimer()
    {
        yield return new WaitForSeconds(timerDuration);
        events.Invoke();

        
    }
}