using UnityEngine;
using TMPro;
public class DestinationText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameDataSO gameData;

    private void Awake()
    {
        SetDestinationText(gameData.GetDestination());
    }
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
        SetDestinationText(location.ToString());
    }

    private void SetDestinationText(string location)
    {
            text.text = $"Destination: {location}";
    }
}
