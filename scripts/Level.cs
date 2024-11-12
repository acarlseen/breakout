using Godot;
using System;
using System.Collections.Generic;
public partial class Level : Node2D
{
    RandomNumberGenerator _rand;
    int[,] _level;
    int _rows;
    int _cols;

    public Level()
    {
        _rows = 5;
        _cols = 4;
        
    }
    public override void _Ready()
    {
        base._Ready();
        BuildLevel();
    }

    private void BuildLevel()
    {
        // PackedScene newBrick = GD.Load<PackedScene>("res://Scene/brick.tscn");
        // Node2D brickInstance = newBrick.Instantiate<StaticBody2D>();
        // AddChild(brickInstance);
        // brickInstance.Position = new Vector2(100,400);
        
        //the above code works for adding one block. I just need to make it algorithmic.

        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 4; k++)
            {
                PackedScene newBrick = GD.Load<PackedScene>("res://Scene/brick.tscn");
                Node2D brickInstance = newBrick.Instantiate<StaticBody2D>();
                AddChild(brickInstance);
                brickInstance.Position = new Vector2(140 + k * (400* 0.205f) ,250 - i * 20.5f);
            }
        }

    }

    private void PatternType()
    {
        // mirrored y-axis, square, random
    }
}