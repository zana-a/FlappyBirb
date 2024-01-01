using System;
using Godot;

namespace FlappyBirb.Actors.Flappy;

public partial class Flappy : CharacterBody2D
{
    private const double Speed = 5d;

    private static readonly string[] FlappyOptions =
    {
        "res://Actors/Flappy/FlappyRed.tscn",
        "res://Actors/Flappy/FlappyBlue.tscn",
        "res://Actors/Flappy/FlappyYellow.tscn"
    };

    private static readonly AnimatedSprite2D AnimatedSprite =
        GD
            .Load<PackedScene>(FlappyOptions[new Random().Next() % FlappyOptions.Length])
            .Instantiate() as AnimatedSprite2D;

    public override void _Ready()
    {
        AnimatedSprite?.Play();
        AddChild(AnimatedSprite);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsOnFloor()) Velocity += new Vector2(0, (float)(Speed * delta));
        //
        //
        // if (Input.IsActionJustPressed("flap"))
        // {
        //     Velocity -= Vector2.Up;
        // }
        //
        MoveAndCollide(Velocity);
    }
}