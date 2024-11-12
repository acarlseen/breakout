using System.Collections.Generic;
using Godot;

public partial class Brick : StaticBody2D
{
    CollisionShape2D _hitbox;
    ColorRect _colorRect;
    private int _hp;

    public override void _Ready()
    {
        base._Ready();
        Ball.CollisionEvent += TakeHit;
        _hitbox = GetNode<CollisionShape2D>("BrickBody");
        _colorRect = GetNode<ColorRect>("ColorRect");

        MakeBrick();
    }

    public Brick()
    {
    }

    private void MakeBrick()
    {
        Color[] palette = { Colors.Azure, Colors.DarkSeaGreen, Colors.LightGoldenrod, Colors.LightSalmon };

        int rand = (int)GD.Randi() % palette.Length;
        _colorRect.Color = palette[rand];
        _hp = rand + 1;
        GD.Print($"_HP IS SET TO {_hp}");
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
        if (_hp <= 0)
        {
            DestroyBrick();
            return;
        }


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