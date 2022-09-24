using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DiscretelyMover
{
    int _jumpCounter = 0;
    GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
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
                        Move(Direction.Left);
                    }
                    break;
                // 右へ移動
                case KeyCode.RightArrow:
                    if (!isHit(Vector2.right))
                    {
                        Move(Direction.Right);
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
                Move(Direction.Down);
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
                    Move(Direction.Up);
                    --_jumpCounter;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            _gameController.GameClear();
        }
    }
}
