using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour   
{
    [SerializeField]
    GameObject[] balls;

    int ballIndex = 0;

    int score, highScore;

    [SerializeField]
    Transform startPos;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;
    }

    private void Update()
    {
    }

    private void Start()
    {
        Instantiate(balls[0], startPos.position, Quaternion.identity);
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        if (ballIndex == balls.Length - 1) return;
        ballIndex += 1;
        Instantiate(balls[ballIndex], startPos.position, Quaternion.identity);
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
