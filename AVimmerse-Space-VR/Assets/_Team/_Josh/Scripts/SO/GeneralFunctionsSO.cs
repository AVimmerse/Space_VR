using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GeneralFunctionsSO : ScriptableObject
{
    public void LoadScene(string scene) => UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
}
