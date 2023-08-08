using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] GameObject _gameOverCanvas;
    [SerializeField] TextMeshProUGUI _gameOverScore;
    float _timer = 0;
    int _score = 0;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AddScore(0);
        _gameOverCanvas.SetActive(false);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        _timeText.text = _timer.ToString("F2");
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = "Score:" + _score.ToString("D8");
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        _gameOverScore.text = "Score\r\n" + _score.ToString("D8");
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
