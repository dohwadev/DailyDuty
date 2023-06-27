﻿using System.Collections.Generic;
using KamiLib.ChatCommands;

namespace KamiLib.Interfaces;

public interface ISubCommand
{
    string? GetCommand();
    IEnumerable<string>? GetAliases();
    bool Execute(CommandData commandData);
    string? GetHelpText();
    bool Hidden { get; }
    bool HasParameterAction { get; }
}