namespace Combat
{
    public interface IDamagableData
    {
        int Health { get; set; }

        int CurrentHealth { get; set; }

        bool Invincible { get; set; }
    }
}
