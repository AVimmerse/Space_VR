using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlanetDataSO : ScriptableObject
{
    [SerializeField] private bool downloaded;
    [SerializeField] private bool uploaded;
    
    public delegate void PlanetData(PlanetDataSO planetData);
    public static event PlanetData OnDataDownload;
    public static event PlanetData OnDataUpload;
    
    public void Download()
    {
        if (downloaded)
        {
            //Debug.Log($"{name} data already downlaoded!");
            return;
        }

        //Debug.Log($"{name} data downlaoded!");
        downloaded = true;
        OnDataDownload?.Invoke(this);
    }

    public void Upload()
    {
        if (!downloaded || uploaded)
        {
            //Debug.Log($"{name} data not avalable for upload!");
            return;
        }

        //Debug.Log($"{name} data uploaded!");
        uploaded = true;
        OnDataUpload?.Invoke(this);
    }

    public void ResetData()
    {
        downloaded = false;
        uploaded = false;
    }

    public bool IsDownloaded() => downloaded;
    public bool IsUploaded() => uploaded;
}
