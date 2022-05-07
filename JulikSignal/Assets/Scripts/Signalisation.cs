using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalisation : MonoBehaviour
{
    [SerializeField] private float _peroidiciy = 3;
    [SerializeField] private Door _door;
    
    private AudioSource _audioSource;
    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _door.ThiefEntered += ThiefDetected;
        _door.ThiefExit += ThiefLeave;
    }

    private void OnDisable()
    {
        _door.ThiefEntered -= ThiefDetected;
        _door.ThiefExit -= ThiefLeave;
    }

    private void ThiefDetected()
    {
        StartCoroutine(ManageSignalisation(_maxVolume));
        _audioSource.Play();
    }

    private void ThiefLeave()
    {
        StartCoroutine(ManageSignalisation(_minVolume));
    }
    
    private IEnumerator ManageSignalisation(float targetValue)
    {
        while (_audioSource.volume != targetValue) 
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetValue, _peroidiciy * Time.deltaTime);
            yield return null;
        }

        if (targetValue == _minVolume)
        {
            _audioSource.Stop();
        }
    }
}
