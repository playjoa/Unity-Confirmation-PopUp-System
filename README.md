# Unity_Confirmation_PopUp_System

## Easily Request as many Confirmation PopUps as you want
* It manages PopUp requests and shows them in order!

```C#
private void ShowPopUp()
{
    var popUpDescription = "Do you wish to do this?";
    var confirmButtonText = "YES";
    var cancelButtonText = "NO";

    ConfirmationPopUpController.ME.RequestConfirmationPopUp(
        popUpDescription, 
        OnConfirm,
        OnCancel,
        confirmButtonText,
        cancelButtonText);
}

private void OnConfirm()
{
    Debug.Log("CONFIRMING ORDER!");
}

private void OnCancel()
{
    Debug.Log("CANCELING ORDER!");
}
```

* <strong>Obs:</strong> It comes with some handy Tween animations and a PopUpSystem that you can expand into whatever you want!