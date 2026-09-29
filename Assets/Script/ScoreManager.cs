using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _balls;
    [SerializeField] private TextMeshProUGUI _balls2;
    [SerializeField] private GameObject _myPanelWin;
    private Enemy _enemySpped;

    public int CurrentNumber = 0;

    private void Start()
    {
        UpdateText();
    }

    private void OnEnable()
    {
        Enemy.EnemyDeath += OnEnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.EnemyDeath -= OnEnemyDeath;
    }

    private void OnEnemyDeath(int score)
    {
        AddScore(score);
        if (CurrentNumber >= 1400)
        {
            if (_myPanelWin != null)
            {
                _myPanelWin.SetActive(true);

                Time.timeScale = 0f;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    private void AddScore(int amount)
    {
        Debug.Log("popal");
        CurrentNumber += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        _balls.text = CurrentNumber.ToString();
        _balls2.text = CurrentNumber.ToString();
    }
}