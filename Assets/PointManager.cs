using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int points =0;
    public TextMeshProUGUI PointText;
    public int PointToEnableTarget;
    public GameObject TargetToEnable;
    public void AddPoint(int amount)
    {
        points += amount;
        PointText.text ="Point: "+points;
        if(points >=PointToEnableTarget){
            TargetToEnable.SetActive(true);
        }
    }
}
