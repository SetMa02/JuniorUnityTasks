using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalisation : MonoBehaviour
{
    [SerializeField] private float _peroidiciy = 3;
    [SerializeField] private Door _door;

    private IEnumerator _signalisationManager;
    private AudioSource _audioSource;
    private bool _isStop = false;
    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _signalisationManager = ManageSignalisation(_maxVolume);
    }

    private void OnEnable()
    {
        _door.ThiefEntered += PlaySignalisation;
        _door.ThiefExit += StopSignalisation;
    }

    private void OnDisable()
    {
        _door.ThiefEntered -= PlaySignalisation;
        _door.ThiefExit -= StopSignalisation;
    }

    private void PlaySignalisation()
    {
        if (_signalisationManager != null && _isStop == false )
        {
            _audioSource.Play();
            StartCoroutine(_signalisationManager);
        }
        else if (_signalisationManager != null && _isStop == true )
        {
            StopCoroutine(_signalisationManager);
            _signalisationManager = ManageSignalisation(_minVolume);
            StartCoroutine(_signalisationManager);
        }
    }

    private void StopSignalisation()
    {
        _isStop = true;
        PlaySignalisation();
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
