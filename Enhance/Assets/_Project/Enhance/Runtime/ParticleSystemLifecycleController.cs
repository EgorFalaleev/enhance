using UnityEngine;

public class ParticleSystemLifecycleController : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        ObjectPoolingManager.ReturnObjectToPool(gameObject);
    }
}
