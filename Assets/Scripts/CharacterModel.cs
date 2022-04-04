public class CharacterModel
{
    private int _level;
    private float _score;
    private float _speedMove;
    private float _speedRotate;
    private AxeModel _axe;

    public CharacterModel()
    {
        _level = 1;
        _score = 0;
        UpdateSpeed();
        _axe = new AxeModel();
    }

    public CharacterModel(int level, float score, int levelAxe)
    {
        _level = level;
        _score = score;
        UpdateSpeed();
        _axe = new AxeModel(levelAxe);
    }

    public float Score() => _score;

    public bool Buy(int value)
    {
        if (_score < value)
            return false;

        _score -= value;
        return true;
    }

    public float DamageAxe() => _axe.GetDamage();

    public int LevelAxe() => _axe.GetLevel();

    public void AddScore(float value) => _score += value;

    public int Level() => _level;

    public float SpeedMove() => _speedMove;
    
    public float SpeedRotate() => _speedRotate;

    public void UpgradeAxe()
    {
        _axe.UpgradeLevel();
    }

    public void UpgradeLevel()
    {
        _level++;
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        _speedMove = 10f + (_level * 2);
        _speedRotate = 25f + (_level * 2);
    }
}