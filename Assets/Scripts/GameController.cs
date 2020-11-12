using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameController>();
            }
            return instance;
        }
    }

    [SerializeField]
    KeyCode Pausega;
    bool IsPaused = false;
    public bool IsStarted = false;
    public bool IsDead = false;
    public Text ScoreText;
    public Text HighestScoreText;
    public GameObject RestartButten;
    public GameObject QuitingButten;
    public GameObject PausingText;
    public GameObject GreatText;
    public GameObject Menuuu;
    //public GameObject BackGraund;

    public InputField PlayerCode;

    DBInterface DBInterface;

    public int Score;
    string Code;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        DBInterface = FindObjectOfType<DBInterface>();
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        
        HighestScoreText.text = "Code: " + Code;

        if (IsDead)
        {
            GreatText.SetActive(true);
            Time.timeScale = 0;
            Menuuu.SetActive(true);
            RestartButten.SetActive(true);
            UnityEngine.Debug.Log(Code);
            UnityEngine.Debug.Log(Score);
            DBInterface.Insert_score(Code, Score);
            
        }
        if (Input.GetKeyDown(Pausega))
        {
            PauseGame();
        }
    }
    public void StartingGame()
    {
       
        Code = PlayerCode.text;
        IsStarted = true;
        SceneManager.LoadScene(1);
        if (DBInterface == null)
        {
            Debug.LogError("UserInterface: Could not insert a score. DBIitefrace is not present.");
            return;
        }
               
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void PauseGame()
    {
        if (IsPaused)
        {
            Time.timeScale = 1;
            IsPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            IsPaused = true;
            
        }
    }
    public void Qitgame()
    {
        UnityEngine.Debug.Log("Quiting...");
        Application.Quit();
    }
    void OnDisable()
    {
        PlayerPrefs.SetString("Code", Code);
    }
    void OnEnable()
    {
        Code = PlayerPrefs.GetString("Code");
    }
}
