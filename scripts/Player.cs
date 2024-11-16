using Godot;
using Godot.NativeInterop;

public partial class Player : CharacterBody2D
{
    private int _speed = 400;
    public override void _Ready()
    {
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        Vector2 _velocity = Velocity;
        Vector2 _position = Position;
        _velocity.Y = 0f;
        float _horizontalInput = Input.GetAxis("left", "right");
        if (_horizontalInput != 0)
        {
            _velocity.X = _horizontalInput < 0 ? -_speed : _speed;
        }
        else
        {
            _velocity.X = 0;
        }

        _position.Y = 640;
        _velocity.Y = 0;
        Position = _position;
        Velocity = _velocity;
        MoveAndSlide();
    }
}