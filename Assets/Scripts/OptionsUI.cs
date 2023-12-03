using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soudEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private Button MoveUpButton;
    [SerializeField] private Button MoveDownButton;
    [SerializeField] private Button MoveLeftButton;
    [SerializeField] private Button MoveRightButton;
    [SerializeField] private Button InteractButton;
    [SerializeField] private Button InteractAltButton;
    [SerializeField] private Button PauseButton;


    [SerializeField] private TextMeshProUGUI MoveUpButtonText;
    [SerializeField] private TextMeshProUGUI MoveDownButtonText;
    [SerializeField] private TextMeshProUGUI MoveLeftButtonText;
    [SerializeField] private TextMeshProUGUI MoveRightButtonText;
    [SerializeField] private TextMeshProUGUI InteractButtonText;
    [SerializeField] private TextMeshProUGUI InteractAltButtonText;
    [SerializeField] private TextMeshProUGUI PauseButtonText;
    [SerializeField] private Transform pressToRebindKeyTransform;

    private Action onCloseButtonAction;

    private void Awake()
    {
        Instance = this;
        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
            onCloseButtonAction.Invoke();
        });

        MoveUpButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.MoveUp));
        MoveDownButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.MoveDown));
        MoveLeftButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.MoveLeft));
        MoveRightButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.MoveRight));
        InteractButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.Interact));
        InteractAltButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.InteractAlt));
        PauseButton.onClick.AddListener(() => RebindBinding(GameInput.Binding.Pause));

    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        UpdateVisual();
        HidePressToRebindKey();
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soudEffectsText.text = "Sound Effects:" + Mathf.Round(SoundManager.Instance.GetVolumn() * 10f);
        musicText.text = "Music:" + Mathf.Round(MusicManager.Instance.GetVolumn() * 10f);

        MoveUpButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveUp);
        MoveDownButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveDown);
        MoveLeftButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveLeft);
        MoveRightButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveRight);
        InteractButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        InteractAltButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlt);
        PauseButtonText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }

    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);

        soundEffectsButton.Select();
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    public void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    public void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.Rebinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
