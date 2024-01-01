using Godot;

namespace FlappyBirb.Actors.Floor;

public partial class Floor : Node2D
{
    private Sprite2D _first;
    private Vector2 _position;
    private Sprite2D _second;

    public override void _Ready()
    {
        _first = GetNode<Sprite2D>("First");
        _second = GetNode<Sprite2D>("Second");
        _position = new Vector2(0, 187);
        Position = _position;
    }

    public override void _PhysicsProcess(double delta)
    {
        _first.GlobalPosition += Vector2.Left;
        _second.GlobalPosition += Vector2.Left;

        if (_first.GlobalPosition.X <= -_first.Texture.GetWidth())
            _first.GlobalPosition = new Vector2(_first.Texture.GetWidth(), _position.Y);

        if (_second.GlobalPosition.X <= -_second.Texture.GetWidth())
            _second.GlobalPosition = new Vector2(_second.Texture.GetWidth(), _position.Y);
    }
}