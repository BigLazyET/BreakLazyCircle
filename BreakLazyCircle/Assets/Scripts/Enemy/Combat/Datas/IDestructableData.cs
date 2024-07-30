using System;

namespace BreakLazyCircle.Combat
{
    public interface IDestructableData
    {
        int Health { get; set; }

        int CurrentHealth { get; set; }

        bool Invincible { get; set; }
    }
}
