﻿using DailyDuty.Models.Attributes;

namespace DailyDuty.Models.Enums;

public enum ModuleName
{
    [Label("Unknown")]
    Unknown,
    
    [Label("TestModule")] 
    TestModule,
    
    [Label("ChallengeLog")]
    ChallengeLog,
    
    [Label("CustomDelivery")]
    CustomDelivery,
    
    [Label("DomanEnclave")]
    DomanEnclave,
    
    [Label("DutyRoulette")]
    DutyRoulette,
    
    [Label("MiniCactpot")]
    MiniCactpot,
    
    [Label("FashionReport")]
    FashionReport,
    
    [Label("FauxHollows")]
    FauxHollows,
    
    [Label("GrandCompanyProvision")]
    GrandCompanyProvision,
    
    [Label("GrandCompanySquadron")]
    GrandCompanySquadron,
    
    [Label("GrandCompanySupply")]
    GrandCompanySupply,
    
    [Label("HuntMarksDaily")]
    HuntMarksDaily,
    
    [Label("HuntMarksWeekly")]
    HuntMarksWeekly,
    
    [Label("TreasureMap")]
    TreasureMap,
    
    [Label("JumboCactpot")]
    JumboCactpot,
    
    [Label("Levequest")]
    Levequest,
    
    [Label("MaskedCarnivale")]
    MaskedCarnivale,
    
    [Label("RaidsAlliance")]
    RaidsAlliance,
    
    [Label("RaidsNormal")]
    RaidsNormal,
    
    [Label("TribalQuests")]
    TribalQuests,
    
    [Label("WondrousTails")]
    WondrousTails
}