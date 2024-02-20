using UnityEngine;

namespace Enhance.Runtime
{
    public class ParticleSystemLifecycleController : MonoBehaviour
    {
        private void OnParticleSystemStopped()
        {
            ObjectPoolingManager.ReturnObjectToPool(gameObject);
        }
    }
}
