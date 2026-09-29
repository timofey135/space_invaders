using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Enemy : EnemyGrid
{
    //[SerializeField] private TextMeshProUGUI _balls;
    [SerializeField] private int _priceBallsEnemy;
    private ScoreManager _scoreManager;

    // жизни врага
    [SerializeField] private int _healthEnemy;
    private int _gameOverstat = 1;

    // скорость игрока
    [SerializeField] private float _speed;
    [SerializeField] private float _speedBonus;
    public static event Action<int> EnemyDeath;
    [SerializeField] private float _speedLanding;
    [SerializeField] private float _speedLandingBonus;

    // объект игрока
    [SerializeField] private GameObject _enemy;

    // время пробега
    [SerializeField] private float _timeSpeed;
    [SerializeField] private float _timeSpeedCorrect;
    [SerializeField] private float _timeLanding;
    [SerializeField] private float _timeLandingCorrect;

    private int _currentStep = 0;
    private float _timeCounter = 0f;

    // пули
    protected bool isShootedEnemy = false;
    [SerializeField] protected GameObject bulletPrefabEnemy;
    [SerializeField] protected Transform firePointEnemy;
    [SerializeField] protected Vector2 firePointSpeed;
    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    void Update()
    {
        Movement();


    }

    // получение урона (не работает)
    public void TakeDamageEnemy(int damage)
    {
        _healthEnemy -= damage;

        if (_healthEnemy <= 0)
        {
            DeathEnemy();
        }
    }

    // Повышение скорости
    private void IncreaseSpeed(int score)
    {
        _speed += _speedBonus;
        _timeSpeed += _timeSpeedCorrect;
        _speedLanding += _speedLandingBonus;
        _timeLanding += _timeLandingCorrect;

        Debug.Log($"{gameObject.name} ускорился! Новая скорость: {_speed}");
    }

    private void OnEnable()
    {
        EnemyDeath += IncreaseSpeed;
    }

    private void OnDisable()
    {
        EnemyDeath -= IncreaseSpeed;
    }

    // Смерть игрока
    public void DeathEnemy()
    {
        Debug.Log("контакт");

        EnemyDeath?.Invoke(_priceBallsEnemy);

        Destroy(gameObject);
    }


    // стрельба врага
    private IEnumerator ShootRoutine()
    {
        while (true)
        {

            float randomDelay = UnityEngine.Random.Range(firePointSpeed.x, firePointSpeed.y);

            yield return new WaitForSeconds(randomDelay);

            ShotEnemy();
        }
    }

    public void ShotEnemy()
    {
        if (bulletPrefabEnemy != null && firePointEnemy != null)
            {
            Instantiate(bulletPrefabEnemy, firePointEnemy.position, firePointEnemy.rotation);
            isShootedEnemy = true;
        }
    }


    // передвижение врага
    public void Movement()
    {
        switch (_currentStep)
        {
            case 0:
                _enemy.transform.position += Vector3.left * _speed * Time.deltaTime;
                _timeCounter += Time.deltaTime;
                if (_timeCounter >= _timeSpeed)
                {
                    _timeCounter = 0f;
                    _currentStep = 1;
                }
                break;

            case 1:
                _enemy.transform.position += Vector3.down * _speedLanding * Time.deltaTime;
                _timeCounter += Time.deltaTime;

                if (_timeCounter >= _timeLanding)
                {
                    _timeCounter = 0f;
                    _currentStep = 2;
                }
                break;

            case 2:
                _enemy.transform.position += Vector3.right * _speed * Time.deltaTime;
                _timeCounter += Time.deltaTime;
                if (_timeCounter >= _timeSpeed)
                {
                    _timeCounter = 0f;
                    _currentStep = 3;
                }
                break;
            case 3:
                _enemy.transform.position += Vector3.down * _speedLanding * Time.deltaTime;
                _timeCounter += Time.deltaTime;

                if (_timeCounter >= _timeLanding)
                {
                    _timeCounter = 0f;
                    _currentStep = 0;
                }
                break;
        }
    }
}
