using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideDetector : MonoBehaviour
{
    [SerializeField] private Transform ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ball.position = new Vector3(0, 1, 0);
        }
    }
}
