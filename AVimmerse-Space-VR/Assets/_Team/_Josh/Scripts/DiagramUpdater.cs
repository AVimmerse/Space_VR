using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagramUpdater : MonoBehaviour
{
    private void OnEnable()
    {
        PlanetDataSO.OnDataUpload += PlanetDataSO_OnDataUpload;
    }
    private void OnDisable()
    {
        PlanetDataSO.OnDataUpload -= PlanetDataSO_OnDataUpload;
    }


    private void PlanetDataSO_OnDataUpload(PlanetDataSO planetData)
    {
        // TO DO.

        // 
        // find the planet in the diagram of planetData.name and enable it.
    }
}
