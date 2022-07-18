using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationDisplay : MonoBehaviour
{
    
    // NOTE:
    // Probabably better to instead save memory and search for the destination in children each time.
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

    private void OnEnable()
    {
        GameDataSO.OnDestinationChange += GameDataSO_OnDestinationChange;
        GameDataSO.OnLocationChange += GameDataSO_OnLocationChange;
    }

    private void OnDisable()
    {
        GameDataSO.OnDestinationChange -= GameDataSO_OnDestinationChange;
        GameDataSO.OnLocationChange -= GameDataSO_OnLocationChange;
    }

    #region Listeners
    private void GameDataSO_OnLocationChange()
    {
        throw new System.NotImplementedException();

    }
    private void GameDataSO_OnDestinationChange()
    {
        throw new System.NotImplementedException();
    }
    #endregion


    private void DisableAllDisplays()
    {
        foreach(Transform child in transform)
            child.gameObject.SetActive(false); 
    }

    public void SetNewActiveDisplay(string destination)
    {
        DisableAllDisplays();
        switch (destination)
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
                Debug.LogWarning($"{name} - Destination '{destination}' not registered as avaliable display");
                break;

        }
    }
}
