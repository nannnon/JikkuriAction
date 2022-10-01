using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject _gameOverUI;
    [SerializeField]
    GameObject _gameClearUI;
    [SerializeField]
    string _nextSceneName;

    enum GameState
    {
        Main,
        GameOver,
        GameClear
    }
    GameState _gameState;
    GameObject _player;
    List<Enemy> _enemies;

    // Start is called before the first frame update
    void Start()
    {
        _gameState = GameState.Main;
        _player = GameObject.FindGameObjectWithTag("Player");

        _enemies = new List<Enemy>();
        var egos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in egos)
        {
            Enemy enemy = go.GetComponent<Enemy>();
            _enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadCurrentScene()
    {
        var activeSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneName);
    }
    
    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nextSceneName);
    }

    public void GameOver()
    {
        if (_gameState == GameState.Main)
        {
            _player.SetActive(false);
            _gameOverUI.SetActive(true);
            _gameState = GameState.GameOver;
        }
    }

    public void GameClear()
    {
        if (_gameState == GameState.Main)
        {
            _player.SetActive(false);
            _gameClearUI.SetActive(true);
            _gameState = GameState.GameClear;
        }
    }

    public void MoveAllEnemies()
    {
        for (int i = _enemies.Count - 1; i >= 0; --i)
        {
            _enemies[i].MoveEnemy();
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

}
