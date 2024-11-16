
using Godot;

public partial class HealthBar : Label
{
    private int _totalHP;
    private int _currentHP;

    public HealthBar(int totalHP)
    {
        _totalHP = totalHP;
        _currentHP = totalHP;
    }
    public void SetHealth(int hp)
    {
        _currentHP = hp;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        Text = $"{_currentHP}";
    }
}