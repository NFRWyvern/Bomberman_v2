using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button ResumeButton;
    public Button RestartButton;
    public Button QuitButton;
    public TMP_Dropdown PlayerSelectDropdown;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI player3ScoreText;
    public TextMeshProUGUI player4ScoreText;
    public int Player1;
    public int Player2;
    public int Player3;
    public int Player4;
    public int YourCurrentScore;
    
    private int High_Score = 0;

    void Start()
    {
        ResumeButton.onClick.AddListener(Resume);
        RestartButton.onClick.AddListener(Restart);
        QuitButton.onClick.AddListener(Quit);
        
        // Load the high score when the game starts
        LoadHighScore();
    }

    void Update()
    {
        // Check if the player selection menu is active and update the number of players accordingly
        int numPlayers = GetSelectedNumPlayers();

        // Check if the current score is higher than the stored high score
        // Replace 'YourCurrentScore' with your actual score variable
        if (YourCurrentScore > High_Score)
        {
            High_Score = YourCurrentScore; // Update the high score
            SaveHighScore(); // Save the new high score
        }

        // Display the high score in the UI
       highScoreText.text = "High Score: " + High_Score;

        player1ScoreText.text = "Player 1 Score: " + Player1;
        player2ScoreText.text = "Player 2 Score: " + Player2;
        player3ScoreText.text = "Player 3 Score: " + Player3;
        player4ScoreText.text = "Player 4 Score: " + Player4;
        // Repeat for Player3, Player4, etc.
    }

    void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    void Restart()
    {
        DetermineNumberOfPlayers();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", High_Score);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        High_Score = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Quit()
    {
        Application.Quit();
    }

    int GetSelectedNumPlayers()
    {
        return PlayerSelectDropdown.value + 1;
        DisablePlayer();
    }

     Checkplayer = new List<MovementController> {  };

    void DetermineNumberOfPlayers()
    {
        int numPlayers = GetSelectedNumPlayers();

        Debug.Log("Number of Players: " + numPlayers);
    }
}
