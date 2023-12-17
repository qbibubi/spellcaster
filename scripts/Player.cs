using Godot;
using System;

public partial class Player : Area2D
{
	[Export] public int movementSpeed = 1000;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		var velocity = Vector2.Zero;

		if (Input.IsActionPressed("moveUp")) { velocity.Y -= 1; }
		if (Input.IsActionPressed("moveDown")) { velocity.Y += 1; }
		if (Input.IsActionPressed("moveLeft")) { velocity.X -= 1; }
		if (Input.IsActionPressed("moveRight")) { velocity.X += 1; }

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * movementSpeed;
			animatedSprite.Play();
		}
		else
		{
			animatedSprite.Stop();
		}

		if (velocity.X < 0)
		{
			animatedSprite.FlipH = true;
		}
		else if (velocity.X > 0)
		{
			animatedSprite.FlipH = false;
		}

		Position += velocity * (float)delta;

		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 24, 1000 - 16),
			y: Mathf.Clamp(Position.Y, 8, 497 - 20)
		);
	}
}
