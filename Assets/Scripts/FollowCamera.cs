using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void LateUpdate()
    {
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, transform.position.z);
    }
}
