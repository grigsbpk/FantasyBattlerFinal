using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public Camera HostCamera;
    public Camera ClientCamera;

    public Button btnMushroom;
    public Button btnSkeleton;
    public Button btnBat;

    public GameObject MushroomUnit;
    public GameObject BatUnit;
    public GameObject SkeletonUnit;

    private List<Button> unitButtons = new List<Button>();

    private List<Vector3> availableHostSpawn = new List<Vector3>();
    public GameObject HostSpawnPoints;
    private int HostSpawnIndex = 0;

    private List<Vector3> availableClientSpawn = new List<Vector3>();
    public GameObject ClientSpawnPoints;
    private int ClientSpawnIndex = 0;



    public void Awake()
    {
        refreshSpawnPoints();
    }
    private void Start()
    {
        
        if (IsHost)
        {
            HostCamera.gameObject.SetActive(true);
        } 
        else
        {
            ClientCamera.gameObject.SetActive(true);
        }

        unitButtons.Add(btnBat);
        unitButtons.Add(btnSkeleton);
        unitButtons.Add(btnMushroom);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if(IsHost)
        {
            btnBat.onClick.AddListener(HostAddUnitBat);
            btnSkeleton.onClick.AddListener(HostAddUnitSkeleton);
            btnMushroom.onClick.AddListener(HostAddUnitMushroom);

            
            
        }
        else
        {
            btnBat.onClick.AddListener(ClientAddUnitBat);
            btnSkeleton.onClick.AddListener(ClientAddUnitSkeleton);
            btnMushroom.onClick.AddListener(ClientAddUnitMushroom);
        }

        

        
    }

    private void refreshSpawnPoints()
    {
        Transform[] HostPoints = HostSpawnPoints.GetComponentsInChildren<Transform>();
        availableHostSpawn.Clear();
        foreach (Transform point in HostPoints)
        {
            if(point != HostSpawnPoints.transform)
            {
                availableHostSpawn.Add(point.localPosition);
            }
        }

        Transform[] ClientPoints = ClientSpawnPoints.GetComponentsInChildren<Transform>();
        availableClientSpawn.Clear();
        foreach (Transform point in ClientPoints)
        {
            if (point != ClientSpawnPoints.transform)
            {
                availableClientSpawn.Add(point.localPosition);
            }
        }
    }


    private void HostAddUnitBat()
    {
        
    }

    private void HostAddUnitSkeleton()
    {

    }

    private void HostAddUnitMushroom()
    {

    }

    private void ClientAddUnitBat()
    {
        Instantiate(BatUnit, GetNextSpawnLocationClient(), Quaternion.identity);
    }
    private void ClientAddUnitSkeleton()
    {

    }
    private void ClientAddUnitMushroom()
    {

    }

    public Vector3 GetNextSpawnLocationHost()
    {
        var newPosition = availableHostSpawn[HostSpawnIndex];
        newPosition.y = 1.5f;
        HostSpawnIndex += 1;

        if (HostSpawnIndex > availableHostSpawn.Count - 1)
        {
            HostSpawnIndex = 0;
        }

        return newPosition;
    }

    public Vector3 GetNextSpawnLocationClient()
    {
        var newPosition = availableClientSpawn[ClientSpawnIndex];
        newPosition.y = 1.5f;
        ClientSpawnIndex += 1;

        if (ClientSpawnIndex > availableClientSpawn.Count - 1)
        {
            ClientSpawnIndex = 0;
        }

        return newPosition;
    }
}
