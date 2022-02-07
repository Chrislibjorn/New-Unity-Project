using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public TimeManager TM;
    public int NextLevel;
    public float TimeUntilNextLevel;
    public AudioClip HitAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(HitAudio, transform.position);

        if (collision.tag == "Player")
        {
            TM.StopAndSaveScore();
            StartCoroutine(WaitAndChangeLevel());
        }
    }
    IEnumerator WaitAndChangeLevel()
    {
        yield return new WaitForSeconds(TimeUntilNextLevel);
        SceneManager.LoadScene(NextLevel);
    }
}
