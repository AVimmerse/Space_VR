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
    [Header("References")]
    [SerializeField] private TMP_Text destinationText;
    [SerializeField] private DestinationDisplay destinationDisplay;

    [Header("Data")]
    [SerializeField] private string destination = "";

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    #region public
    public string GetDestination() { return destination; }
    public void SetDestination(string newDestination)
    {
        destination = newDestination;

        updateDestinationText();
        destinationDisplay.SetNewActiveDisplay(destination);
    }

    //public void LoadSceneDestination() => SceneManager.LoadScene(destination);


    public void TravelToPlanetSpace()
    {
        if (destinationDisplay == null)
        {
            // Play error sound
            return;
        }


        if (IsSceneLoaded("Space_" + destination))
        {
            // Player error sound
            return;
        }

        // Fade skybox to black?
        // Play charging sound
        // Start animation
        // Play wharp sound
        // Fade screen to black

        SceneManager.LoadSceneAsync("Space_" + destination, LoadSceneMode.Additive);

    }

    public void TravelToPlanetSurface()
    {

    }
    #endregion


    private void updateDestinationText() => destinationText.text = "Destination: '" + destination + "'";


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        print($"OnSceneLoaded '{arg0.name}'");

        SceneManager.SetActiveScene(arg0);
        
        // Ensure that only the spaceship and destination are loaded.
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (!scene.name.Equals("Spaceship") && scene != arg0) // (not Spaceship and not last the loaded)
                SceneManager.UnloadSceneAsync(scene);
        }
    }

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