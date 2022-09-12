using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatusType
{
    None,
    /// <summary>
    /// �ּ� �̵��ӵ�
    /// </summary>
    MinMoveSpeed,
    /// <summary>
    /// �ִ� �̵� �ӵ�
    /// </summary>
    MaxMoveSpeed,
    /// <summary>
    /// �ӵ� ������
    /// </summary>
    IncreaseMoveSpeed,
    /// <summary>
    /// �ӵ� ���ҷ�
    /// </summary>
    DecreaseMoveSpeed,
    /// <summary>
    /// ȸ�� �ֱ�
    /// </summary>
    RotationChangeTime,
    /// <summary>
    /// ȸ�� �ӵ�
    /// </summary>
    RotateSpeed,
    /// <summary>
    /// �˹� �Ŀ�
    /// </summary>
    KnockBackPower,
    /// <summary>
    /// �˹� ����
    /// </summary>
    KnockBackDefence,
}
