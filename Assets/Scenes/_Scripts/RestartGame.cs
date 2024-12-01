using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Button restartBtn;

    void Start()
    {
        Button btn = restartBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnRestartButtonClick);
    }

    void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Application.Quit();
    }
}