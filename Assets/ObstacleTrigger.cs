using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Material material;
    [SerializeField] private Light indicator;
    [SerializeField] private int waiting;

    private void OnEnable()
    {
        material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            StartCoroutine(RemoveObstacle());
    }

    IEnumerator RemoveObstacle()
    {
        obstacle.SetActive(false);
        indicator.enabled = true;
        material.color = Color.green;
        indicator.color = Color.green;
        yield return new WaitForSeconds(seconds: waiting);
        obstacle.SetActive(true);
        material.color = Color.red;
        indicator.color = Color.red;
    }
}
