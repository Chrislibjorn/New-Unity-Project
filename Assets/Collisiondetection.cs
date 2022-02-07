using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisiondetection : MonoBehaviour

{
    private PointManager pm;
    public float Time;
      public AudioClip HitAudio;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         AudioSource.PlayClipAtPoint(HitAudio,transform.position);
        print("xd1");
        if (other.tag == "Player")
        {
            StartCoroutine(WaitDestruction());
            print("xd");

        }
    }
    IEnumerator WaitDestruction()
    {
        yield return new WaitForSeconds(Time);
        pm.AddPoint(1);
        Destroy(gameObject);
    }
}

