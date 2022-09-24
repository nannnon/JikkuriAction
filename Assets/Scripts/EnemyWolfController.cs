using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolfController : Enemy
{
    Direction _moveDir = Direction.Left;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MoveEnemy()
    {
        if (_moveDir == Direction.Left)
        {
            // 左に壁がない　かつ　左下に壁がある
            if (!isHit(Vector2.left) && isHit(new Vector2(-MoveStep, -MoveStep)))
            {
                Move(Direction.Left);
            }
            else
            {
                _moveDir = Direction.Right;
            }
        }
        else if (_moveDir == Direction.Right)
        {
            // 右に壁がない　かつ　右下に壁がある
            if (!isHit(Vector2.right) && isHit(new Vector2(MoveStep, -MoveStep)))
            {
                Move(Direction.Right);
            }
            else
            {
                _moveDir = Direction.Left;
            }
        }
    }
}
