using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadedDataManager : MonoBehaviour
{
    [Header("Refereces")]
    [SerializeField] private GameDataSO gameData;

    [Header("Reference Planets")]
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject mercury;
    [SerializeField] private GameObject venus;
    [SerializeField] private GameObject earth;
    [SerializeField] private GameObject theMoon;
    [SerializeField] private GameObject mars;
    [SerializeField] private GameObject jupiter;
    [SerializeField] private GameObject saturn;
    [SerializeField] private GameObject uranus;
    [SerializeField] private GameObject neptune;

    void Start()
    {
        if (gameData == null)
            Debug.LogWarning($"{name} gameData not set!");

        // Ensure already uploaded register
        foreach (string s in gameData.GetAllUploaded())
        {
            SinglePlanetUpload(s);
        }

    }
    private void OnEnable()
    {
        PlanetDataSO.OnDataUpload += PlanetDataSO_OnDataUpload;
    }
    private void OnDestroy()
    {
        PlanetDataSO.OnDataUpload -= PlanetDataSO_OnDataUpload;
    }


    private void PlanetDataSO_OnDataUpload(PlanetDataSO planetData) => SinglePlanetUpload(planetData.name);

    private void SinglePlanetUpload(string planetName)
    {
        switch (planetName)
        {
            case "Sun":
                sun.SetActive(true);
                break;
            case "Mercury":
                mercury.SetActive(true);
                break;
            case "Venus":
                venus.SetActive(true);
                break;
            case "Earth":
                earth.SetActive(true);
                break;
            case "Lunar":
                theMoon.SetActive(true);
                break;
            case "Mars":
                mars.SetActive(true);
                break;
            case "Jupiter":
                jupiter.SetActive(true);
                break;
            case "Saturn":
                saturn.SetActive(true);
                break;
            case "Uranus":
                uranus.SetActive(true);
                break;
            case "Neptune":
                neptune.SetActive(true);
                break;
            default:
                Debug.LogWarning($"{name} - Destination '{planetName}' not registered as avaliable");
                break;
        }
    }
}

// If a planet is data uploaded
