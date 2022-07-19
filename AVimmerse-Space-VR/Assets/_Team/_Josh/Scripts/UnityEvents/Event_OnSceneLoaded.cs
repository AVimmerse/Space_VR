using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Event_OnSceneLoaded : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) => events?.Invoke();
}
