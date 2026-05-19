using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Screens")]
    public GameObject titleScreen;
    public GameObject gameScreen;
    public GameObject playAgainScreen;
    public GameObject leaderboardScreen;
    public GameObject instructionScreen;

    [Header("UI Text")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI leaderboardText;
    public TextMeshProUGUI playAgainReasonText;

    [Header("Players")]
    public Transform player1;
    public Transform player2;

    [Header("Camera Bounds")]
    public float screenBufferY = 2f;

    private float timer = 0f;
    private bool isPlaying = false;
    private List<float> leaderboard = new List<float>();
    private MapGeneratorScript mapGenerator;
    private Camera mainCam;
    public bool isGameOver = false;
    private bool cameFromPlayAgain = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        mainCam = Camera.main;
        mapGenerator = Object.FindFirstObjectByType<MapGeneratorScript>();
        ShowTitleScreen();
    }

    void Update()
    {
        if (!isPlaying) return;

        timer += Time.deltaTime;
        timerText.text = FormatTime(timer);

        if (player1 != null && player2 != null)
        {
            float camBottom = mainCam.transform.position.y - mainCam.orthographicSize - screenBufferY;
            float highestY = Mathf.Max(player1.position.y, player2.position.y);
            float maxVerticalGap = 15f;

            if (player1.position.y < camBottom || player2.position.y < camBottom ||
                highestY - player1.position.y > maxVerticalGap ||
                highestY - player2.position.y > maxVerticalGap)
            {
                EndRound(false, "A player fell behind!");
            }
        }
    }

    public void ShowTitleScreen()
    {
        isPlaying = false;
        titleScreen.SetActive(true);
        gameScreen.SetActive(false);
        playAgainScreen.SetActive(false);
        leaderboardScreen.SetActive(false);
        if (instructionScreen != null) instructionScreen.SetActive(false);
    }

    public void ShowInstructions()
    {
        titleScreen.SetActive(false);
        if (instructionScreen != null) instructionScreen.SetActive(true);
    }

    public void BackToTitle()
    {
        if (instructionScreen != null) instructionScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void StartGame()
    {
        isGameOver = false;
        timer = 0f;
        isPlaying = true;
        titleScreen.SetActive(false);
        if (instructionScreen != null) instructionScreen.SetActive(false);
        gameScreen.SetActive(true);
        playAgainScreen.SetActive(false);
        leaderboardScreen.SetActive(false);
        mapGenerator.GenerateMap();
    }

    public void WinRound()
    {
        EndRound(true, "");
    }

    void EndRound(bool won, string reason)
    {
        isGameOver = true;
        isPlaying = false;

        if (won)
        {
            leaderboard.Add(timer);
            leaderboard.Sort();
            playAgainReasonText.text = "You escaped in " + FormatTime(timer) + "!";
        }
        else
        {
            playAgainReasonText.text = reason;
        }

        gameScreen.SetActive(false);
        playAgainScreen.SetActive(true);
    }

    public void PlayAgain()
    {
        StartGame();
    }

    public void ShowLeaderboardFromTitle()
    {
        cameFromPlayAgain = false;
        titleScreen.SetActive(false);
        leaderboardScreen.SetActive(true);
        UpdateLeaderboardText();
    }

    public void ShowLeaderboard()
    {
        cameFromPlayAgain = true;
        playAgainScreen.SetActive(false);
        leaderboardScreen.SetActive(true);
        UpdateLeaderboardText();
    }

    void UpdateLeaderboardText()
    {
        if (leaderboard.Count == 0)
        {
            leaderboardText.text = "No times yet!";
            return;
        }

        string board = "Top Times:\n\n";
        for (int i = 0; i < Mathf.Min(leaderboard.Count, 3); i++)
        {
            board += (i + 1) + ". " + FormatTime(leaderboard[i]) + "\n";
        }
        leaderboardText.text = board;
    }

    public void BackFromLeaderboard()
    {
        leaderboardScreen.SetActive(false);
        if (cameFromPlayAgain)
        {
            playAgainScreen.SetActive(true);
        }
        else
        {
            titleScreen.SetActive(true);
        }
    }

    string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time * 100) % 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}