namespace Combat
{
    public interface IHitTypeData
    {
        HitType HitType { get; }

        bool IsRecoveryBack { get; }

        float Duration { get; }

        float Delay { get; }
    }
}
