using System;

public class PlayerHealth : Health
{
    public static event Action OnHealthOver;

    public override void DecreaseHealth(int healthDecreaseValue)
    {
        base.DecreaseHealth(healthDecreaseValue);
        
        if (_networkHealth.Value <= 0)
        {
            if (OnHealthOver != null)
                OnHealthOver();

            _networkHealth.Value = 100;
            print("Health is over");
        }
    }
}
