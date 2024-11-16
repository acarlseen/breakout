using System.Collections.Generic;
using Godot;

public partial class Brick : StaticBody2D
{
    CollisionShape2D _hitbox;
    ColorRect _colorRect;
    Label _healthBar;
    private int _hp;
    static Color[] palette = { 
        Colors.OrangeRed, 
        Colors.Gold, 
        Colors.DodgerBlue, 
        Colors.LimeGreen 
        };


    public override void _Ready()
    {
        base._Ready();
        Ball.CollisionEvent += TakeHit;

        _hitbox = GetNode<CollisionShape2D>("BrickBody");
        _colorRect = GetNode<ColorRect>("ColorRect");
        _healthBar = GetNode<Label>("HPLabel");
        _hp = (int)(GD.Randi() % palette.Length) +1;
        MakeBrick();
        _healthBar.Text = _hp.ToString();
    }

    public Brick()
    {
    }

    private void MakeBrick()
    {

        _colorRect.Color = palette[_hp-1];
        GD.Print($"_HP IS SET TO {_hp}");
    }

    private void SetColor(int index)
    {

    }
    public override void _ExitTree()
    {
        base._ExitTree();
        Ball.CollisionEvent -= TakeHit;
    }

    public void TakeHit(GodotObject obj)
    {
        if (this != obj)
            return;

        _hp -= 1;
        // _healthBar.Text = _hp.ToString();
        _healthBar.Text = _hp.ToString();
        if (_hp <= 0)
        {
            DestroyBrick();
            return;
        }
        _colorRect.Color = palette[_hp - 1];


        // GD.Print($"This : {this} and OBJ : {obj}");
        // if (this == obj)
        // {
        //     _hitbox.Disabled = true;
        // }
    }

    private void DestroyBrick()
    {
        Ball.CollisionEvent -= TakeHit;
        this.Free();
    }
}