using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private Transform packageSpawnPoint;
    [SerializeField] private GameObject packagePrefab;
    
    private GameObject[] houses;
    private GameObject currentPackage;
    private GameObject currentHouse;

    [HideInInspector] public bool isPackagePickedUp = false;
    [HideInInspector] public bool isDelivering = false;
    [HideInInspector] public bool isDeliveryAreaReached = false;

    public static DeliveryManager Instance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        currentPackage = Instantiate(packagePrefab, packageSpawnPoint);
    }

    void Update()
    {
        if (isPackagePickedUp && !isDelivering)
        {
            currentHouse = houses[Random.Range(0, houses.Length)];
            currentHouse.GetComponent<House>().AskForDelivery();
            isPackagePickedUp = true;
            isDelivering = true;
            Destroy(currentPackage);
        }

        if (isPackagePickedUp && isDelivering && isDeliveryAreaReached)
        {
            currentHouse.GetComponent<House>().StopAskingForDelivery();
            isPackagePickedUp = false;
            isDelivering = false;
            isDeliveryAreaReached = false;
            currentPackage = Instantiate(packagePrefab, packageSpawnPoint);
        }
    }
}
