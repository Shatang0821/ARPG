using FrameWork.Manager;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IManager
{
    private Player _player;
    public void Init()
    {
        _player = new Player();
        _player.SpawnPlayer(new Vector3(0,1,0));
    }

    public void LogicUpdate()
    {
        
    }
}