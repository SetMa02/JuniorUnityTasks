using System;
using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    public event UnityAction Reched;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Reched.Invoke();
            Debug.Log("Reached");
        }
    }
}