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
    private bool _isEnter = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _door.TheifWalk += ThiefDetected;
    }

    private void OnDisable()
    {
        _door.TheifWalk -= ThiefDetected;
    }

    private void ThiefDetected()
    {
        StartCoroutine(ManageSignalisation());
    }

    private void MoveSound(float volume)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _peroidiciy * Time.deltaTime);
    }

    private IEnumerator ManageSignalisation()
    {
        if (_isEnter == false) 
        {
            _isEnter = true;
            while (_audioSource.volume != _maxVolume) 
            {
                MoveSound(_maxVolume);
                yield return null;
            }
        }
        else if(_isEnter == true) 
        {
            _isEnter = false;
            while (_audioSource.volume != _minVolume) 
            {
                MoveSound(_minVolume);
                yield return null;
            }
            _audioSource.Stop();
        }
    }
}
