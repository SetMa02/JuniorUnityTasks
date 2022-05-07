using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public event UnityAction ThiefEntered;
    public event UnityAction ThiefExit;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief julik))
        {
            ThiefEntered?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out Thief julik))
        {
            ThiefExit?.Invoke();
        }
    }
}
