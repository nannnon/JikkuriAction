using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBirdController : Enemy
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
            if (!isHit(Vector2.left))
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
            if (!isHit(Vector2.right))
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
