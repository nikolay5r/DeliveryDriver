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
    
    public bool isPackagePickedUp = false;
    public bool isDelivering = false;
    public bool isDeliveryAreaReached = false;

    public static DeliveryManager Instance;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        houses = GameObject.FindGameObjectsWithTag("House");
        currentPackage = Instantiate(packagePrefab, packageSpawnPoint);
    }

    // Update is called once per frame
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
        }
    }
}
