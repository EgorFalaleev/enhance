using Enhance.Data;
using UnityEngine;

namespace Enhance.Runtime
{
    public interface IShooter
    {
        public void Shoot(BulletConfigSO bulletConfig, Transform shootPosition);
    }
}