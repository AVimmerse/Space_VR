using UnityEngine;
using UnityEngine.Events;

public class Event_OnLocationChanged : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    private void OnEnable()
    {
        GameDataSO.OnLocationChange += GameDataSO_OnLocationChange;
    }
    private void OnDisable()
    {
        GameDataSO.OnLocationChange -= GameDataSO_OnLocationChange;
    }
    private void GameDataSO_OnLocationChange(GameDataSO.Location location) => events?.Invoke();
}
