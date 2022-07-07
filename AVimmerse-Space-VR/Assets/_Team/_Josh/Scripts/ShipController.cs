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

    [Header("Data")]
    [SerializeField] private string destination = "";

    private void Awake()
    {
        
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    #region public
    public string GetDestination() { return destination; }
    public void SetDestination(string newDestination)
    {
        destination = newDestination;
        updateDestinationText();
    }

    public void LoadSceneDestination() => SceneManager.LoadScene(destination);


    public void TravelToPlanetSpace()
    {
        SceneManager.LoadSceneAsync("Space_" + destination, LoadSceneMode.Additive);
        
    }

    public void TravelToPlanetSurface()
    {

    }
    #endregion


    private void updateDestinationText() => destinationText.text = "Destination: '" + destination +"'";


    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        print("OnSceneLoaded");

        // When a scene loads...
        // ensure that only the spaceship and destination are loaded.

        // VERSION 1 - LONG
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (!SceneManager.GetSceneAt(i).name.Contains(destination))
            {
                print($"scene {SceneManager.GetSceneAt(i).name} doesnt contain destination");
                SceneManager.UnloadSceneAsync(i);
            }
            else if (SceneManager.GetSceneAt(i).name.Contains(destination))
            {
                print($"scene {SceneManager.GetSceneAt(i).name} contains destination");
                SceneManager.SetActiveScene(SceneManager.GetSceneAt(i));
            }
        }

        // VERSION 2 - User arg0


    }
}
