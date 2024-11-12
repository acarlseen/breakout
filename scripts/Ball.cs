using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public partial class Ball : CharacterBody2D
{
	private int _speed = 500;
	public static event Action <GodotObject> CollisionEvent;
	private CollisionShape2D _body;

	public override void _Ready()
	{
		Vector2 _velocity = new(0, _speed);
		Velocity = _velocity;
	}

	public override void _PhysicsProcess(double delta)
	{
		KinematicCollision2D collisionInfo = MoveAndCollide(Velocity * (float) delta);
		Bounce(collisionInfo);
	}

	private void Bounce(KinematicCollision2D collisionInfo)
	{
		if (collisionInfo == null)
		{
			return;
		}
		GD.Print($"Collision info: {collisionInfo}");
		OnCollisionEvent(collisionInfo.GetCollider());
		Vector2 _velocity = Velocity;

		_velocity = _velocity.Bounce(collisionInfo.GetNormal());
		Velocity = _velocity;
		// MoveAndCollide(Velocity * (float)delta);
	}

	public void OnCollisionEvent(GodotObject collisionInfo)
	{
		CollisionEvent?.Invoke(collisionInfo);
	}
}
