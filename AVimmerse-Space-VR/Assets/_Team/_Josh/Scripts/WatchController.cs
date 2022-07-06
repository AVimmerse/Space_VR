using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchController : MonoBehaviour
{
   public void LoadScene(string scene) => UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
}
