using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class UnitManager : NetworkBehaviour
{

    public GameObject BatUnit;

    [ServerRpc]
    public void BatServerRpc(ServerRpcParams rpcParams = default)
    {
        GameObject Bat = Instantiate(BatUnit, transform.position, transform.rotation);
        Bat.gameObject.GetComponent<NetworkObject>().SpawnWithOwnership(rpcParams.Receive.SenderClientId);
    }

}
