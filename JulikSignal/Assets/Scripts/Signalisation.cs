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
    private bool _isEnter = false;

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
            StartCoroutine(SignalisationManager());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(SignalisationManager());
    }

    private IEnumerator SignalisationManager()
    {
        if (_isEnter == false)
        {
            _isEnter = true;
            while (_audioSource.volume != _maxVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _peroidiciy * Time.deltaTime);
                yield return null;
            }
        }
        else if(_isEnter == true)
        {
            _isEnter = false;
            while (_audioSource.volume != _minVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _peroidiciy * Time.deltaTime);
                yield return null;
            }
            _audioSource.Stop();
        }
    }
}
