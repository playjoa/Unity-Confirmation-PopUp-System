using System;

namespace PopUps.Data
{
    public struct ConfirmationPopUpData
    {
        public string ConfirmationDescription { get; private set; }
        public ConfirmationButtons ButtonConfig { get; private set; }
        public Action OnConfirm { get; private set; }
        public Action OnCancel { get; private set; }

        public ConfirmationPopUpData(string confirmationDescription, Action confirm, Action cancel,
            ConfirmationButtons buttonConfig = ConfirmationButtons.OkCancel)
        {
            ConfirmationDescription = confirmationDescription;
            OnConfirm = confirm;
            OnCancel = cancel;
            ButtonConfig = buttonConfig;
        }

        public string ConfirmText()
        {
            return ButtonConfig switch
            {
                ConfirmationButtons.OkCancel => "Ok",
                ConfirmationButtons.ConfirmCancel => "Confirm",
                ConfirmationButtons.YesNo => "Yes",
                ConfirmationButtons.ContinueBack => "Continue",
                _ => ""
            };
        }

        public string CancelText()
        {
            return ButtonConfig switch
            {
                ConfirmationButtons.OkCancel => "Cancel",
                ConfirmationButtons.ConfirmCancel => "Cancel",
                ConfirmationButtons.YesNo => "No",
                ConfirmationButtons.ContinueBack => "Back",
                _ => ""
            };
        }
    }

    public enum ConfirmationButtons
    {
        OkCancel,
        ConfirmCancel,
        YesNo,
        ContinueBack
    }
}