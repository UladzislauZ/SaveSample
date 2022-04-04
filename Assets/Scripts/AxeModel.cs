public class AxeModel
{
    private float _damage;
    private int _level;

    public AxeModel()
    {
        _level = 1;
        UpdateDamage();
    }

    public AxeModel(int level)
    {
        _level = level;
        UpdateDamage();
    }

    public int GetLevel() => _level;

    public float GetDamage() => _damage;

    public void SetLevel(int level)
    {
        _level = level;
        UpdateDamage();
    }

    public void UpgradeLevel()
    {
        _level++;
        UpdateDamage();
    }

    private void UpdateDamage()
    {
        _damage = 5 * (_level * 2);
    }
}