using FrameWork.Manager;
using FrameWork.Utils;
using UnityEngine;

public class Player
{
    private readonly string PREFABROOT = "Prefabs/Player/Player.prefab";
    private readonly string INPUTROOT = "Input/Player Input.asset";
    private GameObject _playerPrefab;
    public Rigidbody Rigidbody { get; private set; }
    

    public PlayerInput Input { get; private set; }
    public Player()
    {
        Input = ResManager.Instance.GetAssetCache<PlayerInput>(INPUTROOT);
        // プレファブを指定された位置と回転でインスタンス化
        _playerPrefab = GameObject.Instantiate(ResManager.Instance.GetAssetCache<GameObject>(PREFABROOT), new Vector3(-99,-99,-99), Quaternion.identity);
        Rigidbody = _playerPrefab.GetComponent<Rigidbody>();
        
        _playerPrefab.SetActive(false);
    }

    public void SpawnPlayer(Vector3 spawnPoint)
    {
        _playerPrefab.transform.position = spawnPoint;
        _playerPrefab.SetActive(true);
    }

   
}
