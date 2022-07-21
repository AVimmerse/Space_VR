using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DownloadedDataManager : MonoBehaviour
{
    [SerializeField] private TMP_Text downloadStatus;
    [SerializeField] private UnityEvent events;
    private void OnEnable()
    {
        PlanetDataSO.OnDataDownload += PlanetDataSO_OnDataDownload;
    }
    private void OnDisable()
    {
        PlanetDataSO.OnDataDownload -= PlanetDataSO_OnDataDownload;
    }
    private void PlanetDataSO_OnDataDownload(PlanetDataSO planetData)
    {
        downloadStatus.text = $"{planetData.name} data downloaded";
        events?.Invoke();
    }
}
    