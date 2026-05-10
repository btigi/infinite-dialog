using ii.InfinityEngine.Files;

public class ActionProcessor
{
    private readonly ObjectLocator objectLocator;
    private readonly IdsProcessor idsProcessor;

    public ActionProcessor(ObjectLocator objectLocator, IdsProcessor idsProcessor)
    {
        this.objectLocator = objectLocator;
        this.idsProcessor = idsProcessor;
    }

    public Area Area { get; set; }
    public CreFile Creature { get; set; }

    public bool NoAction()
    {
        return true;
    }

    public bool ActionOverride(string actor, string action)
    {
        return true;
    }

    public bool AddWayPoint(string wayPoint)
    {
        return true;
    }

    public bool Attack(string target)
    {
        return true;
    }

    public bool BackStab(string target)
    {
        return true;
    }

    public bool CreateCreature(string newObject, string location, int face)
    {
        return true;
    }

    public bool CreateCreatureEffect(string newObject, string effect, string location, int face)
    {
        return true;
    }

    public bool Dialog(string obj)
    {
        return true;
    }

    public bool Dialogue(string obj)
    {
        return Dialog(obj);
    }

    public bool DropItem(string obj, string location)
    {
        return true;
    }

    public bool Enemy()
    {
        return true;
    }

    public bool EquipItem(string obj)
    {
        return true;
    }

    public bool EquipItemEx(string obj, int equipUnEquip)
    {
        return true;
    }

    public bool FindTraps()
    {
        return true;
    }

    public bool GetItem(string obj, string target)
    {
        return true;
    }

    public bool GiveItem(string obj, string target)
    {
        return true;
    }

    public bool GiveOrder(string obj, int order)
    {
        return true;
    }

    public bool Help()
    {
        return true;
    }

    public bool Hide()
    {
        return true;
    }

    public bool JoinParty()
    {
        return true;
    }

    public bool LayHands(string target)
    {
        return true;
    }

    public bool LeaveParty()
    {
        return true;
    }

    public bool MoveToObject(string obj)
    {
        return true;
    }

    public bool MoveToPoint(string point)
    {
        return true;
    }

    public bool Panic()
    {
        return true;
    }

    public bool PickPockets(string target)
    {
        return true;
    }

    public bool PlaySound(string sound)
    {
        return true;
    }

    public bool ProtectPoint(string target, int range)
    {
        return true;
    }

    public bool RemoveTraps(string trap)
    {
        return true;
    }

    public bool RunAwayFrom(string creature, int time)
    {
        return true;
    }

    public bool SetGlobal(string name, string area, int value)
    {
        return true;
    }

    public bool Spell(string target, int spell)
    {
        return true;
    }

    public bool SpellRES(string res, string target)
    {
        return true;
    }

    public bool Turn()
    {
        return true;
    }

    public bool UseItem(string item, string target)
    {
        return true;
    }

    public bool UseItemAbility(string item, string target, int slot, int ability)
    {
        return true;
    }

    public bool UseItemSlot(string target, int slot)
    {
        return true;
    }

    public bool UseItemSlotAbility(string target, int slot, int ability)
    {
        return true;
    }

    public bool Continue()
    {
        return true;
    }

    public bool FollowPath()
    {
        return true;
    }

    public bool Swing()
    {
        return true;
    }

    public bool Recoil()
    {
        return true;
    }

    public bool PlayDead(int time)
    {
        return true;
    }

    public bool Formation(string leader, string offset)
    {
        return true;
    }

    public bool JumpToPoint(string target)
    {
        return true;
    }

    public bool MoveViewPoint(string target, int scrollSpeed)
    {
        return true;
    }

    public bool MoveViewObject(string target, int scrollSpeed)
    {
        return true;
    }

    public bool ClickLButtonPoint(string target, int scrollSpeed)
    {
        return true;
    }

    public bool ClickLButtonObject(string target, int scrollSpeed)
    {
        return true;
    }

    public bool ClickRButtonPoint(string target, int scrollSpeed)
    {
        return true;
    }

    public bool ClickRButtonObject(string target, int scrollSpeed)
    {
        return true;
    }

    public bool DoubleClickLButtonPoint(string target, int scrollSpeed)
    {
        return true;
    }

    public bool DoubleClickLButtonObject(string target, int scrollSpeed)
    {
        return true;
    }

    public bool DoubleClickRButtonPoint(string target, int scrollSpeed)
    {
        return true;
    }

    public bool DoubleClickRButtonObject(string target, int scrollSpeed)
    {
        return true;
    }

    public bool MoveCursorPoint(string target, int scrollSpeed)
    {
        return true;
    }

    public bool ChangeAIScript(string scriptFile, int level)
    {
        return true;
    }

    public bool StartTimer(int id, int time)
    {
        return true;
    }

    public bool SendTrigger(string target, int triggerNum)
    {
        return true;
    }

    public bool Wait(int time)
    {
        return true;
    }

    public bool UndoExplore()
    {
        return true;
    }

    public bool Explore()
    {
        return true;
    }

    public bool DayNight(int timeOfDay)
    {
        return true;
    }

    public bool Weather(int weather)
    {
        return true;
    }

    public bool CallLightning(string target)
    {
        return true;
    }

    public bool VEquip(int item)
    {
        return true;
    }

    public bool NIDSpecial1()
    {
        return true;
    }

    public bool NIDSpecial2()
    {
        return true;
    }

    public bool NIDSpecial3()
    {
        return true;
    }

    public bool NIDSpecial4()
    {
        return true;
    }

    public bool NIDSpecial5()
    {
        return true;
    }

    public bool NIDSpecial6()
    {
        return true;
    }

    public bool NIDSpecial7()
    {
        return true;
    }

    public bool NIDSpecial8()
    {
        return true;
    }

    public bool NIDSpecial9()
    {
        return true;
    }

    public bool NIDSpecial10()
    {
        return true;
    }

    public bool NIDSpecial11()
    {
        return true;
    }

    public bool NIDSpecial12()
    {
        return true;
    }

    public bool CreateItem(string resRef, int usage1, int usage2, int usage3)
    {
        return true;
    }

    public bool SmallWait(int time)
    {
        return true;
    }

    public bool Face(int direction)
    {
        return true;
    }

    public bool RandomWalk()
    {
        return true;
    }

    public bool SetInterrupt(int state)
    {
        return true;
    }

    public bool ProtectObject(string target, int range)
    {
        return true;
    }

    public bool Leader(string point)
    {
        return true;
    }

    public bool Follow(string point)
    {
        return true;
    }

    public bool MoveToPointNoRecticle(string point)
    {
        return true;
    }

    public bool LeaveArea(string area, string point, int face)
    {
        return true;
    }

    public bool SelectWeaponAbility(int weaponNum, int abilityNum)
    {
        return true;
    }

    public bool LeaveAreaName(int target)
    {
        return true;
    }

    public bool GroupAttack(string target)
    {
        return true;
    }

    public bool SpellPoint(string target, int spell)
    {
        return true;
    }

    public bool SpellPointRES(string res, string target)
    {
        return true;
    }

    public bool Rest()
    {
        return true;
    }

    public bool UseItemPoint(string item, string target, int ability)
    {
        return true;
    }

    public bool UseItemPointSlot(string point, int slot, int ability)
    {
        return true;
    }

    public bool AttackNoSound(string target)
    {
        return true;
    }

    public bool RandomFly()
    {
        return true;
    }

    public bool FlyToPoint(string point, int time)
    {
        return true;
    }

    public bool MoraleSet(string target, int morale)
    {
        return true;
    }

    public bool MoraleInc(string target, int morale)
    {
        return true;
    }

    public bool MoraleDec(string target, int morale)
    {
        return true;
    }

    public bool AttackOneRound(string target)
    {
        return true;
    }

    public bool Shout(int id)
    {
        return true;
    }

    public bool MoveToOffset(string offset)
    {
        return true;
    }

    public bool EscapeArea()
    {
        return true;
    }

    public bool EscapeAreaMove(string area, int x, int y, int face)
    {
        return true;
    }

    public bool IncrementGlobal(string name, string area, int value)
    {
        return true;
    }

    public bool LeaveAreaLUA(string area, string parchment, string point, int face)
    {
        return true;
    }

    public bool DestroySelf()
    {
        return true;
    }

    public bool UseContainer()
    {
        return true;
    }

    public bool ForceSpell(string target, int spell)
    {
        return true;
    }

    public bool ForceSpellRES(string res, string target, int castingLevel)
    {
        return true;
    }

    public bool ForceSpellRES(string res, string target)
    {
        return true;
    }

    public bool ForceSpellPoint(string target, int spell)
    {
        return true;
    }

    public bool ForceSpellPointRES(string res, string target)
    {
        return true;
    }

    public bool ForceSpellPointRES(string res, string target, int castingLevel)
    {
        return true;
    }

    public bool SetGlobalTimer(string name, string area, int time)
    {
        return true;
    }

    public bool TakePartyItem(string item)
    {
        return true;
    }

    public bool TakePartyGold(int amount)
    {
        return true;
    }

    public bool GivePartyGold(int amount)
    {
        return true;
    }

    public bool DropInventory()
    {
        return true;
    }

    public bool StartCutScene(string cutScene)
    {
        return true;
    }

    public bool StartCutSceneEx(string cutScene, int evaluateConditions)
    {
        return true;
    }

    public bool StartCutSceneMode()
    {
        return true;
    }

    public bool EndCutSceneMode()
    {
        return true;
    }

    public bool ClearAllActions()
    {
        return true;
    }

    public bool Berserk()
    {
        return true;
    }

    public bool Deactivate(string objectValue)
    {
        return true;
    }

    public bool Activate(string objectValue)
    {
        return true;
    }

    public bool CutSceneId(string objectValue)
    {
        return true;
    }

    public bool AnkhegEmerge()
    {
        return true;
    }

    public bool AnkhegHide()
    {
        return true;
    }

    public bool RandomTurn()
    {
        return true;
    }

    public bool Kill(string objectValue)
    {
        return true;
    }

    public bool VerbalConstant(string objectValue, int constant)
    {
        return true;
    }

    public bool ClearActions(string objectValue)
    {
        return true;
    }

    public bool AttackReevaluate(string target, int reevaluationPeriod)
    {
        return true;
    }

    public bool LockScroll()
    {
        return true;
    }

    public bool UnlockScroll()
    {
        return true;
    }

    public bool StartDialog(string dialogFile, string target)
    {
        return true;
    }

    public bool StartDialogue(string dialogFile, string target)
    {
        return true;
    }

    public bool SetDialog(string dialogFile)
    {
        return true;
    }

    public bool SetDialogue(string dialogFile)
    {
        return true;
    }

    public bool PlayerDialog(string target)
    {
        return true;
    }

    public bool PlayerDialogue(string target)
    {
        return true;
    }

    public bool GiveItemCreate(string resRef, string objectValue, int usage1, int usage2, int usage3)
    {
        return true;
    }

    public bool GivePartyGoldGlobal(string name, string area)
    {
        return true;
    }

    public bool UseDoor()
    {
        return true;
    }

    public bool OpenDoor(string objectValue)
    {
        return true;
    }

    public bool CloseDoor(string objectValue)
    {
        return true;
    }

    public bool PickLock(string objectValue)
    {
        return true;
    }

    public bool Polymorph(int animationType)
    {
        return true;
    }

    public bool RemoveSpell(int spell)
    {
        return true;
    }

    public bool RemoveSpellRES(string res)
    {
        return true;
    }

    public bool BashDoor(string objectValue)
    {
        return true;
    }

    public bool EquipMostDamagingMelee()
    {
        return true;
    }

    public bool StartStore(string store, string target)
    {
        return true;
    }

    public bool DisplayString(string objectValue, int strRef)
    {
        return true;
    }

    public bool ChangeAIType(string objectValue)
    {
        return true;
    }

    public bool ChangeEnemyAlly(string objectValue, int value)
    {
        return true;
    }

    public bool ChangeGeneral(string objectValue, int value)
    {
        return true;
    }

    public bool ChangeRace(string objectValue, int value)
    {
        return true;
    }

    public bool ChangeClass(string objectValue, int value)
    {
        return true;
    }

    public bool ChangeSpecifics(string objectValue, int value)
    {
        return true;
    }

    public bool ChangeGender(string objectValue, int value)
    {
        return true;
    }

    public bool ChangeAlignment(string objectValue, int value)
    {
        return true;
    }

    public bool ApplySpell(string target, int spell)
    {
        return true;
    }

    public bool ApplySpellRES(string res, string target)
    {
        return true;
    }

    public bool IncrementChapter(string resref)
    {
        return true;
    }

    public bool ReputationSet(int reputation)
    {
        return true;
    }

    public bool ReputationInc(int reputation)
    {
        return true;
    }

    public bool AddExperienceParty(int xp)
    {
        return true;
    }

    public bool AddExperiencePartyGlobal(string name, string area)
    {
        return true;
    }

    public bool SetNumTimesTalkedTo(int num)
    {
        return true;
    }

    public bool StartMovie(string resRef)
    {
        return true;
    }

    public bool Interact(string objectValue)
    {
        return true;
    }

    public bool DestroyItem(string resRef)
    {
        return true;
    }

    public bool RevealAreaOnMap(string resRef)
    {
        return true;
    }

    public bool GiveGoldForce(int amount)
    {
        return true;
    }

    public bool ChangeTileState(string tile, int state)
    {
        return true;
    }

    public bool AddJournalEntry(int entry, int type)
    {
        return true;
    }

    public bool EquipRanged()
    {
        return true;
    }

    public bool SetLeavePartyDialogFile()
    {
        return true;
    }

    public bool SetLeavePartyDialogueFile()
    {
        return true;
    }

    public bool EscapeAreaDestroy(int delay)
    {
        return true;
    }

    public bool TriggerActivation(string objectValue, int state)
    {
        return true;
    }

    public bool BreakInstants()
    {
        return true;
    }

    public bool DialogInterrupt(int state)
    {
        return true;
    }

    public bool DialogueInterrupt(int state)
    {
        return true;
    }

    public bool MoveToObjectFollow(string objectValue)
    {
        return true;
    }

    public bool ReallyForceSpell(string target, int spell)
    {
        return true;
    }

    public bool ReallyForceSpellRES(string res, string target)
    {
        return true;
    }

    public bool MakeUnselectable(int time)
    {
        return true;
    }

    public bool MultiPlayerSync()
    {
        return true;
    }

    public bool RunAwayFromNoInterrupt(string creature, int time)
    {
        return true;
    }

    public bool SetMasterArea(string name)
    {
        return true;
    }

    public bool EndCredits()
    {
        return true;
    }

    public bool StartMusic(int slot, int flags)
    {
        return true;
    }

    public bool TakePartyItemAll(string item)
    {
        return true;
    }

    public bool LeaveAreaLUAPanic(string area, string parchment, string point, int face)
    {
        return true;
    }

    public bool SaveGame(int slot)
    {
        return true;
    }

    public bool SpellNoDec(string target, int spell)
    {
        return true;
    }

    public bool SpellNoDecRES(string res, string target)
    {
        return true;
    }

    public bool SpellPointNoDec(string target, int spell)
    {
        return true;
    }

    public bool SpellPointNoDecRES(string res, string target)
    {
        return true;
    }

    public bool TakePartyItemRange(string item)
    {
        return true;
    }

    public bool ChangeAnimation(string resRef)
    {
        return true;
    }

    public bool Lock(string objectValue)
    {
        return true;
    }

    public bool Unlock(string objectValue)
    {
        return true;
    }

    public bool MoveGlobal(string area, string objectValue, string point)
    {
        return true;
    }

    public bool StartDialogNoSet(string objectValue)
    {
        return true;
    }

    public bool StartDialogueNoSet(string objectValue)
    {
        return true;
    }

    public bool TextScreen(string textList)
    {
        return true;
    }

    public bool RandomWalkContinuous()
    {
        return true;
    }

    public bool DetectSecretDoor(string objectValue)
    {
        return true;
    }

    public bool FadeToColor(string point, int blue)
    {
        return true;
    }

    public bool FadeFromColor(string point, int blue)
    {
        return true;
    }

    public bool TakePartyItemNum(string resRef, int num)
    {
        return true;
    }

    public bool WaitWait(int time)
    {
        return true;
    }

    public bool MoveToPointNoInterrupt(string point)
    {
        return true;
    }

    public bool MoveToObjectNoInterrupt(string objectValue)
    {
        return true;
    }

    public bool SpawnPtActivate(string objectValue)
    {
        return true;
    }

    public bool SpawnPtDeactivate(string objectValue)
    {
        return true;
    }

    public bool SpawnPtSpawn(string objectValue)
    {
        return true;
    }

    public bool GlobalShout(int id)
    {
        return true;
    }

    public bool StaticStart(string objectValue)
    {
        return true;
    }

    public bool StaticStop(string objectValue)
    {
        return true;
    }

    public bool FollowObjectFormation(string objectValue, int formation, int position)
    {
        return true;
    }

    public bool AddFamiliar()
    {
        return true;
    }

    public bool RemoveFamiliar()
    {
        return true;
    }

    public bool PauseGame()
    {
        return true;
    }

    public bool ChangeAnimationNoEffect(string resRef)
    {
        return true;
    }

    public bool TakeItemListParty(string resRef)
    {
        return true;
    }

    public bool SetMoraleAI(int morale)
    {
        return true;
    }

    public bool IncMoraleAI(int morale)
    {
        return true;
    }

    public bool DestroyAllEquipment()
    {
        return true;
    }

    public bool GivePartyAllEquipment()
    {
        return true;
    }

    public bool MoveBetweenAreas(string area, string location, int face)
    {
        return true;
    }

    public bool MoveBetweenAreasEffect(string area, string graphic, string location, int face)
    {
        return true;
    }

    public bool TakeItemListPartyNum(string resRef, int num)
    {
        return true;
    }

    public bool CreateCreatureObject(string resRef, string objectValue, int usage1, int usage2, int usage3)
    {
        return true;
    }

    public bool CreateCreatureObjectEffect(string resRef, string effect, string objectValue)
    {
        return true;
    }

    public bool CreateCreatureImpassable(string newObject, string location, int face)
    {
        return true;
    }

    public bool CreateCreatureImpassableEffect(string newObject, string effect, string location, int face)
    {
        return true;
    }

    public bool FaceObject(string objectValue)
    {
        return true;
    }

    public bool RestParty()
    {
        return true;
    }

    public bool RestPartyEx(int gold, int hpBonus, int disableMovie)
    {
        return true;
    }

    public bool CreateCreatureDoor(string newObject, string location, int face)
    {
        return true;
    }

    public bool CreateCreatureObjectDoor(string resRef, string objectValue, int usage1, int usage2, int usage3)
    {
        return true;
    }

    public bool CreateCreatureObjectOffScreen(string resRef, string objectValue, int usage1, int usage2, int usage3)
    {
        return true;
    }

    public bool MoveGlobalObjectOffScreen(string objectValue, string target)
    {
        return true;
    }

    public bool SetQuestDone(int strref)
    {
        return true;
    }

    public bool StorePartyLocations()
    {
        return true;
    }

    public bool RestorePartyLocations()
    {
        return true;
    }

    public bool CreateCreatureOffScreen(string resRef, int face)
    {
        return true;
    }

    public bool MoveToCenterOfScreen(int notInterruptableFor)
    {
        return true;
    }

    public bool ReallyForceSpellDead(string target, int spell)
    {
        return true;
    }

    public bool ReallyForceSpellDeadRES(string res, string target)
    {
        return true;
    }

    public bool Calm(string objectValue)
    {
        return true;
    }

    public bool Ally()
    {
        return true;
    }

    public bool RestNoSpells()
    {
        return true;
    }

    public bool SaveLocation(string area, string global, string point)
    {
        return true;
    }

    public bool SaveObjectLocation(string area, string global, string objectValue)
    {
        return true;
    }

    public bool CreateCreatureAtLocation(string global, string area, string resRef)
    {
        return true;
    }

    public bool SetToken(string token, int strref)
    {
        return true;
    }

    public bool SetTokenObject(string token, string objectValue)
    {
        return true;
    }

    public bool SetGabber(string objectValue)
    {
        return true;
    }

    public bool CreateCreatureObjectCopy(string resRef, string objectValue, int usage1, int usage2, int usage3)
    {
        return true;
    }

    public bool CreateCreatureObjectCopyEffect(string resRef, string effect, string objectValue)
    {
        return true;
    }

    public bool HideAreaOnMap(string resRef)
    {
        return true;
    }

    public bool CreateCreatureObjectOffset(string resRef, string objectValue, string offset)
    {
        return true;
    }

    public bool ContainerEnable(string objectValue, int boolValue)
    {
        return true;
    }

    public bool ScreenShake(string point, int duration)
    {
        return true;
    }

    public bool AddGlobals(string name, string name2)
    {
        return true;
    }

    public bool CreateItemGlobal(string global, string area, string resRef)
    {
        return true;
    }

    public bool PickUpItem(string resRef)
    {
        return true;
    }

    public bool FillSlot(int slot)
    {
        return true;
    }

    public bool AddXPObject(string objectValue, int xp)
    {
        return true;
    }

    public bool DestroyGold(int gold)
    {
        return true;
    }

    public bool SetHomeLocation(string point)
    {
        return true;
    }

    public bool DisplayStringNoName(string objectValue, int strRef)
    {
        return true;
    }

    public bool EraseJournalEntry(int strref)
    {
        return true;
    }

    public bool CopyGroundPilesTo(string resRef, string location)
    {
        return true;
    }

    public bool DialogForceInterrupt(string objectValue)
    {
        return true;
    }

    public bool DialogueForceInterrupt(string objectValue)
    {
        return true;
    }

    public bool StartDialogInterrupt(string dialogFile, string target)
    {
        return true;
    }

    public bool StartDialogueInterrupt(string dialogFile, string target)
    {
        return true;
    }

    public bool StartDialogNoSetInterrupt(string objectValue)
    {
        return true;
    }

    public bool StartDialogueNoSetInterrupt(string objectValue)
    {
        return true;
    }

    public bool RealSetGlobalTimer(string name, string area, int time)
    {
        return true;
    }

    public bool DisplayStringHead(string objectValue, int strRef)
    {
        return true;
    }

    public bool PolymorphCopy(string objectValue)
    {
        return true;
    }

    public bool VerbalConstantHead(string objectValue, int constant)
    {
        return true;
    }

    public bool CreateVisualEffect(string item, string location)
    {
        return true;
    }

    public bool CreateVisualEffectObject(string dialogFile, string target)
    {
        return true;
    }

    public bool AddKit(int kit)
    {
        return true;
    }

    public bool StartCombatCounter()
    {
        return true;
    }

    public bool EscapeAreaNoSee()
    {
        return true;
    }

    public bool EscapeAreaObject(string objectValue)
    {
        return true;
    }

    public bool EscapeAreaObjectMove(string resRef, string objectValue, int x, int y, int face)
    {
        return true;
    }

    public bool TakeItemReplace(string give, string take, string objectValue)
    {
        return true;
    }

    public bool AddSpecialAbility(string resRef)
    {
        return true;
    }

    public bool DestroyAllDestructableEquipment()
    {
        return true;
    }

    public bool DestroyAllFragileEquipment(int type)
    {
        return true;
    }

    public bool RemovePaladinHood()
    {
        return true;
    }

    public bool RemoveRangerHood()
    {
        return true;
    }

    public bool RegainPaladinHood()
    {
        return true;
    }

    public bool RegainRangerHood()
    {
        return true;
    }

    public bool PolymorphCopyBase(string objectValue)
    {
        return true;
    }

    public bool HideGUI()
    {
        return true;
    }

    public bool UnhideGUI()
    {
        return true;
    }

    public bool SetName(int strref)
    {
        return true;
    }

    public bool AddSuperKit(int kit)
    {
        return true;
    }

    public bool PlayDeadInterruptable(int time)
    {
        return true;
    }

    public bool PlayDeadInterruptible(int time)
    {
        return true;
    }

    public bool MoveGlobalObject(string objectValue, string target)
    {
        return true;
    }

    public bool DisplayStringHeadOwner(string item, int strref)
    {
        return true;
    }

    public bool StartDialogOverride(string dialogFile, string target, int unused, int unused2, int converseAsItem)
    {
        return true;
    }

    public bool StartDialogOverride(string dialogFile, string target)
    {
        return true;
    }

    public bool StartDialogOverrideInterrupt(string dialogFile, string target)
    {
        return true;
    }

    public bool CreateCreatureCopyPoint(string resRef, string objectValue, string dest)
    {
        return true;
    }

    public bool BattleSong()
    {
        return true;
    }

    public bool MoveToSavedLocation(string global, string area)
    {
        return true;
    }

    public bool MoveToSavedLocationn(string global, string area)
    {
        return true;
    }

    public bool ApplyDamage(string objectValue, int amount, int type)
    {
        return true;
    }

    public bool BanterBlockTime(int time)
    {
        return true;
    }

    public bool BanterBlockFlag(int state)
    {
        return true;
    }

    public bool AmbientActivate(string objectValue, int state)
    {
        return true;
    }

    public bool AttachTransitionToDoor(string global, string objectValue)
    {
        return true;
    }

    public bool DeathMatchPositionGlobal(string areaname, string dest, int player)
    {
        return true;
    }

    public bool DeathMatchPositionArea(string areaname, string dest, int player)
    {
        return true;
    }

    public bool DeathMatchPositionLocal(string areaname, string dest, int player)
    {
        return true;
    }

    public bool ApplyDamagePercent(string objectValue, int amount, int type)
    {
        return true;
    }

    public bool SG(string name, int num)
    {
        return true;
    }

    public bool AddMapNote(string position, int stringRef)
    {
        return true;
    }

    public bool AddMapNoteColor(string position, int stringRef, int color)
    {
        return true;
    }

    public bool DemoEnd()
    {
        return true;
    }

    public bool MoveGlobalsTo(string fromArea, string toArea, string location)
    {
        return true;
    }

    public bool DisplayStringWait(string objectValue, int strRef)
    {
        return true;
    }

    public bool StateOverrideTime(int time)
    {
        return true;
    }

    public bool StateOverrideFlag(int state)
    {
        return true;
    }

    public bool SetRestEncounterProbabilityDay(int prob)
    {
        return true;
    }

    public bool SetRestEncounterProbabilityNight(int prob)
    {
        return true;
    }

    public bool SoundActivate(string objectValue, int state)
    {
        return true;
    }

    public bool PlaySong(int song)
    {
        return true;
    }

    public bool ForceSpellRange(string target, int spell)
    {
        return true;
    }

    public bool ForceSpellRangeRES(string res, string target)
    {
        return true;
    }

    public bool ForceSpellPointRange(string target, int spell)
    {
        return true;
    }

    public bool ForceSpellPointRangeRES(string res, string target)
    {
        return true;
    }

    public bool SetPlayerSound(string objectValue, int strref, int slotNum)
    {
        return true;
    }

    public bool SetAreaRestFlag(int canRest)
    {
        return true;
    }

    public bool FakeEffectExpiryCheck(string objectValue, int ticks)
    {
        return true;
    }

    public bool CreateCreatureImpassableAllowOverlap(string newObject, string location, int face)
    {
        return true;
    }

    public bool CreateCreatureImpassableAllowOverlapEffect(string newObject, string effect, string location, int face)
    {
        return true;
    }

    public bool SetBeenInPartyFlags()
    {
        return true;
    }

    public bool GoToStartScreen()
    {
        return true;
    }

    public bool ExitPocketPlane()
    {
        return true;
    }

    public bool AddXP2DA(string column)
    {
        return true;
    }

    public bool RemoveMapNote(string position, int strref)
    {
        return true;
    }

    public bool TriggerWalkTo(string objectValue)
    {
        return true;
    }

    public bool AddAreaType(int type)
    {
        return true;
    }

    public bool RemoveAreaType(int type)
    {
        return true;
    }

    public bool AddAreaFlag(int type)
    {
        return true;
    }

    public bool RemoveAreaFlag(int type)
    {
        return true;
    }

    public bool StartDialogNoName(string dialogFile, string target)
    {
        return true;
    }

    public bool SetTokenGlobal(string global, string area, string token)
    {
        return true;
    }

    public bool MakeGlobal()
    {
        return true;
    }

    public bool ReallyForceSpellPoint(string target, int spell)
    {
        return true;
    }

    public bool ReallyForceSpellPointRES(string res, string target)
    {
        return true;
    }

    public bool SetCursorState(int boolValue)
    {
        return true;
    }

    public bool SetCutSceneLite(int boolValue)
    {
        return true;
    }

    public bool SwingOnce()
    {
        return true;
    }

    public bool StaticSequence(string objectValue, int sequence)
    {
        return true;
    }

    public bool StaticPalette(string palette, string objectValue)
    {
        return true;
    }

    public bool DisplayStringHeadDead(string objectValue, int strRef)
    {
        return true;
    }

    public bool MoveToExpansion()
    {
        return true;
    }

    public bool StartRainNow()
    {
        return true;
    }

    public bool SetSequence(int sequence)
    {
        return true;
    }

    public bool DisplayStringNoNameHead(string objectValue, int strRef)
    {
        return true;
    }

    public bool SetEncounterProbability(string fromArea, string toArea, int probability)
    {
        return true;
    }

    public bool SetupWish(int column, int count)
    {
        return true;
    }

    public bool SetupWishObject(string creature, int count)
    {
        return true;
    }

    public bool LeaveAreaLUAEntry(string area, string entry, string point, int face)
    {
        return true;
    }

    public bool LeaveAreaLUAPanicEntry(string area, string entry, string point, int face)
    {
        return true;
    }

    public bool SetAreaScript(string script, int scriptSlot)
    {
        return true;
    }

    public bool AdvanceTime(int time)
    {
        return true;
    }

    public bool RunAwayFromNoInterruptNoLeaveArea(string creature, int time)
    {
        return true;
    }

    public bool RunAwayFromNoLeaveArea(string creature, int time)
    {
        return true;
    }

    public bool TransformItem(string oldItem, string newItem)
    {
        return true;
    }

    public bool ForceRandomEncounter(string area)
    {
        return true;
    }

    public bool ForceRandomEncounterEntry(string area, string entry)
    {
        return true;
    }

    public bool JumpToObject(string target)
    {
        return true;
    }

    public bool SetMusic(int slot, int song)
    {
        return true;
    }

    public bool ChangeStoreMarkup(string store, int buyMarkup, int sellMarkup)
    {
        return true;
    }

    public bool DisplayStringPoint(string location, int strref)
    {
        return true;
    }

    public bool RemoveStoreItem(string store, string item, int count)
    {
        return true;
    }

    public bool AddStoreItem(string store, string item, int count, int flags)
    {
        return true;
    }

    public bool SetGlobalRandom(string variable, string area, int count, int size)
    {
        return true;
    }

    public bool SetGlobalRandomPlus(string variable, string area, int count, int size, int plus)
    {
        return true;
    }

    public bool DestroyGroundPiles()
    {
        return true;
    }

    public bool GameOver(int strRef)
    {
        return true;
    }

    public bool SetWorldmap(string worldmap)
    {
        return true;
    }

    public bool WaitRandom(int minTime, int maxTime)
    {
        return true;
    }

    public bool StartRandomTimer(int timerID, int minTime, int maxTime)
    {
        return true;
    }

    public bool ChangeStat(string objectValue, int stat, int value, int modifier)
    {
        return true;
    }

    public bool ResetMorale(int failure, int level)
    {
        return true;
    }

    public bool MoveToCampaign(string campaign)
    {
        return true;
    }

    public bool AddWorldmapAreaFlag(string area, int type)
    {
        return true;
    }

    public bool RemoveWorldmapAreaFlag(string area, int type)
    {
        return true;
    }

    public bool SetNoWaitX(int setReset)
    {
        return true;
    }

    public bool DisplayStringNoNameDlg(string objectValue, int strRef)
    {
        return true;
    }

    public bool SetGlobalTimerRandom(string name, string area, int min, int max)
    {
        return true;
    }

    public bool ExportParty(string name)
    {
        return true;
    }

    public bool TakeCreatureItems(string objectValue, int type)
    {
        return true;
    }

    public bool TakeObjectGoldGlobal(string name, string area, string objectValue)
    {
        return true;
    }

    public bool GiveObjectGoldGlobal(string name, string area, string objectValue)
    {
        return true;
    }

    public bool JoinPartyOverride()
    {
        return true;
    }

    public bool MakeGlobalOverride()
    {
        return true;
    }

    public bool AddXPWorth(string objectValue)
    {
        return true;
    }

    public bool AddXPWorthOnce(string objectValue, int clearStat)
    {
        return true;
    }

    public bool XEquipItem(string item, string objectValue, int slot, int equipUnEquip)
    {
        return true;
    }

    public bool MoveToObjectOffset(string target, string offset)
    {
        return true;
    }

    public bool SetCutSceneBreakable(int breakable)
    {
        return true;
    }

    public bool DisplayStringHeadNoLog(string objectValue, int strRef)
    {
        return true;
    }

    public bool SetItemFlags(string itemName, int flags, int setReset)
    {
        return true;
    }

    public bool DisableAI(string objectValue, int disable)
    {
        return true;
    }

    public bool MoveContainerContents(string container1, string container2)
    {
        return true;
    }
    public bool BitSet(string name, string scope, int bit)
    {
        return true;
    }

    public bool BitClear(string name, string scope, int bit)
    {
        return true;
    }

    public bool ContinueGame(int state)
    {
        return true;
    }
    public bool DisplayStringPointLog(string location, int strref)
    {
        return true;
    }

    public bool ResetPlayerAI()
    {
        return true;
    }

    public bool RandomWalkTime(int time)
    {
        return true;
    }

    public bool RandomWalkContinuousTime(int time)
    {
        return true;
    }

    public bool ZoomLock(int lockValue)
    {
        return true;
    }

    public bool IncrementGlobalOnce(string name1, string area1, string name2, string area2, int val)
    {
        return true;
    }

    public bool IncrementGlobalOnceEx(string var1, string var2, int val)
    {
        return true;
    }

    public bool PlaySoundNotRanged(string sound)
    {
        return true;
    }

    public bool SetZoomViewport(string point)
    {
        return true;
    }

    public bool StoreZoomLevel()
    {
        return true;
    }

    public bool RestoreZoomLevel()
    {
        return true;
    }

    public bool WaitSync(int amount)
    {
        return true;
    }

    public bool WaitForVoiceChannel()
    {
        return true;
    }

    public bool PlaySoundThroughVoice(string sound)
    {
        return true;
    }
}