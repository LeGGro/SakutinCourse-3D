using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private const float MaxVolume = 1;
    private const float MinVolume = 0;

    [SerializeField] private float _deltaStep;

    private AudioSource _audioSource;

    public void Start()
    { 
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PathFollower enemy))
        {
            StopAllCoroutines();
            StartCoroutine(SmoothVolumeChanging(MaxVolume));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PathFollower enemy))
        {
            StopAllCoroutines();
            StartCoroutine(SmoothVolumeChanging(MinVolume));
        }
    }

    private IEnumerator SmoothVolumeChanging(float value)
    {
        while (_audioSource.volume != value)
        {
            _audioSource.volume = Mathf.Clamp01(Mathf.MoveTowards(_audioSource.volume, value, _deltaStep * Time.deltaTime));
            yield return null;
        }
    }
}
