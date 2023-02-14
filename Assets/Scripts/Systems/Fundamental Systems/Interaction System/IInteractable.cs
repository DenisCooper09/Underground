using UnityEngine;

namespace Underground.Systems.FundamentalSystems.InteractionSystem
{
    interface IInteractable
    {
        void Interact();
        GameObject GetUI();
    }
}
