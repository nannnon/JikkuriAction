using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : Enemy
{
    GameController _gameController;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MoveEnemy()
    {
        if (isHit(Vector2.left))
        {
            _gameController.RemoveEnemy(this);
            Destroy(this.gameObject);
        }
        else
        {
            Move(Direction.Left);
        }
    }
}
