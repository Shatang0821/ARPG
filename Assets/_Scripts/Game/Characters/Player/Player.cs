using FrameWork.Manager;
using FrameWork.Utils;
using UnityEngine;

public class Player
{
    private readonly string PREFABROOT = "Prefabs/Player/Player.prefab";
    private readonly string INPUTROOT = "Input/Player Input.asset";
    private GameObject _playerPrefab;

    

    public PlayerInput _input;
    public Player()
    {
        _input = ResManager.Instance.GetAssetCache<PlayerInput>(INPUTROOT);
    }

    public void SpawnPlayer(Vector3 spawnPoint)
    {
        // プレファブを指定された位置と回転でインスタンス化
        _playerPrefab = GameObject.Instantiate(ResManager.Instance.GetAssetCache<GameObject>(PREFABROOT), spawnPoint, Quaternion.identity);
    }

   
}
