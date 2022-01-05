using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PopUps.Data;
using UnityEngine;

namespace PopUps.Controllers
{
    public class ConfirmationPopUpController : MonoBehaviour
    {
        public static ConfirmationPopUpController ME { get; private set; }

        [SerializeField] private ConfirmationPopUp confirmationPopUp;

        private List<ConfirmationPopUpData> popUpDataList = new List<ConfirmationPopUpData>();
        private Coroutine showPopUpCoroutine;

        private void Awake()
        {
            if (ME == null)
            {
                ME = this;
                DontDestroyOnLoad(this);
                return;
            }
            DestroyImmediate(this);
        }

        public void RequestConfirmationPopUp(string confirmMessage, Action onConfirm, Action onCancel = null,
            ConfirmationButtons buttonConfig = ConfirmationButtons.ConfirmCancel)
        {
            var confirmPopUpInitializeData =
                new ConfirmationPopUpData(confirmMessage, onConfirm, onCancel, buttonConfig);
            EnqueuePopUp(confirmPopUpInitializeData);
        }

        private void EnqueuePopUp(ConfirmationPopUpData initializeData)
        {
            popUpDataList.Add(initializeData);
            showPopUpCoroutine ??= StartCoroutine(ShowPopUp());
        }

        private IEnumerator ShowPopUp()
        {
            while (popUpDataList.Count > 0)
            {
                yield return new WaitUntil(() => !confirmationPopUp.IsShowing);
                confirmationPopUp.Initiate(RequestInitializeData());
            }
            showPopUpCoroutine = null;
        }

        private ConfirmationPopUpData RequestInitializeData()
        {
            var candidateData = popUpDataList.FirstOrDefault();
            popUpDataList.RemoveAt(0);
            return candidateData;
        }
    }
}
