using System;
using PopUps.Base;
using PopUps.Data;
using TMPro;
using UnityEngine;
using Utils.UI;

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
            confirmButton.onClick.AddListener(OnConfirmClick);
            cancelButton.onClick.AddListener(OnCancelClick);
        }

        private void OnDestroy()
        {
            confirmButton.onClick.RemoveListener(OnConfirmClick);
            cancelButton.onClick.RemoveListener(OnCancelClick);
        }

        public override void Initiate(ConfirmationPopUpData initializeData)
        {
            base.Initiate();

            descriptionText.text = initializeData.ConfirmationDescription;
            onConfirm = initializeData.OnConfirm;
            onCancel = initializeData.OnCancel;
            confirmButton.Text.text = initializeData.ConfirmText();
            cancelButton.Text.text = initializeData.CancelText();
        }

        private void ResetActions()
        {
            onConfirm = null;
            onCancel = null;
        }

        private void OnConfirmClick()
        {
            onConfirm?.Invoke();
            ResetActions();
            CloseWithAnimation();
        }

        private void OnCancelClick()
        {
            onCancel?.Invoke();
            ResetActions();
            CloseWithAnimation();
        }
    }
}
