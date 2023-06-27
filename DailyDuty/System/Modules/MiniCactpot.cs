﻿using DailyDuty.Abstracts;
using DailyDuty.Interfaces;
using DailyDuty.Models;
using DailyDuty.Models.Attributes;
using DailyDuty.Models.Enums;
using DailyDuty.System.Localization;

namespace DailyDuty.System;

public class MiniCactpotConfig : ModuleConfigBase
{
    [ClickableLink("GoldSaucerTeleport")]
    public bool ClickableLink = true;
}

public class MiniCactpotData : ModuleDataBase
{
    [DataDisplay("TicketsRemaining")]
    public int AllowancesRemaining = 3;
}

public unsafe class MiniCactpot : Module.DailyModule, IGoldSaucerMessageReceiver
{
    public override ModuleDataBase ModuleData { get; protected set; } = new MiniCactpotData();
    public override ModuleConfigBase ModuleConfig { get; protected set; } = new MiniCactpotConfig();
    private MiniCactpotData Data => ModuleData as MiniCactpotData ?? new MiniCactpotData();
    private MiniCactpotConfig Config => ModuleConfig as MiniCactpotConfig ?? new MiniCactpotConfig()
    ;public override ModuleName ModuleName => ModuleName.MiniCactpot;

    public override void Reset()
    {
        Data.AllowancesRemaining = 3;
        
        base.Reset();
    }

    protected override ModuleStatus GetModuleStatus() => Data.AllowancesRemaining == 0 ? ModuleStatus.Complete : ModuleStatus.Incomplete;

    protected override StatusMessage GetStatusMessage()
    {
        var message = $"{Data.AllowancesRemaining} {Strings.TicketsRemaining}";

        return ConditionalStatusMessage.GetMessage(Config.ClickableLink, message, PayloadId.GoldSaucerTeleport);
    }

    public override void AddonPreSetup(AddonArgs addonInfo)
    {
        if (addonInfo.AddonName != "LotteryDaily") return;

        Data.AllowancesRemaining -= 1;
        DataChanged = true;
    }

    public void GoldSaucerUpdate(object? sender, GoldSaucerEventArgs data)
    {
        const int miniCactpotBroker = 1010445;
        if (Service.TargetManager.Target?.DataId is not miniCactpotBroker) return;

        if (data.EventId == 5)
        {
            Data.AllowancesRemaining = data.Data[4];
            DataChanged = true;
        }
        else
        {
            Data.AllowancesRemaining = 0;
            DataChanged = true;
        } 
    }
}