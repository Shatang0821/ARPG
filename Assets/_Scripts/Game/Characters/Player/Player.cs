using FrameWork.Manager;
using UnityEngine;

public class Player
{
    private const string PREFABROOT = "Prefabs/Player/Player.prefab";
    private const string INPUTROOT = "Input/Player Input.asset";
    private const string PLYAERSOROOT = "ScriptableObjects/Characters/Player/Player.asset";
    
    private GameObject _playerPrefab;
    public Rigidbody Rigidbody { get; private set; }
    public PlayerInput Input { get; private set; }
    
    public PlayerSO Data { get; private set; }
    
    //カメラ
    public Transform MainCameraTransform { get; private set; }
    public Player()
    {
        Input = ResManager.Instance.GetAssetCache<PlayerInput>(INPUTROOT);
        Data = ResManager.Instance.GetAssetCache<PlayerSO>(PLYAERSOROOT);
        if (Camera.main != null) MainCameraTransform = Camera.main.transform;

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
