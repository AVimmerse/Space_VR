using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataListener : MonoBehaviour
{
    [SerializeReference] public PlanetDataSO Mercury;
    [SerializeReference] public PlanetDataSO Venus;

    public void UploadData(PlanetDataSO planetData)
    {
        planetData.Upload();
    }
}
