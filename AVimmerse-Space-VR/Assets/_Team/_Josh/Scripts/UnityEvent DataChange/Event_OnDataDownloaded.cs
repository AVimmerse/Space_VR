using UnityEngine;
using UnityEngine.Events;
public class Event_OnDataDownloaded : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    private void OnEnable()
    {
        PlanetDataSO.OnDataDownload += PlanetDataSO_OnDataDownload;
    }
    private void OnDisable()
    {
        PlanetDataSO.OnDataDownload -= PlanetDataSO_OnDataDownload;
    }

    private void PlanetDataSO_OnDataDownload(PlanetDataSO planetData) => events?.Invoke();

}
