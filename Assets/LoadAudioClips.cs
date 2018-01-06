using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudioClips : MonoBehaviour {
    public AudioClip[] list;
    // Use this for initialization
    void Start () {
        //Loading the items into the array
        list = new AudioClip[]{(AudioClip)Resources.Load("Audio/aaa.wav"),
                                     (AudioClip)Resources.Load("Audio/china.wav")};
    }
	
}
