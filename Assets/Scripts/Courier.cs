using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courier : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            DeliveryManager.Instance.isPackagePickedUp = true;
        }

        if (collision.tag == "DeliveryArea")
        {
            DeliveryManager.Instance.isDeliveryAreaReached = true;
        }
    }
}
