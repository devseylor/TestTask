using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private PlayerPath _playerPath;

    private void Start()
    {
        _playerPath = FindObjectOfType<PlayerPath>();
    }

    void Update()
    {
        if(!_playerPath.IsEnemyInWaypoint(_playerPath.CountWaypoints()))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
