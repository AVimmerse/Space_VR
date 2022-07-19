using UnityEngine;
using UnityEngine.Events;
public class Event_OnDataUploaded : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    private void OnEnable()
    {
        PlanetDataSO.OnDataUpload += PlanetDataSO_OnDataUpload;
    }
    private void OnDisable()
    {
        PlanetDataSO.OnDataUpload -= PlanetDataSO_OnDataUpload;
    }

    private void PlanetDataSO_OnDataUpload(PlanetDataSO planetData) => events?.Invoke();
}
