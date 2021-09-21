using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumWalkableType
{
    Default,
    None,
    Snow,
    Ice,
    Rock,
}

public class TagWalkable : MonoBehaviour
{
    [SerializeField] EnumWalkableType m_walkableType = EnumWalkableType.Default;
    public EnumWalkableType walkableType { get { return m_walkableType; } }

    // bikin fungsi yang manggil ke database dan pindahin ke step manager?
}
