using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {
    public AudioClip[] soundtrack;
    AudioSource audio;
    // Use this for initialization
    void Start () {

        soundtrack = new AudioClip[]{(AudioClip)Resources.Load("build wall"),
                                      (AudioClip)Resources.Load("she has a very nice figure"),
                                      (AudioClip)Resources.Load("they are sending people"),
                                      (AudioClip)Resources.Load("what the hell is going on"),
                                      (AudioClip)Resources.Load("we now have a gun on every table"),

                                     (AudioClip)Resources.Load("they are rapists")};
        audio = GetComponent<AudioSource>();
        Invoke("PlaySoundStart", 4);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!audio.isPlaying)
        {
            audio.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audio.Play();
        }
    }

    void PlaySoundStart()
    {
        if (!audio.playOnAwake)
        {
            audio.clip = soundtrack[0];
            audio.Play();
        }
    }

   
}
