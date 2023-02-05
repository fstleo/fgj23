using System;
using UnityEngine;

public class GameInstaller : Installer
{

    [SerializeField] private TreeRoot _tree;
    
    protected override void Initialize()
    {
        _tree.Deadge += () => GameInstance.GameOver();
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Cancel"))
        {
            return;
        }
        switch (GameInstance.State)
        {
            case GameState.Pause:
                GameInstance.Return();
                break;
            case GameState.Game:
                GameInstance.Pause();
                break;
            case GameState.MainMenu:
                GameInstance.Exit();
                break;
            case GameState.GameOver:
                GameInstance.ToMainMenu();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
}