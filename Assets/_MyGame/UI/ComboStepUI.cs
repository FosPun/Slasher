using UnityEngine;
using UnityEngine.UI;
using Zenject;
using System;

public class ComboStepUI : MonoBehaviour
{
    public static Action OnComboStepOpened;
    [SerializeField] private AttackSO _previousAttackSo;
    [SerializeField] private AttackSO _attackSo;
    private SkillTreeManager _skillTreeManager;
    private SkillPointsManager _skillPointsManager;
    private Image _image;
    private Button _button;

    [Inject]
    private void Construct(SkillTreeManager skillTreeManage, SkillPointsManager skillPointsManager)
    {
        _skillTreeManager = skillTreeManage;
        _skillPointsManager = skillPointsManager;
    }
    private void Awake()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }
    private void Start()
    {
        _image.sprite = _attackSo.iconSprite;
        CheckComboData();
    }

    private void CheckComboData()
    {
        bool isAlreadyUnlocked = ConfigDynamic.IsUnlocked(_attackSo);
        bool hasEnoughPoints = _skillPointsManager.SkillPoints >= _attackSo.cost;
        bool isPreviousUnlocked = _previousAttackSo == null || ConfigDynamic.IsUnlocked(_previousAttackSo);

        bool canUnlock = !isAlreadyUnlocked && hasEnoughPoints && isPreviousUnlocked;

        _button.interactable = canUnlock;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OpenComboStep);
        OnComboStepOpened += CheckComboData;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
        OnComboStepOpened -= CheckComboData;
    }

    private void OpenComboStep()
    {
        _skillTreeManager.UnlockAttack(_attackSo);
        OnComboStepOpened?.Invoke();
    }
}
