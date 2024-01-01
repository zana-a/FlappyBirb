using Godot;
using Vector2 = Godot.Vector2;

namespace FlappyBirb.Actors.Background;

public partial class Background : Node2D
{
    private static readonly string[] BackgroundOptions =
    {
        "res://Actors/Background/BackgroundDay.tscn",
        "res://Actors/Background/BackgroundNight.tscn"
    };

    private static readonly string BackgroundOption =
        BackgroundOptions[GD.Randi() % BackgroundOptions.Length];

    private static readonly Node2D BackgroundSprite =
        GD.Load<PackedScene>(BackgroundOption).Instantiate() as Node2D;

    public override void _Ready()
    {
        AddChild(BackgroundSprite);
    }

    public override void _PhysicsProcess(double delta)
    {
        var node = GetChild<Node2D>(0);
        var first = node.GetNode<Sprite2D>("First");
        var second = node.GetNode<Sprite2D>("Second");

        first.GlobalPosition += Vector2.Left;
        second.GlobalPosition += Vector2.Left;

        if (first.GlobalPosition.X <= -first.Texture.GetWidth())
            first.GlobalPosition = new Vector2(first.Texture.GetWidth(), 0);

        if (second.GlobalPosition.X <= -second.Texture.GetWidth())
            second.GlobalPosition = new Vector2(second.Texture.GetWidth(), 0);
    }
}