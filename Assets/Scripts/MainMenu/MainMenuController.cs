using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#pragma warning disable 649

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Text difficultyText;
    GameDifficulty _selectedDifficulty;
    int _difficultyIndex;
    private void Start()
    {
        _difficultyIndex = (int)_selectedDifficulty;
        ChangeDifficulty();
        PublicStaticSettings.CurrentLevel = 0;
    }
    private void Update()
    {
        PlayerInput();
    }
    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            ChangeDifficulty();
        }
    }
    public void LoadNextScene()
    {
        PublicStaticSettings.CurrentLevel++;
        LoadSceneMode loadMode = LoadSceneMode.Single;
        SceneManager.LoadScene(PublicStaticSettings.CurrentLevel, loadMode);
    }
    public void ChangeDifficulty()
    {
        _difficultyIndex++;
        if (_difficultyIndex >= Enum.GetNames(typeof(GameDifficulty)).Length)
            _difficultyIndex = 0;
        _selectedDifficulty = (GameDifficulty)_difficultyIndex;
        switch (_selectedDifficulty)
        {
            case GameDifficulty.Easy:
                difficultyText.text = "Difficulty : Easy";
                break;
            case GameDifficulty.Normal:
                difficultyText.text = "Difficulty : Normal";
                break;
            case GameDifficulty.Hard:
                difficultyText.text = "Difficulty : Hard";
                break;
        }
        PublicStaticSettings.GameDifficulty = _selectedDifficulty;
    }
    public void Dispose()
    {
        Destroy(gameObject);
    }


}