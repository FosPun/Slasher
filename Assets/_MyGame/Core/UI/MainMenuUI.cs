using UnityEngine;
using Zenject;

public class MainMenuUI : MonoBehaviour
{
    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void ClickPlayButton()
    {
        _gameManager.StartGame();
    }
}
