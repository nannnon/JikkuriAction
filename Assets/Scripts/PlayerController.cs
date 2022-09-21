using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float MoveStep = 1f;

    int _jumpCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool keyUp = false;
        KeyCode upKey = KeyCode.None;
        {         
            void checkKeyUp(KeyCode keyCode)
            {
                if (Input.GetKeyUp(keyCode))
                {
                    keyUp = true;
                    upKey = keyCode;
                }
            }

            checkKeyUp(KeyCode.LeftArrow);
            checkKeyUp(KeyCode.RightArrow);
            checkKeyUp(KeyCode.Space);
            checkKeyUp(KeyCode.DownArrow);
        }

        if (keyUp)
        {
            switch (upKey)
            {
                // 左へ移動
                case KeyCode.LeftArrow:
                    if (!isHit(Vector2.left))
                    {
                        this.transform.position += new Vector3(-MoveStep, 0, 0);
                    }
                    break;
                // 右へ移動
                case KeyCode.RightArrow:
                    if (!isHit(Vector2.right))
                    {
                        this.transform.position += new Vector3(MoveStep, 0, 0);
                    }
                    break;
                // ジャンプ
                case KeyCode.Space:
                    if (isHit(Vector2.down))
                    {
                        _jumpCounter = 2;
                    }
                    break;
            }

            // 落下
            if (!isHit(Vector2.down) && _jumpCounter == 0)
            {
                this.transform.position += new Vector3(0, -MoveStep, 0);
            }

            if (_jumpCounter > 0)
            {
                // 頭がぶつかったらジャンプ終了
                if (isHit(Vector2.up))
                {
                    _jumpCounter = 0;
                }
                else // ジャンプ
                {
                    this.transform.position += new Vector3(0, MoveStep, 0);
                    --_jumpCounter;
                }
            }
        }
    }

    bool isHit(Vector2 direction)
    {
        var result = Physics2D.CircleCast((Vector2)this.transform.position + direction, MoveStep / 2.5f, direction, 0);

        return (bool)result;
    }
}
