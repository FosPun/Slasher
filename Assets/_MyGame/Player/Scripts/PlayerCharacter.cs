using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    [SerializeField] private AttackSO baseLightAttack;
    [SerializeField] private AttackSO baseHeavyAttack;

    private PlayerInputHandler _playerInputHandler;
    private PlayerCombo _playerCombo;

    private StateMachine _stateMachine;

    [Inject]
    private void Construct(
        PlayerInputHandler playerInputHandler,
        StateMachine stateMachine,
        PlayerAnimator animator,
        PlayerCombo playerCombo
    )
    {
        _stateMachine = stateMachine;
        _playerInputHandler = playerInputHandler;
        _playerCombo = playerCombo;
    }

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        _playerInputHandler.OnLightInput += HandleLightAttack;
        _playerInputHandler.OnHeavyInput += HandleHeavyAttack;
    }

    private void OnDisable()
    {
        _playerInputHandler.OnLightInput -= HandleLightAttack;
        _playerInputHandler.OnHeavyInput -= HandleHeavyAttack;
    }

    protected override void Initialize()
    {
        _stateMachine.Initialize<IdleState>();
    }

    private void Update()
    {
        _stateMachine.Execute(); // Возвращаем работу StateMachine!
    }

    private void HandleLightAttack(AttackInput input)
    {
        TryAttack(input, baseLightAttack);
    }

    private void HandleHeavyAttack(AttackInput input)
    {
        TryAttack(input, baseHeavyAttack);
    }

    private void TryAttack(AttackInput input, AttackSO baseAttack)
    {
        if (_playerCombo.TryProcessAttackInput(input, baseAttack)) _stateMachine.ChangeState<AttackState>();
    }
}