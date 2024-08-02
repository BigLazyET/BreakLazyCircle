namespace Combat
{
    public interface IHitTypeInflatData : IHitTypeData
    {
        /// <summary>
        /// x碰撞系数
        /// </summary>
        float XScale { get; set; }

        /// <summary>
        /// y碰撞系数
        /// </summary>
        float YScale { get; set; }

        /// <summary>
        /// z膨胀系数
        /// </summary>
        float ZScale { get; set; }
    }
}
