using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private List<AudioSource> _audioSourceButtons;
    [SerializeField] private AudioMixerGroup _masterGroup;
    [SerializeField] private AudioMixerGroup _buttonsGroup;
    [SerializeField] private AudioMixerGroup _backGroup;


    public void ToggleAllButtons()
    {
        if (_audioSourceButtons.All(x => x.isPlaying == false))
        {
            foreach (var audioSource in _audioSourceButtons)
            {
                audioSource.Play();
            }
        }
        else
        {
            foreach (var audioSource in _audioSourceButtons)
            {
                audioSource.Stop();
            }
        }
    }

    public void ToggleButton(AudioSource audioSource)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }

    public void ChangeMasterGroupVolume(float volume)
    {
        _audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void ChangeButtonsGroupVolume(float volume)
    {
        _audioMixer.SetFloat("ButtonsVolume", Mathf.Log10(volume) * 20);
    }

    public void ChangeBackGroupVolume(float volume)
    {
        _audioMixer.SetFloat("BackVolume", Mathf.Log10(volume) * 20);
    }
}
