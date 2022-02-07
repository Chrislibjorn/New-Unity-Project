using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI TextTid;
    public TextMeshProUGUI TextHighscore;
    private float _timeInLevel;

    private bool _runTimer = true;
    private string _currentLevelName;
    // Start is called before the first frame update
    void Start()
    {
        _currentLevelName = SceneManager.GetActiveScene().name;
        string score = "HighScore: "+PlayerPrefs.GetFloat(_currentLevelName).ToString("F2");
        TextHighscore.text = score;
    }

    // Update is called once per frame
    void Update()
    {
        if(_runTimer){
        _timeInLevel += Time.deltaTime;
        } 
        TextTid.text = "Time: "+_timeInLevel.ToString("F2");
    }
    public void StopAndSaveScore()
    {
        _runTimer = false;
        float lastScore = PlayerPrefs.GetFloat(_currentLevelName);
        if(lastScore>_timeInLevel||lastScore==0){
        PlayerPrefs.SetFloat(_currentLevelName,_timeInLevel);
        }
    }
}
