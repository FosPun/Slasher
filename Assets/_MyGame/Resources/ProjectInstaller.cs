using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SkillPointsManager _skillPointsManager;
    [SerializeField] private SkillTreeManager _skillTreeManager;
    [SerializeField] private PlayerDataSO _playerData;
    public override void InstallBindings()
    {
        Container.BindInstance(_gameManager).AsSingle();
        Container.BindInstance(_skillPointsManager).AsSingle();
        Container.BindInstance(_skillTreeManager).AsSingle();
        Container.BindInstance(_playerData).AsSingle();
    }
}