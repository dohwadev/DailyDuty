﻿using Dalamud.Data;
using Dalamud.Game.ClientState;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Plugin;
using DalamudCommandManager = Dalamud.Game.Command.CommandManager;
using DalamudCondition = Dalamud.Game.ClientState.Conditions.Condition;

namespace KamiLib;

internal class Service
{
    [PluginService] public static DalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] public static DalamudCommandManager Commands { get; private set; } = null!;
    [PluginService] public static ClientState ClientState { get; private set; } = null!;
    [PluginService] public static ChatGui Chat { get; private set; } = null!;
    [PluginService] public static GameGui GameGui { get; private set; } = null!;
    [PluginService] public static DalamudCondition Condition { get; private set; } = null!;
    [PluginService] public static DataManager DataManager { get; private set; } = null!;
}