using TweenerSystem;
using UnityEngine;

namespace PopUps.Base
{
    public abstract class PopUp<T> : MonoBehaviour where T : struct
    {
        [Header("Animation Components")] 
        [SerializeField] protected LeanTweenerAnimation tweenAnimation;
        [SerializeField] protected LeanTweenerUISlideAnimation tweenUISlideAnimation;

        public bool IsShowing => gameObject.activeSelf;
        
        public virtual void Initiate(T initiateData) => gameObject.SetActive(true);
        public virtual void Initiate() => gameObject.SetActive(true);
        public virtual void ClosePopUp() => gameObject.SetActive(false);

        public virtual void CloseWithAnimation()
        {
            if (tweenAnimation)
                tweenAnimation.CloseAnimation();
            
            if(tweenUISlideAnimation)
                tweenUISlideAnimation.SlideOut();
        }
    }
}