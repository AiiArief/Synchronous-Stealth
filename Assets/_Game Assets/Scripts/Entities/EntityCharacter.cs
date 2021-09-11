using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCharacter : Entity
{
    public CharacterController characterController { get; private set; }
    [SerializeField] bool m_detectCollisionOnStart = true;
    [SerializeField] float m_gravityPerTurn = 3.0f;
    public float gravityPerTurn { get { return m_gravityPerTurn; } }

    public LevelGridNode currentNode { get; private set; }

    // tambah status effect list, ga usah entity biasa
    // invoke semua status effect pas wait input
    // tergantung status effectnya mau invoke apaan ke entity nya

    public override void SetIsUpdateAble(bool isUpdateAble)
    {
        base.SetIsUpdateAble(isUpdateAble);

        if (isUpdateAble)
            _AssignComponent();
    }

    public void AssignToLevelGrid(LevelGridNode node = null)
    {
        currentNode = node;
        if (node == null)
            currentNode = GameManager.Instance.levelManager.AssignToGridFromRealWorldPos(this);

        currentNode.entityListOnThisNode.Add(this);
    }

    protected virtual void _AssignComponent()
    {
        if (!characterController)
        {
            characterController = GetComponent<CharacterController>();
            characterController.detectCollisions = m_detectCollisionOnStart;
        }
    }
}
