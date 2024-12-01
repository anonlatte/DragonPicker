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
        SceneManager.LoadScene("_1Scene", LoadSceneMode.Single);
        Application.Quit();
    }
}