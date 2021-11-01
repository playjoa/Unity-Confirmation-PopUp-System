using UnityEngine;

namespace Gameplay.UI_System.PopUps
{
    public abstract class PopUp<T> : MonoBehaviour where T : struct
    {
        [Header("Animation Components")] [SerializeField]
        protected TweenerAnimation tweenAnimation;

        public bool IsShowing => gameObject.activeSelf;
        
        public virtual void Initiate(T initiateData) => gameObject.SetActive(true);
        public virtual void Initiate() => gameObject.SetActive(true);
        public virtual void ClosePopUp() => gameObject.SetActive(false);

        public virtual void CloseWithAnimation()
        {
            if (!tweenAnimation)
            {
                Debug.LogError($"No TweenAnimation on {gameObject.name}");
                return;
            }

            tweenAnimation.CloseAnimation();
        }
    }
}