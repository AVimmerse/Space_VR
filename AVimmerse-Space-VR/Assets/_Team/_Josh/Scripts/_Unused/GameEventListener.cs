using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeReference]
    public GameEventSO GameEvent;
    public UnityEvent Response;

    private void OnEnable()
    { GameEvent.RegisterListener(this); }

    private void OnDisable()
    { GameEvent.UnregisterListener(this); }

    public void OnEventRaised()
    { Response.Invoke(); }
}
