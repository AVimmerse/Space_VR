using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DownloadedDataManager : MonoBehaviour
{
    [SerializeField] private TMP_Text downloadStatus;

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
    }
}
    