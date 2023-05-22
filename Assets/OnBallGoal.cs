using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnBallGoal : MonoBehaviour
{
    [SerializeField] private UnityEvent OnBallEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            OnBallEnter.Invoke();
    }
}
