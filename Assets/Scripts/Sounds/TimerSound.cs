using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSound : MonoBehaviour {
    AudioSource sound;
    float time;
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
		if(time >= sound.clip.length)
        {
            Destroy(gameObject);
        }
	}
}
