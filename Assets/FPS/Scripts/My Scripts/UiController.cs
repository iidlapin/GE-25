using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerScore;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void UpdateScore()
    {
        PlayerScore.text = gameManager.score.ToString();

    }
}
