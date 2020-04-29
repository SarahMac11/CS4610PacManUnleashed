using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    // audio source
    private AudioSource audioSrc;

    // music value altered by slider knob
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // control audio source game component
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // set audio volume to music volume
        audioSrc.volume = musicVolume;
    }

    // set volume
    public void SetVolume(float volume)
    {
        musicVolume = volume;
        SaveSliderValue(musicVolume);
    }

    void SaveSliderValue(float vol)
    {
        float setVolume = vol;
        // set user pref on volume level
        PlayerPrefs.SetFloat("SliderVolumeLevel", setVolume);
    }

}
