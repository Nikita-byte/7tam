using System.Collections.Generic;


public sealed class AssetsPath
{
    public static readonly Dictionary<ObjectType, string> Path = new Dictionary<ObjectType, string>
        {
            {
                 ObjectType.Camera, "Camera"
            },
            {
                 ObjectType.Canvas, "Canvas"
            },
            {
                 ObjectType.Sprites, "UI"
            },
            {
                ObjectType.MainMenu, "UI/MainMenu"
            },
            {
                ObjectType.GamePanel, "UI/GamePanel"
            },
            {
                ObjectType.SettingsPanel, "UI/Settings"
            },
            {
                ObjectType.EndGamePanel, "UI/EndGamePanel"
            },
            {
                ObjectType.BackGround, "bg"
            },
            {
                ObjectType.Table, "Table"
            },
            {
                ObjectType.Text, "Text"
            },
            {
                ObjectType.Sound, "Sound"
            },
            {
                ObjectType.Pig, "Pig"
            },
            {
                ObjectType.Stone, "stone"
            },
            {
                ObjectType.Explosion, "Explosion"
            },
            {
                ObjectType.Bomb, "bomb"
            },
            {
                ObjectType.Dog, "Dog"
            },
            {
                ObjectType.Farmer, "Farmer"
            },
        };
}