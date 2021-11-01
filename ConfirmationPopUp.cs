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
        
        private Action OnConfirm;
        private Action OnCancel;

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
            OnConfirm = initializeData.OnConfirm;
            OnCancel = initializeData.OnCancel;

            if (initializeData.ConfirmText != string.Empty)
                confirmButton.ButtonText.text = initializeData.ConfirmText;     
            
            if (initializeData.CancelText != string.Empty)
                cancelButton.ButtonText.text = initializeData.CancelText;
        }

        private void OnConfirmClick()
        {
            OnConfirm?.Invoke();
            CloseWithAnimation();
        }
        
        private void OnCancelClick()
        {
            OnCancel?.Invoke();
            CloseWithAnimation();
        }
    }
    
    public struct ConfirmationPopUpData
    {
        public string ConfirmationDescription { get; private set; }
        public string CancelText { get; private set; }
        public string ConfirmText { get; private set; }
        public Action OnConfirm { get; private set; }
        public Action OnCancel { get; private set; }

        public ConfirmationPopUpData(string confirmationDescription, Action confirm, Action cancel, string confirmText = "", string cancelText = "")
        {
            ConfirmationDescription = confirmationDescription;
            OnConfirm = confirm;
            OnCancel = cancel;
            ConfirmText = confirmText;
            CancelText = cancelText;
        }
    }
}