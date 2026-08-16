using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerCharacter playerCharacter;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private CombatManager combatManager;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private CoinManager coinManager;
    public override void InstallBindings()
    {
        Container.BindInstance(playerCharacter).AsSingle();
        Container.BindInstance(combatManager).AsSingle();
        Container.BindInstance(coinManager).AsSingle();
        Container.BindInstance(spawner).AsSingle();
        Container.BindInstance(levelManager).AsSingle();
    }
}
