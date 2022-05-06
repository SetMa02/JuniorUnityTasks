using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalisation : MonoBehaviour
{
    [SerializeField] private float _peroidiciy = 3;  
    private AudioSource _audioSource;
    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief julik))
        {
            _audioSource.Play();
            _audioSource.volume = _minVolume;
            StartCoroutine(StartSignalisation());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(StopSignalisation());
    }

    private IEnumerator StartSignalisation()
    {
        float volume;
        while (true)
        {
            volume = _maxVolume / _peroidiciy * Time.deltaTime;

            _audioSource.volume += volume;

            if (_audioSource.volume >= _maxVolume) break;
            yield return null;
        }
    }

    private IEnumerator StopSignalisation()
    {
        float volume;
        while (true)
        {
            volume = _maxVolume / _peroidiciy * Time.deltaTime;

            _audioSource.volume -= volume;

            if (_audioSource.volume >= _maxVolume) break;
            yield return null;
        }
    }
}
