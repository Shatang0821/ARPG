using System;
using FrameWork.Manager;
using FrameWork.Utils;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player _player;
    public bool IsSpawnPlayer;

    private void Awake()
    {
        DebugLogger.Log("Init");
        if (IsSpawnPlayer)
        {
            GameObject.Instantiate(_player, Vector3.zero, Quaternion.identity);
        }
    }
    
}