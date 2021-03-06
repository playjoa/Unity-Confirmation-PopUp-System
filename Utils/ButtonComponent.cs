using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopUps.Utils
{
    public class ButtonComponent : Button
    {
        [SerializeField] private Image thisImage;
        [SerializeField] private TextMeshProUGUI thisText;
        [SerializeField] private ButtonTweenAnimations thisButtonAnimations;
        
        public Image Image => thisImage;
        public TextMeshProUGUI Text => thisText;
        public ButtonTweenAnimations ButtonAnimations => thisButtonAnimations;

        private const string TextName = "txtButtonInfo";

        private void OnValidate()
        {
            thisImage = GetComponent<Image>();
            thisText = GetComponentInChildren<TextMeshProUGUI>();
            thisButtonAnimations = GetComponent<ButtonTweenAnimations>();

            if (thisButtonAnimations == null)
                thisButtonAnimations = gameObject.AddComponent<ButtonTweenAnimations>();
            
            if (thisText) thisText.name = TextName;
        }

        public void Disable() => interactable = false;
        public void Enable() => interactable = true;
    }
}