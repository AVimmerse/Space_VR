using UnityEngine;
using TMPro;
public class DestinationText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void OnEnable()
    {
        GameDataSO.OnDestinationChange += GameDataSO_OnDestinationChange;
    }
    private void OnDisable()
    {
        GameDataSO.OnDestinationChange -= GameDataSO_OnDestinationChange;

    }

    private void GameDataSO_OnDestinationChange(GameDataSO.Location location)
    {
        text.text = $"Destination: {location}";
    }
}
