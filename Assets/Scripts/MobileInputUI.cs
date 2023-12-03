using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileInputUI : MonoBehaviour
{
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pasueButton;

    private void Start()
    {
        interactButton.onClick.AddListener(() =>
        {
            GameInput.Instance.Interact();
        });
        interactAlternateButton.onClick.AddListener(() =>
        {
            GameInput.Instance.InteractAlternate();
        });
        pasueButton.onClick.AddListener(()=>{
            GameInput.Instance.PauseClick();
        });
    }
}
