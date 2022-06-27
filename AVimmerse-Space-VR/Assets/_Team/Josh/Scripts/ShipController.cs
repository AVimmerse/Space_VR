using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Main ship script encapsulating functionality
/// </summary>
public class ShipController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text destinationText;

    [Header("Data")]
    [SerializeField] private string destination = "";

    #region public
    public string GetDestination() { return destination; }
    public void SetDestination(string newDestination)
    {
        destination = newDestination;
        updateDestinationText();
    }

    public void LoadSceneDestination() => UnityEngine.SceneManagement.SceneManager.LoadScene(destination);
    #endregion


    private void updateDestinationText() => destinationText.text = "Destination: '" + destination +"'";
}
