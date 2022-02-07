using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
     public AudioClip HitAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
         AudioSource.PlayClipAtPoint(HitAudio,transform.position);
        if(other.tag=="Player"){
            Destroy(other.gameObject);
            print("XD");
        }
    }
}
