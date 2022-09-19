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
            bool isGrounded = checkGrounded();
            switch (upKey)
            {
                case KeyCode.LeftArrow:
                    this.transform.position += new Vector3(-MoveStep, 0, 0);
                    break;
                case KeyCode.RightArrow:
                    this.transform.position += new Vector3(MoveStep, 0, 0);
                    break;
                case KeyCode.Space:
                    if (isGrounded)
                    {
                        _jumpCounter = 2;
                    }
                    break;
            }

            // 落下
            isGrounded = checkGrounded();
            if (!isGrounded && _jumpCounter == 0)
            {
                this.transform.position += new Vector3(0, -MoveStep, 0);
            }

            if (_jumpCounter > 0)
            {
                this.transform.position += new Vector3(0, MoveStep, 0);
                --_jumpCounter;
            }
        }
    }

    bool checkGrounded()
    {
        var result = Physics2D.CircleCast((Vector2)this.transform.position + Vector2.down, MoveStep / 2.5f, Vector2.down, 0);

        return (bool)result;
    }
}