using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Recorder;
using UnityEditor;

public class UnityRecorderToggle : MonoBehaviour
{
    [Space]
    [Header("Will toggle from offline to online quality on Record/Stop")]

    public int OfflineQualitySettingIndex;
    public int OnlineQualitySettingIndex;
    RecorderWindow recorderWindow;
    [Header("Will always use full quality")]
    public bool AlwaysStayInFullRes;


    private RecorderWindow GetRecorderWindow()
    {
        return (RecorderWindow)EditorWindow.GetWindow(typeof(RecorderWindow));
    }

    //Works when scene view is active AND gizmos are active
    private void OnDrawGizmos()
    {
        if (recorderWindow == null)
        {
            recorderWindow = GetRecorderWindow();
        }

        if (recorderWindow != null)
        {

            if (recorderWindow.IsRecording() || AlwaysStayInFullRes)
            {
                QualitySettings.SetQualityLevel(0, true);
            }
            else
            {
               
                    QualitySettings.SetQualityLevel(OfflineQualitySettingIndex, true);
                
               
            }
        }
    }

    //Works in playmode
    private void OnGUI()
    {
        if (recorderWindow == null)
        {
            recorderWindow = GetRecorderWindow();
        }

        if (recorderWindow != null)
        {

           // Debug.Log("Recorder is not null");

            if (recorderWindow.IsRecording() || AlwaysStayInFullRes)
            {
                QualitySettings.SetQualityLevel(OnlineQualitySettingIndex, true);
            }
            else
            {
                  QualitySettings.SetQualityLevel(OfflineQualitySettingIndex, true);
                
            }
        }
    }


}
