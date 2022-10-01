using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : Enemy
{
    [SerializeField]
    GameObject _bulletPrefab;

    GameController _gameController;
    int _counter = 0;

    enum GunState
    {
        BlazeAway,
        EarthAndSky,
        ShotGun
    }
    GunState _gunState = GunState.BlazeAway;

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
        if (_counter % 10 == 0)
        {
            switch (_gunState)
            {
                case GunState.BlazeAway:
                    _gunState = GunState.EarthAndSky;
                    break;
                case GunState.EarthAndSky:
                    _gunState = GunState.ShotGun;
                    break;
                case GunState.ShotGun:
                    _gunState = GunState.BlazeAway;
                    break;
            }
        }

        if (_gunState == GunState.BlazeAway)
        {
            if (!isHit(Vector2.down))
            {
                Move(Direction.Down);
            }

            if (_counter % 2 == 0)
            {
                ShootBullet(new Vector3(-MoveStep, 0, 0));
            }
        }
        else if (_gunState == GunState.EarthAndSky)
        {
            int mod = _counter % 4;
            if (mod == 0)
            {
                ShootBullet(new Vector3(-MoveStep, 0, 0));
            }
            else if (mod == 1)
            {
                if (!isHit(Vector2.up))
                {
                    Move(Direction.Up);
                }
            }
            else if (mod == 2)
            {
                ShootBullet(new Vector3(-MoveStep, 0, 0));
            }
            else if (mod == 3)
            {
                if (!isHit(Vector2.down))
                {
                    Move(Direction.Down);
                }
            }
        }
        else if (_gunState == GunState.ShotGun)
        {
            if (!isHit(Vector2.down))
            {
                Move(Direction.Down);
            }

            if (_counter % 5 == 0)
            {
                ShootBullet(new Vector3(-2 * MoveStep, MoveStep, 0));
                ShootBullet(new Vector3(-2 * MoveStep, 0, 0));
                ShootBullet(new Vector3(-1 * MoveStep, MoveStep, 0));
                ShootBullet(new Vector3(-1 * MoveStep, 0, 0));
            }
        }

        ++_counter;
    }

    void ShootBullet(Vector3 dpos)
    {
        GameObject go = Instantiate(_bulletPrefab);
        go.transform.position = this.transform.position + dpos;
        _gameController.AddEnemy(go.GetComponent<Enemy>());
    }
}
