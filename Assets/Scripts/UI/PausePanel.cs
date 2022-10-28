using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PausePanel : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;

        private void Start()
        {
            _pauseButton.onClick.AddListener(PauseButtonOnClicked);
            _resumeButton.onClick.AddListener(ResumeButtonOnClicked);
            _restartButton.onClick.AddListener(RestartButtonOnClicked);
            _menuButton.onClick.AddListener(MenuButtonOnClicked);
        }

        private void PauseButtonOnClicked()
        {
            Time.timeScale = 0;
            _pausePanel.SetActive(true);
        }

        private void ResumeButtonOnClicked()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        private void RestartButtonOnClicked()
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1;
        }

        private void MenuButtonOnClicked()
        {
            SceneManager.LoadScene("Menu");
            Time.timeScale = 1;
        }

        private void OnDestroy()
        {
            _pauseButton.onClick.RemoveListener(PauseButtonOnClicked);
            _resumeButton.onClick.RemoveListener(ResumeButtonOnClicked);
            _restartButton.onClick.RemoveListener(RestartButtonOnClicked);
            _menuButton.onClick.RemoveListener(MenuButtonOnClicked);
        }
    }
}
