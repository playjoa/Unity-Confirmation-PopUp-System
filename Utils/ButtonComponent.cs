using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopUps.Utils
{
    [RequireComponent(typeof(Button))]
    public class ButtonComponent : MonoBehaviour
    {
        [SerializeField] private Button thisButton;
        [SerializeField] private TextMeshProUGUI thisButtonText;

        public Button Button => thisButton;
        public TextMeshProUGUI ButtonText => thisButtonText;

        private void OnValidate()
        {
            thisButton = GetComponent<Button>();
            thisButtonText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}