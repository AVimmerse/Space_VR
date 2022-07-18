using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameDataSO : ScriptableObject
{
    //Internal Data
    public enum Location { Space, Sun, Mercury, Venus, Earth, Lunar, Mars, Jupiter, Saturn, Uranus, Neptune };
    public delegate void GameDataEvent();
    public static event GameDataEvent OnLocationChange;
    public static event GameDataEvent OnDestinationChange;

    [Header("Location")]
    [SerializeField] private Location CurrLocation;
    [SerializeField] private Location CurrDestination;

    [Header("Data")]
    public bool FisrtTime;

    [Header("References")]
    public PlanetDataSO Sun;
    public PlanetDataSO Mercury;
    public PlanetDataSO Venus;
    public PlanetDataSO Earth;
    public PlanetDataSO Lunar;
    public PlanetDataSO Mars;
    public PlanetDataSO Jupiter;
    public PlanetDataSO Saturn;
    public PlanetDataSO Uranus;
    public PlanetDataSO Neptune;


    private void OnEnable()
    {
        PlanetDataSO.OnDataDownload += PlanetDataSO_OnDownload;
        PlanetDataSO.OnDataUpload += PlanetDataSO_OnUpload;
    }
    private void OnDisable()
    {
        PlanetDataSO.OnDataDownload -= PlanetDataSO_OnDownload;
        PlanetDataSO.OnDataUpload -= PlanetDataSO_OnUpload;
    }
    private void PlanetDataSO_OnDownload(PlanetDataSO planetData)
    {
        Debug.Log($"{planetData.name} data has been downloaded!");
    }
    private void PlanetDataSO_OnUpload(PlanetDataSO planetData)
    {
        Debug.Log($"{planetData.name} data has been uploaded!");
    }


    public void UploadDataAll()
    {
        Sun.Upload();
        Mercury.Upload();
        Venus.Upload();
        Earth.Upload();
        Lunar.Upload();
        Mars.Upload();
        Jupiter.Upload();
        Saturn.Upload();
        Uranus.Upload();
        Neptune.Upload();
    }

    public void ResetData()
    {
        CurrLocation = 0;
        CurrDestination = 0;

        Sun.ResetData();
        Mercury.ResetData();
        Venus.ResetData();
        Earth.ResetData();
        Lunar.ResetData();
        Mars.ResetData();
        Jupiter.ResetData();
        Saturn.ResetData();
        Uranus.ResetData();
        Neptune.ResetData();

        // LoadScene(Intro);

        Debug.Log($"{name} data has been reset!");
    }


    public string GetLocation() => CurrLocation.ToString();
    public void SetLocation(Location location)
    {
        CurrLocation = location;
        OnLocationChange?.Invoke();
    }

    public string GetDestination() => CurrDestination.ToString();
    public void SetDestination(Location location)
    {
        CurrDestination = location;
        OnDestinationChange?.Invoke();
    }
}
