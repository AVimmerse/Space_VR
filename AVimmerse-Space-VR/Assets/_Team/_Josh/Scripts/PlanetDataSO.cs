using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlanetDataSO : ScriptableObject
{
    [SerializeField] private bool downloaded;
    public delegate void DownloadAction(PlanetDataSO planetData);
    public static event DownloadAction OnDownload;

    [SerializeField] private bool uploaded;
    public delegate void UploadAction(PlanetDataSO planetData);
    public static event UploadAction OnUpload;

    public void Download()
    {
        if (downloaded)
        {
            Debug.Log($"{name} data already downlaoded!");
            return;
        }


        downloaded = true;
        OnDownload?.Invoke(this);
    }

    public void Upload()
    {
        if (!downloaded || uploaded)
        {
            Debug.Log($"{name} data not avalable for upload!");
            return;
        }

        uploaded = true;
        OnUpload?.Invoke(this);
    }

    
}
