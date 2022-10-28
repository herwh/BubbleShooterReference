using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _modeButton;
        [SerializeField] private TMP_Text _modeButtonText;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _startButton.onClick.AddListener(StartButtonClicked);
            _modeButton.onClick.AddListener(ModeButtonClicked);
            _exitButton.onClick.AddListener(ExitButtonClicked);

            _modeButtonText.text = $"Mode: {(Mode) GetCurrentMode()}";
        }

        private void StartButtonClicked()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void ModeButtonClicked()
        {
            var currentMode = GetCurrentMode();
            currentMode = (currentMode + 1) % 2;
            PlayerPrefs.SetInt("Mode", currentMode);

            _modeButtonText.text = $"Mode: {(Mode) currentMode}";
        }

        private int GetCurrentMode()
        {
            return PlayerPrefs.GetInt("Mode", (int) Mode.Random);
        }

        private void ExitButtonClicked()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(StartButtonClicked);
            _modeButton.onClick.RemoveListener(ModeButtonClicked);
            _exitButton.onClick.RemoveListener(ExitButtonClicked);
        }
    }
}
