using System;
using UnityEngine;

[Serializable]
public class PlayerDashData
{
    // 速度修正係数
    [field: SerializeField] [field: Range(1f, 2f)] public float SpeedModifier { get; private set; } = 2f;
    // 連続とみなされる時間
    [field: SerializeField] [field: Range(0f, 2f)] public float TimeToBeConsideredConsecutive { get; private set; } = 1f;
    // 連続ダッシュの制限数
    [field: SerializeField] [field: Range(1, 10)] public int ConsecutiveDashedLimitAmount { get; private set; } = 2;
    // ダッシュ制限に達した後のクールダウン時間
    [field: SerializeField] [field: Range(0f, 5f)] public float DashLimitReachedCooldown { get; private set; } = 1.75f;
}