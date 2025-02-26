using System;
using TMPro;
using UnityEngine;

public class Missionmanager : MonoBehaviour
{
    public TextMeshProUGUI missionText;
    public string missionName;
    public int missionRequire;
    public int missionNow;

    private void Update()
    {
        missionText.text = (missionName + missionNow + "/" +missionRequire).ToString();
    }

    public void BeginMission()
    {
        missionText.gameObject.SetActive(true);
        missionText.text = "";
        missionText.text = (missionName + missionNow + "/" +missionRequire).ToString();
    }
    

    public void UpdateMission()
    {
        missionNow++;

        if (missionNow >= missionRequire)
        {
            MissionEnd();
        }
    }

    public void MissionEnd()
    {
        missionText.gameObject.SetActive(false);
    }
}
