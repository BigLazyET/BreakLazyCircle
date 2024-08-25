using AIShared;

namespace BreakLazyCircle.Minions
{
    public class Patroler : Entity
    {
        public Patroler_IdleState IdleState { get; private set; }

        public Patroler_PlayerDetectedState PlayerDetectedState { get; private set; }
    }
}

