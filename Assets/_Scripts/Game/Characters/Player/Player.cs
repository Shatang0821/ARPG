using System;
using FrameWork.Manager;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string INPUTROOT = "Input/Player Input.asset";
    private const string PLYAERSOROOT = "ScriptableObjects/Characters/Player/Player.asset";
    public Rigidbody Rigidbody { get; private set; }
    public PlayerInput Input { get; private set; }
    public PlayerSO Data { get; private set; }
    //カメラ
    public Transform MainCameraTransform { get; private set; }
    
    private PlayerStateMachine _playerStateMachine;

    private Animator _animator;
    private void Awake()
    {
        Input = new PlayerInput();
        Data = ResManager.Instance.GetAssetCache<PlayerSO>(PLYAERSOROOT);
        if (Camera.main != null) MainCameraTransform = Camera.main.transform;
        
        Rigidbody =GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        _playerStateMachine = new PlayerStateMachine(this,_animator);
    }
    
    private void OnEnable()
    {
        Input.OnEnable();
    }

    private void OnDisable()
    {
        Input.OnDisable();
    }

    private void Start()
    {
        _playerStateMachine.ChangeState(_playerStateMachine.IdleState);
    }

    

    private void Update()
    {
        _playerStateMachine.HandleInput();
        _playerStateMachine.LogicUpdate();
    }

    private void FixedUpdate()
    {
        _playerStateMachine.PhysicsUpdate();
    }
}
