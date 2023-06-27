﻿using System;
using System.Collections.Generic;
using Dalamud.Game.Command;
using Dalamud.Logging;
using KamiLib.Interfaces;
using KamiLib.Localization;

namespace KamiLib.ChatCommands;

public class CommandManager : IDisposable
{
    private static string SettingsCommand => $"/{KamiCommon.PluginName.ToLower()}";
    private static string HelpCommand => $"/{KamiCommon.PluginName.ToLower()} help";

    public readonly List<IPluginCommand> Commands = new();

    private readonly List<string> additionalCommands = new();
    
    public CommandManager()
    {
        Commands.Add(new HelpCommands());
        
        Service.Commands.AddHandler(SettingsCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = Strings.Command_OpenConfigWindow
        });

        Service.Commands.AddHandler(HelpCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = Strings.Command_DisplayHelpText
        });
    }
    
    public void Dispose()
    {
        Service.Commands.RemoveHandler(SettingsCommand);
        Service.Commands.RemoveHandler(HelpCommand);

        foreach (var additionalCommand in additionalCommands)
        {
            Service.Commands.RemoveHandler(additionalCommand);
        }
    }

    public void AddHandler(string additionalCommand, string description)
    {
        additionalCommands.Add(additionalCommand);
        Service.Commands.AddHandler(additionalCommand, new CommandInfo(OnCommand)
        {
            HelpMessage = description
        });
    }

    public void AddCommand(IPluginCommand command) => Commands.Add(command);

    public void RemoveCommand(IPluginCommand command) => Commands.Remove(command);

    public void OnCommand(string command, string arguments)
    {
        var commandData = Command.GetCommandData(command.ToLower(), arguments.ToLower());
        
        PluginLog.Debug($"[{KamiCommon.PluginName}] Received Command: {commandData}");
        Command.ProcessCommand(commandData, Commands);
    }
}
