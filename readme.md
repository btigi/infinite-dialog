# Infinite Dialog

Infinite Dialog is a command-line app to play dialog conversations from Infinity Engine games, specifically Baldur's Gate 2, without having to run the game.

## Usage

From the command-line run the app passing in required directories and the DLG to 'play':

`infinite-dialog game-directory tlk-directory gam-file dialog lua-path`

This example command gives this example output:

`infinite-dialog D:\bg2ee D:\bg2ee\lang\en_US D:\saves\000000010-010 sample\baldur.gam PPDILI.DLG "C:\Users\igi\Documents\Baldur's Gate II - Enhanced Edition\Baldur.lua`

```
Dili
State 0 (weight 0)
Hello! You are new. Those your faces? Funny. Ha! Maybe change them. (44186)
 - [0] What is your name, young one?
 - [1] What do you mean by "change them"? What's wrong with my face?
> 1
Dili
Nothing. Don't you change your face? That's okay, I'll take it and change it for you. Don't worry, you can keep it too. Who are you today? (44194)
 - [0] <GABBER> is my name.
 - [1] Ah, maybe I'll just let you enjoy your break here.
> 0
Dili
<GABBER>? Okay, I'll be <GABBER> tomorrow. I've seen you, so now I can take your face. Don't worry, you can keep it too.  (44193)
I do not think Boo is too thrilled about you borrowing his face. He only has the one. You don't hurt those you mirror, do you? (55694)
Dili
I like taking puppy's face, but it scares him. He's not here though.  (44197)
```

The user is prompted to make dialog choices, and dialog checks (e.g. for the character's strength, the parties composition or gold, the player's progress) are checked based on the specified save game.

## Implementation

The Infinity Engine has many triggers - (see the [IESDP](https://gibberlings3.github.io/iesdp/scripting/triggers/bgeetriggers.htm]))- the triggers listed below are implemented in infinite-dialog. All actions are coded to unconditionally return true, though they do not affect the game state (e.g. using GiveItem in a dialog, then checking for the item later in the dialog via PartyHasItem will not return true).

### Implemented Triggers

- Alignment
- Class
- General
- Global
- HP
- HPGT
- HPLT
- Morale
- MoraleGT
- MoraleLT
- Race
- Reputation
- ReputationGT
- ReputationLT
- Specifics
- True
- HPPercent
- HPPercentLT
- HPPercentGT
- False
- HaveSpell
- HaveSpellRES
- HaveAnySpells
- GlobalGT
- GlobalLT
- StateCheck
- NotStateCheck
- PartyHasItem
- InParty
- CheckStatGT
- RandomNum
- RandomNumGT
- RandomNumLT
- Gender
- PartyGold
- PartyGoldGT
- PartyGoldLT
- Dead
- OutOfAmmo
- HasItem
- HasWeaponEquipped
- Happiness
- HappinessGT
- HappinessLT
- NumInParty
- NumInPartyGT
- NumInPartyLT
- NumDead
- NumDeadGT
- NumDeadLT
- NumItems
- NumItemsGT
- NumItemsLT
- NumItemsParty
- NumItemsPartyGT
- NumItemsPartyLT
- AreaCheck
- HasItemEquipped
- Level
- LevelGT
- LevelLT
- GlobalsEqual
- GlobalsGT
- GlobalsLT
- LocalsEqual
- LocalsGT
- LocalsLT
- CalanderDay
- CalandarDayGT
- CalandarDayLT
- Name
- IsValidForPartyDialog
- IsValidForPartyDialogue
- IfValidForPartyDialogue
- IfValidForPartyDialog
- PartyHasItemIdentified
- HasBounceEffects
- HasImmunityEffects
- HasItemSlot
- InMyGroup
- NumInPartyAlive
- NumInPartyAliveGT
- NumInPartyAliveLT
- Kit
- CharName
- FallenRanger
- FallenPaladin
- InventoryFull
- XP
- XPGT
- XPLT
- G
- GGT
- GLT
- LevelParty
- LevelPartyGT
- LevelPartyLT
- HaveSpellParty
- AmIInWatchersKeepPleaseIgnoreTheLackOfApostophe
- InWatchersKeep
- BeenInParty
- IsWeaponRanged
- ButtonDisabled
- NightmareModeOn
- OriginalClass
- INI
- ModalStateObject
- NumKilledByParty
- NumKilledByPartyGT
- NumKilledByPartyLT
- ImmuneToSpellLevel
- StoryModeOn
- IsForcedRandomEncounterActive
- ClassLevel
- ClassLevelGT
- ClassLevelLT
- HaveKnownSpell
- HaveKnownSpellRES
- CheckItemSlot
- CurrentAmmo
- Proficiency
- ProficiencyGT
- ProficiencyLT

### Unimplemented Triggers

These triggers either require additional information not available in a save game or make no sense in a dialog.

- Acquired
- AttackedBy
- Help
- Joins
- Leaves
- ReceivedOrder
- Said
- TurnedBy
- Unusable
- Allegiance
- Exists
- LOS
- Range
- See
- Time
- TimeOfDay
- HitBy
- HotKey
- TimerExpired
- Trigger
- Die
- TargetUnreachable
- Delay
- NumCreature
- NumCreatureLT
- NumCreatureGT
- ActionListEmpty
- Heard
- BecameVisible
- OnCreation
- NumTimesTalkedTo
- NumTimesTalkedToGT
- NumTimesTalkedToLT
- Reaction
- ReactionGT
- ReactionLT
- GlobalTimerExact
- GlobalTimerExpired
- GlobalTimerNotExpired
- CheckStat
- CheckStatLT
- Died
- Killed
- Entered
- Opened
- Closed
- Detected
- Reset
- Disarmed
- Unlocked
- NumTimesInteracted
- NumTimesInteractedGT
- NumTimesInteractedLT
- BreakingPoint
- PickPocketFailed
- StealFailed
- DisarmFailed
- PickLockFailed
- HasItemType
- InteractingWith
- InWeaponRange
- TimeGT
- TimeLT
- UnselectableVariable
- UnselectableVariableGT
- UnselectableVariableLT
- Clicked
- NumberOfTimesTalkedTo
- Detect
- Contains
- OpenState
- IsOverMe
- NumCreatureVsParty
- NumCreatureVsPartyLT
- NumCreatureVsPartyGT
- CombatCounter
- CombatCounterLT
- CombatCounterGT
- AreaType
- TrapTriggered
- PartyMemberDied
- OR
- InPartySlot
- SpellCast
- InLine
- PartyRested
- Summoned
- ObjectActionListEmpty
- OnScreen
- InActiveArea
- SpellCastOnMe
- SpellCastPriest
- SpellCastInnate
- PersonalSpaceDistance
- RealGlobalTimerExact
- RealGlobalTimerExpired
- RealGlobalTimerNotExpired
- IsGabber
- IsActive
- HasItemEquipedReal
- ModalState
- InMyArea
- TookDamage
- DamageTaken
- DamageTakenGT
- DamageTakenLT
- Difficulty
- DifficultyGT
- DifficultyLT
- InPartyAllowDead
- AreaCheckObject
- ActuallyInCombat
- WalkedToTrigger
- AreaCheckAllegiance
- IsTouchGUI
- HasDLC
- NextTriggerObject
- ExtendedStateCheck
- CheckSpellState
- NearLocation
- NearSavedLocation
- Switch
- HasItemCategory
- CutSceneBroken
- WeaponEffectiveVs
- WeaponCanDamage
- CanTurn
- BitCheck
- CanEquipRanged
- SecretDoorDetected
