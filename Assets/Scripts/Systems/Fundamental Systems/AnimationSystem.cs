using UnityEngine;
using NaughtyAttributes;

namespace Underground.Systems.FundamentalSystems
{
    [RequireComponent(typeof(Animator))]
    sealed class AnimationSystem : MonoBehaviour
    {
        [SerializeField] private Animator m_Animator = null;
        [SerializeField, AnimatorParam(nameof(m_Animator))] private string m_ParameterName;

        private Vector2 _originalScale = Vector2.zero;

        private void Awake()
        {
            _originalScale = transform.localScale;
        }

        public void PlayAnimation(Vector2 movementInput)
        {
            m_Animator.SetBool(m_ParameterName, movementInput.magnitude > 0f);
        }

        public void RotateToPointer(Vector2 pointerPosition)
        {
            Vector2 scale = transform.localScale;
            scale.x = pointerPosition.x > transform.position.x ? _originalScale.x : -_originalScale.x;
            transform.localScale = scale;
        }
    }
}
