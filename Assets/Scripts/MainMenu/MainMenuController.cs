using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

#pragma warning disable 649

public class MainMenuController : MonoBehaviour
{
    #region Constructor
    MenuSettings _menuSettings;

    [Inject]
    public void Construct(MenuSettings menuSettings)
    {
        _menuSettings = menuSettings;
    }
    #endregion

    #region GameLogic

    [SerializeField] Text difficultyText;
    GameDifficulty _selectedDifficulty;
    int _difficultyIndex;
    private void Start()
    {
        _difficultyIndex = (int)_selectedDifficulty;
        Debug.Log(_menuSettings.GetCurrentDifficulty);
        ChangeDifficulty();
        _menuSettings.SetCurrentLevel = 0;
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
        _menuSettings.SetCurrentLevel=_menuSettings.GetCurrentLevel+1;
        LoadSceneMode loadMode = LoadSceneMode.Single;
        SceneManager.LoadScene(_menuSettings.GetCurrentLevel, loadMode);
    }
    public void ChangeDifficulty()
    {
        _difficultyIndex++;

        if (IsDifficultyIndexTooBig(_difficultyIndex))
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
        _menuSettings.SetCurrentDifficulty = _selectedDifficulty;
    }
    bool IsDifficultyIndexTooBig(int index)
    {
        return index >= Enum.GetNames(typeof(GameDifficulty)).Length ? true : false;
    }
    public void Dispose()
    {
        Destroy(gameObject);
    }

    #endregion

}