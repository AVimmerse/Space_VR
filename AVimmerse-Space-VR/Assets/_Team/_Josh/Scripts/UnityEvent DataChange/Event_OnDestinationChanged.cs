using UnityEngine;
using UnityEngine.Events;

public class Event_OnDestinationChanged : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    private void OnEnable()
    {
        GameDataSO.OnDestinationChange += GameDataSO_OnDestinationChange;
    }
    private void OnDisable()
    {
        GameDataSO.OnDestinationChange -= GameDataSO_OnDestinationChange;
    }
    private void GameDataSO_OnDestinationChange(GameDataSO.Location location) => events?.Invoke();
}
