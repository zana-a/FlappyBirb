using System;
using Godot;

namespace FlappyBirb.Actors.Flappy
{
    public partial class Flappy : CharacterBody2D
    {
        public override void _Ready()
        {
            GD.Print("Hello, world");
        }

        public override void _Process(double delta)
        {
            
        }
    }
}
