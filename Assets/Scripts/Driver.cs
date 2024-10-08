using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 10.0f;
    [SerializeField] private float moveSpeed = 10.0f;

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        if (moveAmount != 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
    }
}
