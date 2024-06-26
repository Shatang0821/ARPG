using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtual;

    [SerializeField] [Range(0, 10f)] private float _defaultDistance = 6f;
    [SerializeField] [Range(0, 10f)] private float _minimumDistance = 1f;
    [SerializeField] [Range(0, 10f)] private float _maximumDistance = 6f;
    
    [SerializeField] [Range(0, 10f)] private float _smoothing = 4f;
    [SerializeField] [Range(0, 10f)] private float _zoomSensitivity = 1f;

    private CinemachineFramingTransposer _framingTransposer;
    private CinemachineInputProvider _inputProvider;

    private float _currentTargetDistance;
    private void Awake()
    {
        _cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();
        _framingTransposer = _cinemachineVirtual.GetCinemachineComponent<CinemachineFramingTransposer>();
        _inputProvider = GetComponent<CinemachineInputProvider>();

        _currentTargetDistance = _defaultDistance;
    }

    private void Start()
    {
        _cinemachineVirtual.Follow = GameObject.Find("CameraLookPoint").transform;
        _cinemachineVirtual.LookAt = GameObject.Find("CameraLookPoint").transform;
    }

    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float zoomValue = _inputProvider.GetAxisValue(2) * _zoomSensitivity;

        _currentTargetDistance = Mathf.Clamp(_currentTargetDistance + zoomValue,_minimumDistance,_maximumDistance);
        float currentDistance = _framingTransposer.m_CameraDistance;

        if (currentDistance == _currentTargetDistance)
        {
            return;
        }

        float lerpedZoomValue = Mathf.Lerp(currentDistance, _currentTargetDistance, _smoothing * Time.deltaTime);

        _framingTransposer.m_CameraDistance = lerpedZoomValue;
    }
}