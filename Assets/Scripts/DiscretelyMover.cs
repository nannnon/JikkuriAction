using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiscretelyMover : MonoBehaviour
{
    protected const float MoveStep = 1f;

    protected enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }

    protected void Move(Direction dir)
    {
        switch (dir)
        {
            case Direction.Right:
                this.transform.position += new Vector3(MoveStep, 0, 0);
                break;

            case Direction.Left:
                this.transform.position += new Vector3(-MoveStep, 0, 0);
                break;

            case Direction.Up:
                this.transform.position += new Vector3(0, MoveStep, 0);
                break;

            case Direction.Down:
                this.transform.position += new Vector3(0, -MoveStep, 0);
                break;
        }
    }

    protected bool isHit(Vector2 direction)
    {
        const int layerMask = 1 << 6; // Levelのみ衝突
        var result = Physics2D.CircleCast((Vector2)this.transform.position + direction, MoveStep / 2.5f, direction, 0, layerMask);

        return (bool)result;
    }
}
