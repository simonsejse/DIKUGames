﻿using Breakout.GameModifiers.PowerUps.Activators;
using Breakout.PowerUps.Activators;
using Breakout.States.GameRunning;
using DIKUArcade.Graphics;

namespace Breakout.GameModifiers.PowerUps;

/// <summary>
/// Represents the Player Speed Power-Up.
/// </summary>
public class PlayerSpeedPowerUp : IGameModifier {
    /// <summary>
    /// Gets the image associated with the Player Speed Power-Up.
    /// </summary>
    /// <returns>The image of the Player Speed Power-Up.</returns>
    public IBaseImage GetImage() => 
        new Image(Path.Combine("Assets", "Images", "SpeedPickUp.png"));
    
    /// <summary>
    /// Gets the activator for the Player Speed Power-Up.
    /// </summary>
    /// <returns>The activator for the Player Speed Power-Up.</returns>
    public IGameModifierActivator Activator() => 
        new PlayerSpeedPowerUpActivator(GameRunningState.GetInstance().EntityManager.PlayerEntity);
}