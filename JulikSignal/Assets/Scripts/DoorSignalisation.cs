using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DoorSignalisation : MonoBehaviour
{
    [SerializeField] private float _peroidiciy = 3;  
    private AudioSource _audioSource;
    private bool isEnter = false;
    private float _minVolume = 0;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Julik>(out Julik julik))
        {
            _audioSource.Play();
            _audioSource.volume = _minVolume;
            isEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isEnter = false;
    }

    private void FixedUpdate()
    {
        if (isEnter == true)
        {
            _audioSource.volume += Time.deltaTime * _peroidiciy;
        }

        if (isEnter == false)
        {
            _audioSource.volume -= Time.deltaTime * _peroidiciy;
        }
    }
}
