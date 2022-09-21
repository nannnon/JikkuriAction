using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState
{
    Main,
    GameOver
}

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject _gameOverUI;

    GameState _gameState;
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _gameState = GameState.Main;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameState == GameState.Main)
        {
            // プレイヤーが一定以上落下したらゲームオーバー
            const int DeadHeight = -10;
            if (_player.transform.position.y < DeadHeight)
            {
                _gameOverUI.SetActive(true);
                _gameState = GameState.GameOver;
            }
        }
    }

    public void LoadCurrentScene()
    {
        var activeSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneName);
    }
}
