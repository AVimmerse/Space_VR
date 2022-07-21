using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// Main ship script encapsulating functionality
/// </summary>
public class ShipController : MonoBehaviour
{
    public enum Location { Space, Sun, Mercury, Venus, Earth, Lunar, Mars, Jupiter, Saturn, Uranus, Neptune };
    
    [Header("References")]
    [SerializeField] private GameDataSO gameData;
    
    [Header("Data")]
    //[SerializeField] private string destination = "";
    [SerializeField] private Location destination;

    private void Awake()
    {
        destination = (Location)System.Enum.Parse(typeof(Location), gameData.GetDestination()); // (convert from string to ShipController.Location)
        SceneManager.LoadSceneAsync("Space_" + gameData.GetLocation(), LoadSceneMode.Additive);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        GameDataSO.OnDestinationChange += GameDataSO_OnDestinationChange;
        GameDataSO.OnLocationChange += GameDataSO_OnLocationChange;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        GameDataSO.OnDestinationChange -= GameDataSO_OnDestinationChange;
        GameDataSO.OnLocationChange -= GameDataSO_OnLocationChange;
    }

    #region Listeners
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name != "Spaceship")
        {
            Debug.Log("Setting " + arg0.name + " active scene");
            SceneManager.SetActiveScene(arg0);
        }
    }

    private void GameDataSO_OnLocationChange(GameDataSO.Location location)
    {

        // Load scene...
        Scene sctiveScene = SceneManager.GetActiveScene();
        if (sctiveScene.name != "Spaceship")
        {
            Debug.Log("unloading " + sctiveScene.name);
            SceneManager.UnloadSceneAsync(sctiveScene);
        }

        // additevely load the destination
        Debug.Log("loading " + "Space_" + destination.ToString());
        SceneManager.LoadSceneAsync("Space_" + destination.ToString(), LoadSceneMode.Additive);
    }
    private void GameDataSO_OnDestinationChange(GameDataSO.Location location)
    {

        destination = (Location)System.Enum.Parse(typeof(Location), gameData.GetDestination()); // (convert from string to ShipController.Location)

        Debug.Log(destination.ToString());

    }
    #endregion

    #region public
    // NOTE: Porbably convoluted?
    public void SetDestination(string location) => gameData.SetDestination((GameDataSO.Location)System.Enum.Parse(typeof(Location), location));
    public void SetLocation(string location) => gameData.SetLocation((GameDataSO.Location)System.Enum.Parse(typeof(Location), location));
    public void TravelToDestinationSpace() => gameData.SetLocation((GameDataSO.Location)destination);
    public void TravelToDestinationSurface() => SceneManager.LoadSceneAsync(destination.ToString());
    #endregion



    private bool IsSceneLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name.Equals(sceneName))
                return true;
        }
        return false;

    }

}