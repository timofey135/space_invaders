using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;

    void Start()
    {
        losePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TaskOnClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
