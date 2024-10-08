using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Transform deliveryPoint;
    [SerializeField] private GameObject placeForDeliveryPrefab;

    private GameObject placeForDelivery;

    public bool isWaiting = false;

    public void AskForDelivery()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            placeForDelivery = Instantiate(placeForDeliveryPrefab, deliveryPoint);
        }
    }

    public void StopAskingForDelivery()
    {
        if (isWaiting)
        {
            isWaiting = false;
            Destroy(placeForDelivery);
        }
    }
}
