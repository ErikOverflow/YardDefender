using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer = null;
    

    public void SetMasterLevel(float volume)
    {
        float dbLevel = 20 * Mathf.Log10(volume);
        if (volume == 0f)
            dbLevel = -80f;
        mixer.SetFloat("MasterVolume", dbLevel);
    }

    public void SetAmbienceVolume(float volume)
    {
        float dbLevel = 20 * Mathf.Log10(volume);
        if (volume == 0f)
            dbLevel = -80f;
        mixer.SetFloat("AmbienceVolume", dbLevel);
    }

    public void SetMusicVolume(float volume)
    {
        float dbLevel = 20 * Mathf.Log10(volume);
        if (volume == 0f)
            dbLevel = -80f;
        mixer.SetFloat("MusicVolume", dbLevel);
    }

    public void SetSfxVolume(float volume)
    {
        float dbLevel = 20 * Mathf.Log10(volume);
        if (volume == 0f)
            dbLevel = -80f;
        mixer.SetFloat("SfxVolume", dbLevel);
    }

}
