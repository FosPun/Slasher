using UnityEngine;
using Zenject;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private AttackSO CurrentAttack;
    
    private PlayerInputHandler _playerInputHandler;
    private PlayerCharacter _playerCharacter;
    

    [Inject]
    private void Construct(PlayerInputHandler playerInputHandler, PlayerCharacter playerCharacter)
         {
        _playerInputHandler = playerInputHandler;
        _playerCharacter = playerCharacter;
         }
    private void OnEnable()
    {
        _playerInputHandler.OnLightInput += ExecuteAttack;
    }

    private void ExecuteAttack()
    {
        _playerCharacter.TryAttack(CurrentAttack);
    }

    private void OnDisable()
    { 
        _playerInputHandler.OnLightInput -= ExecuteAttack;
    }
}
