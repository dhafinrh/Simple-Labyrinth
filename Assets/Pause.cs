using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera, pauseCamera;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform ball;
    bool value;

    public void OnPause(bool value)
    {
        this.value = value;
        
        if (value)
        {
            rb.isKinematic = true;
            mainCamera.SetActive(false);
            pauseCamera.SetActive(true);
        }
        else
        {
            rb.isKinematic = false;
            mainCamera.SetActive(true);
            pauseCamera.SetActive(false);
        }
    }

    private void Update()
    {
        if (value)
            transform.position = new Vector3(7, ball.transform.position.y, ball.transform.position.z + 0.5f);
    }


}
