using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefabsBall;
    public Transform firePoint;
    public float speedBall;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(prefabsBall, firePoint.position, firePoint.rotation);
            Rigidbody2D rbBall = ball.GetComponent<Rigidbody2D>();
            rbBall.AddForce(firePoint.right * speedBall, ForceMode2D.Impulse);
        }
    }
}
