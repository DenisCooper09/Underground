using UnityEngine;

namespace Underground.Systems.CoinsSystem
{
    sealed class SpawnMoneyOnDie : MonoBehaviour
    {
        public void Spawn()
        {
            MoneyGeneratorSpawner.Instance.Spawn(transform);
        }
    }
}
