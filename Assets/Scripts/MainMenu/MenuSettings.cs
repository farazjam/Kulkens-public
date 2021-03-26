public class MenuSettings
{
    public MenuSettings()
    {

    }
    //private vars
    GameDifficulty _gameDifficulty;
    int _currentLevel;
    int _currentLives;
    //getters
    public GameDifficulty GetCurrentDifficulty { get => _gameDifficulty; }
    public int GetCurrentLevel { get => _currentLevel; }
    public int GetCurrentLives { get => _currentLives; }
    //setters
    public GameDifficulty SetCurrentDifficulty { set => _gameDifficulty = value; }
    public int SetCurrentLevel { set => _currentLevel = value; }
    public int SetCurrentLives { set => _currentLives = value; }
}
