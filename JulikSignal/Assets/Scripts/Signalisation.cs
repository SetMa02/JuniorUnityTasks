using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalisation : MonoBehaviour
{
    [SerializeField] private float _peroidiciy = 3;
    [SerializeField] private Door _door;

    private IEnumerator _startSignalisationManager;
    private IEnumerator _stopSignalisationManager;
    private AudioSource _audioSource;
    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _startSignalisationManager = ManageSignalisation(_maxVolume);
        _stopSignalisationManager = ManageSignalisation(_minVolume);
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
        _audioSource.Play();
        if (_stopSignalisationManager != null)
        {
            StopCoroutine(_stopSignalisationManager);
        }

        StartCoroutine(_startSignalisationManager);
        
    }

    private void StopSignalisation()
    {
        if (_startSignalisationManager != null)
        {
            StopCoroutine(_startSignalisationManager);
        }

        StartCoroutine(_stopSignalisationManager);

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
