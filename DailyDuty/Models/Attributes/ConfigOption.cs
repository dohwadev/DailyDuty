﻿using System;
using System.Numerics;
using DailyDuty.System.Localization;

namespace DailyDuty.Models.Attributes;

public class ConfigOption : Attribute
{
    private readonly string resourceKey;
    private readonly string? helpTextKey;
    
    public string Name
    {
        get
        {
            var displayName = Strings.ResourceManager.GetString(resourceKey, Strings.Culture);

            return string.IsNullOrEmpty(displayName) ? $"[[{resourceKey}]]" : displayName;
        }
    }

    public string? HelpText 
    {
        get
        {
            if (helpTextKey is null) return null;
            
            var displayName = Strings.ResourceManager.GetString(helpTextKey, Strings.Culture);

            return string.IsNullOrEmpty(displayName) ? $"[[{helpTextKey}]]" : displayName;
        }
    }

    public int IntMin { get; }
    public int IntMax { get; } = 100;
    public float FloatMin { get; }
    public float FloatMax { get; } = 1.0f;
    public Vector4 DefaultColor { get; } = Vector4.One;
    public ushort DefaultUiColor { get; } = 1;
    public bool UseAxisFont { get; }
    public bool ShowLabel { get; } = true;

    public ConfigOption(string resourceKey, float r, float g, float b, float a)
    {
        this.resourceKey = resourceKey;
        DefaultColor = new Vector4(r, g, b, a);
    }

    public ConfigOption(string resourceKey, bool useAxisFont, bool showLabel = true)
    {
        this.resourceKey = resourceKey;
        UseAxisFont = useAxisFont;
        ShowLabel = showLabel;
    }

    public ConfigOption(string resourceKey, float floatMin, float floatMax)
    {
        this.resourceKey = resourceKey;
        FloatMin = floatMin;
        FloatMax = floatMax;
    }
    
    public ConfigOption(string resourceKey)
    {
        this.resourceKey = resourceKey;
    }
    
    public ConfigOption(string resourceKey, int intMin, int intMax)
    {
        this.resourceKey = resourceKey;
        IntMin = intMin;
        IntMax = intMax;
    }

    public ConfigOption(string resourceKey, string helpTextKey)
    {
        this.resourceKey = resourceKey;
        this.helpTextKey = helpTextKey;
    }

    public ConfigOption(string resourceKey, ushort defaultUiColor)
    {
        this.resourceKey = resourceKey;
        DefaultUiColor = defaultUiColor;
    }
}