using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public List<TextMeshProUGUI> texts;

    public AudioMixer audioMixer;

    public List<Slider> sliders;

    public List<AudioMixerGroup> mixerGroups;

    public List<AudioSource> audioSources;


    public List<AudioClip> BGMClips;
    public List<AudioClip> SFXClips;


    private void Update()
    {
        //float mastervo;
        //audioMixer.GetFloat("masterVol", out mastervo);

        //text.text = mastervo.ToString();

        audioMixer.SetFloat("masterVol", Mathf.Log10(sliders[0].value) * 20);
        audioMixer.SetFloat("BGMVol", Mathf.Log10(sliders[1].value) * 20);
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sliders[2].value) * 20);

        //float vol = volemSlider.value.;

        texts[0].text = "Volumen Global: " + Mathf.Round(sliders[0].value * 100).ToString() + "%";
        texts[1].text = "Volumen Music: " + Mathf.Round(sliders[1].value * 100).ToString() + "%";
        texts[2].text = "Volumen SFX: " + Mathf.Round(sliders[2].value * 100).ToString() + "%";


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSources[0].clip = BGMClips[0];
            audioSources[0].outputAudioMixerGroup = mixerGroups[0];
            audioSources[0].Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSources[0].clip = BGMClips[1];
            audioSources[0].outputAudioMixerGroup = mixerGroups[0];

            audioSources[0].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSources[1].clip = SFXClips[0];
            audioSources[1].outputAudioMixerGroup = mixerGroups[1];

            audioSources[1].Play();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            audioSources[1].clip = SFXClips[1];
            audioSources[1].outputAudioMixerGroup = mixerGroups[1];
            audioSources[1].Play();
            //audioMixer.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];

        }

    }
}
