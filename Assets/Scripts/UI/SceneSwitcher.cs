using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    private readonly Game _game;
    private GameState _previousState;
    
    public SceneSwitcher(Game game)
    {
        _game = game;
        _game.GameStateChange += OnStateChange;
    }

    private void OnStateChange(GameState state)
    {
        if (state == GameState.Game && _previousState != GameState.Pause)
        {
            SceneManager.LoadScene("Level");
        }
        
        if (state == GameState.MainMenu)
        {
            SceneManager.LoadScene("Menu");
        }
        
        _previousState = state;
    }
}