using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Underground.Systems.CoinsSystem
{
    sealed class CoinsCollector : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnCoinColleted;

        private ParticleSystem _particleSystem = null;
        private readonly List<ParticleSystem.Particle> _particles = new();

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        private void OnParticleTrigger()
        {
            int triggredParticles = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _particles);

            for (int i = 0; i < triggredParticles; i++)
            {
                ParticleSystem.Particle particle = _particles[i];
                particle.remainingLifetime = 0f;
                OnCoinColleted?.Invoke();
                _particles[i] = particle;
            }

            _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, _particles);
        }
    }
}
