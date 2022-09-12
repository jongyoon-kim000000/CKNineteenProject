using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum KeyType 
{
    None,
    /// <summary>
    /// ���� �̵�
    /// </summary>
    MoveLeft,
    /// <summary>
    /// ������ �̵�
    /// </summary>
    MoveRight,

    /// <summary>
    /// ����
    /// </summary>
    Jump,
    /// <summary>
    /// ���
    /// </summary>
    Dash,
    /// <summary>
    /// ���� 
    /// </summary>
    Attack,
    /// <summary>
    /// ��ȣ�ۿ�
    /// </summary>
    Interaction,
    /// <summary>
    /// ĳ���� ����
    /// </summary>
    ChangeCharacter,

    /// <summary>
    /// ��ų ���� 1
    /// </summary>
    Skill1,
    /// <summary>
    /// ��ų ���� 2
    /// </summary>
    Skill2,

    /// <summary>
    /// ����
    /// </summary>
    Status,
    /// <summary>
    /// �޴�(�Ͻ�����)
    /// </summary>
    Menu,
}
