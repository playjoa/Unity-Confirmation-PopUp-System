using System;
using TMPro;
using UnityEngine;
using PopUps.Utils;

namespace PopUps
{
    public class ConfirmationPopUp : PopUp<ConfirmationPopUpData>
    {
        [Header("Confirmation PopUp Components")] 
        [SerializeField] private TextMeshProUGUI descriptionText;
        [SerializeField] private ButtonComponent confirmButton;
        [SerializeField] private ButtonComponent cancelButton;

        private Action onConfirm;
        private Action onCancel;

        private void Awake()
        {
            confirmButton.Button.onClick.AddListener(OnConfirmClick);
            cancelButton.Button.onClick.AddListener(OnCancelClick);
        }

        private void OnDestroy()
        {
            confirmButton.Button.onClick.RemoveAllListeners();
            cancelButton.Button.onClick.RemoveAllListeners();
        }

        public override void Initiate(ConfirmationPopUpData initializeData)
        {
            base.Initiate();

            descriptionText.text = initializeData.ConfirmationDescription;
            onConfirm = initializeData.OnConfirm;
            onCancel = initializeData.OnCancel;
            confirmButton.ButtonText.text = initializeData.ConfirmText();
            cancelButton.ButtonText.text = initializeData.CancelText();
        }

        private void OnConfirmClick()
        {
            onConfirm?.Invoke();
            CloseWithAnimation();
        }

        private void OnCancelClick()
        {
            onCancel?.Invoke();
            CloseWithAnimation();
        }
    }
}