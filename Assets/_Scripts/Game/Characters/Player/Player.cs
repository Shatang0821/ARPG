using UnityEngine;

public class Player
{
    private readonly string PREFABROOT = "Prefabs/Player/Player.prefab";
    private GameObject _playerPrefab;
    public Player()
    {
        
    }

    public void SpawnPlayer(Vector3 spawnPoint)
    {
        // プレファブを指定された位置と回転でインスタンス化
        _playerPrefab = GameObject.Instantiate(ResManager.Instance.GetAssetCache<GameObject>(PREFABROOT), spawnPoint, Quaternion.identity);
    }
    
    
}
