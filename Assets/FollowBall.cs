using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform ball;

    private void Update()
    {
        transform.position = new Vector3(ball.transform.position.x, 50, ball.transform.position.z);
    }
}
