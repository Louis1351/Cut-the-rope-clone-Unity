using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundText : MonoBehaviour {
    [SerializeField] Slider s;
    Text soundTxt;
   
	// Use this for initialization
	void Start () {
        soundTxt = GetComponent<Text>();
        s.value = AudioListener.volume;
    }
	
	// Update is called once per frame
	void Update () {
        int v = (int)(s.value * 100);
        soundTxt.text = v.ToString();
        AudioListener.volume = s.value;
    }
}
