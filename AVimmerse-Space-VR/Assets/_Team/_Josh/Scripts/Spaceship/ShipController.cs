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
    [SerializeField] private TMP_Text destinationText;
    [SerializeField] private DestinationDisplay destinationDisplay;
    [SerializeField] private GameDataSO gameData;
    
    [Header("Data")]
    //[SerializeField] private string destination = "";
    [SerializeField] private Location destination;


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

        //print($"OnSceneLoaded '{arg0.name}'");
        //
        //SceneManager.SetActiveScene(arg0);
        //
        //// Ensure that only the spaceship and destination are loaded.
        //for (int i = 0; i < SceneManager.sceneCount; i++)
        //{
        //    Scene scene = SceneManager.GetSceneAt(i);
        //
        //    if (!scene.name.Equals("Spaceship") && scene != arg0) // (not Spaceship and not last the loaded)
        //        SceneManager.UnloadSceneAsync(scene);
        //}
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
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Space_" + destination.ToString()));
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

    //{
    //    gameData.SetDestination((GameDataSO.Location)location);
    //
    //    updateDestinationText();
    //    destinationDisplay.SetNewActiveDisplay(destination);
    //}

    //public void TravelToPlanetSpace()
    //{
    //    if (destinationDisplay == null)
    //    {
    //        // Play error sound
    //        return;
    //    }
    //
    //
    //    if (IsSceneLoaded("Space_" + destination))
    //    {
    //        // Player error sound
    //        return;
    //    }
    //
    //    // Fade skybox to black?
    //    // Play charging sound
    //    // Start animation
    //    // Play wharp sound
    //    // Fade screen to black
    //
    //    SceneManager.LoadSceneAsync("Space_" + destination, LoadSceneMode.Additive);
    //
    //}

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

    private void updateDestinationText() => destinationText.text = "Destination: '" + destination + "'";

}