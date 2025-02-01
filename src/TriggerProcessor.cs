public class TriggerProcessor
{
    private readonly ObjectLocator objectLocator;
    private readonly IdsProcessor idsProcessor;
    private readonly Random random;

    public TriggerProcessor(ObjectLocator objectLocator, IdsProcessor idsProcessor)
    {
        this.objectLocator = objectLocator;
        this.idsProcessor = idsProcessor;
        random = new Random();
    }

    public Area Area { get; set; }
    public Creature Creature { get; set; }
    public List<(string name, int value)> GlobalState = new();

    public bool Acquired(string resRef)
    {
        return false;
    }

    public bool AttackedBy(string attacker, string style)
    {
        return false;
    }

    public bool Help(string obj)
    {
        return false;
    }

    public bool Joins(string obj)
    {
        return false;
    }

    public bool Leaves(string obj)
    {
        return false;
    }

    public bool ReceivedOrder(string obj, int orderId)
    {
        return false;
    }

    public bool Said(string obj, int dialogId)
    {
        return false;
    }

    public bool TurnedBy(string obj)
    {
        return false;
    }

    public bool Unusable(string resRef)
    {
        return false;
    }

    public bool Alignment(string obj, int align)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Alignment == align;
    }

    public bool Allegiance(string obj, int allegiance)
    {
        return false;
    }

    public bool Class(string obj, int classId)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Class == classId;
    }

    public bool Exists(string obj)
    {
        return false;
    }

    public bool General(string obj, int general)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.General == general;
    }

    public bool Global(string name, string area, int value)
    {
        if (area == "global")
        {
            return this.GlobalState.SingleOrDefault(w => w.name == name).value == value;
        }
        if (area == "area")
        {
            return this.Area.Variables.Count(w => w.variable == name && w.value == value) == 1;
        }
        if (area == "locals")
        {
            //
        }
        return false;
    }

    public bool HP(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.HP == hitPoints;
    }

    public bool HPGT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.HP > hitPoints;
    }

    public bool HPLT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.HP < hitPoints;
    }

    public bool LOS(string obj, int range)
    {
        return false;
    }

    public bool Morale(string obj, int morale)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Morale == morale;
    }

    public bool MoraleGT(string obj, int morale)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Morale > morale;
    }

    public bool MoraleLT(string obj, int morale)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Morale < morale;
    }

    public bool Race(string obj, int race)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Race == race;
    }

    public bool Range(string obj, int range)
    {
        return false;
    }

    public bool Reputation(string obj, int reputation)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Reputation == reputation;
    }

    public bool ReputationGT(string obj, int reputation)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Reputation > reputation;
    }

    public bool ReputationLT(string obj, int reputation)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Reputation < reputation;
    }

    public bool See(string obj)
    {
        return false;
    }

    public bool Specifics(string obj, int specifics)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Specific < specifics;
    }

    public bool Time(int time)
    {
        return false;
    }

    public bool TimeOfDay(int timeOfDay)
    {
        return false;
    }

    public bool HitBy(string obj, int damageType)
    {
        return false;
    }

    public bool HotKey(int key)
    {
        return false;
    }

    public bool TimerExpired(int id)
    {
        return false;
    }

    public bool True()
    {
        return true;
    }

    public bool Trigger(int triggerNum)
    {
        return false;
    }

    public bool Die()
    {
        return false;
    }

    public bool TargetUnreachable(string obj)
    {
        return false;
    }

    public bool Delay(int delay)
    {
        return false;
    }

    public bool NumCreature(string obj, int number)
    {
        return false;
    }

    public bool NumCreatureLT(string obj, int number)
    {
        return false;
    }

    public bool NumCreatureGT(string obj, int number)
    {
        return false;
    }

    public bool ActionListEmpty()
    {
        return false;
    }

    public bool HPPercent(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.HP / creature?.MaxHP == hitPoints;
    }

    public bool HPPercentLT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.HP / creature?.MaxHP < hitPoints;
    }

    public bool HPPercentGT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.HP / creature?.MaxHP > hitPoints;
    }

    public bool Heard(string obj, int shoutId)
    {
        return false;
    }

    public bool False()
    {
        return false;
    }

    public bool HaveSpell(int spell)
    {
        return this.Creature.MemorisedSpells.Contains(spell);
    }

    public bool HaveSpell(string spell)
    {
        var spellId = idsProcessor.GetIdsValue("spell.ids", spell);
        return this.Creature.MemorisedSpells.Contains(spellId);
    }

    public bool HaveAnySpells()
    {
        return this.Creature.MemorisedSpells.Any();
    }

    public bool BecameVisible()
    {
        return false;
    }

    public bool GlobalGT(string name, string area, int value)
    {
        return false;
    }

    public bool GlobalLT(string name, string area, int value)
    {
        return false;
    }

    public bool OnCreation()
    {
        return false;
    }

    public bool StateCheck(string obj, int state)
    {
        var creature = objectLocator.GetObject(obj);
        return (creature.State & state) > 0;
    }

    public bool NotStateCheck(string obj, int state)
    {
        var creature = objectLocator.GetObject(obj);
        return (creature.State & state) == 0;
    }

    public bool NumTimesTalkedTo(int num)
    {
        return false;
    }

    public bool NumTimesTalkedToGT(int num)
    {
        return false;
    }

    public bool NumTimesTalkedToLT(int num)
    {
        return false;
    }

    public bool Reaction(string obj, int value)
    {
        return false;
    }

    public bool ReactionGT(string obj, int value)
    {
        return false;
    }

    public bool ReactionLT(string obj, int value)
    {
        return false;
    }

    public bool GlobalTimerExact(string name, string area)
    {
        return false;
    }

    public bool GlobalTimerExpired(string name, string area)
    {
        return false;
    }

    public bool GlobalTimerNotExpired(string name, string area)
    {
        return false;
    }

    public bool PartyHasItem(string item)
    {
        foreach (var partyMember in objectLocator.Party.Members)
        {
            if (partyMember.Creature.Items.Contains(item))
            {
                return true;
            }
        }
        return false;
    }

    public bool InParty(string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.Members.Select(s => s.Creature).Contains(creature);
    }

    public bool CheckStat(string obj, int value, int statNum)
    {
        return false;
    }

    public bool CheckStatGT(string obj, int value, int statNum)
    {
        return false;
    }

    public bool CheckStatLT(string obj, int value, int statNum)
    {
        return false;
    }

    public bool RandomNum(int range, int value)
    {
        return random.Next(1, range) == value;
    }

    public bool RandomNumGT(int range, int value)
    {
        return random.Next(1, range) > value;
    }

    public bool RandomNumLT(int range, int value)
    {
        return random.Next(1, range) < value;
    }

    public bool Died(string obj)
    {
        return false;
    }

    public bool Killed(string obj)
    {
        return false;
    }

    public bool Entered(string obj)
    {
        return false;
    }

    public bool Gender(string obj, int gender)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Gender == gender;
    }

    public bool PartyGold(int amount)
    {
        return objectLocator.Party.PartyGold == amount;
    }

    public bool PartyGoldGT(int amount)
    {
        return objectLocator.Party.PartyGold > amount;
    }

    public bool PartyGoldLT(int amount)
    {
        return objectLocator.Party.PartyGold < amount;
    }

    public bool Dead(string name)
    {
        return false;
    }

    public bool Opened(string obj)
    {
        return false;
    }

    public bool Closed(string obj)
    {
        return false;
    }

    public bool Detected(string obj)
    {
        return false;
    }

    public bool Reset(string obj)
    {
        return false;
    }

    public bool Disarmed(string obj)
    {
        return false;
    }

    public bool Unlocked(string obj)
    {
        return false;
    }

    public bool OutOfAmmo()
    {
        return false;
    }

    public bool NumTimesInteracted(string npc, int num)
    {
        return false;
    }

    public bool NumTimesInteractedGT(string npc, int num)
    {
        return false;
    }

    public bool NumTimesInteractedLT(string npc, int num)
    {
        return false;
    }

    public bool BreakingPoint()
    {
        return false;
    }

    public bool PickPocketFailed(string obj)
    {
        return false;
    }

    public bool StealFailed(string obj)
    {
        return false;
    }

    public bool DisarmFailed(string obj)
    {
        return false;
    }

    public bool PickLockFailed(string obj)
    {
        return false;
    }

    public bool HasItem(string resRef, string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return creature.Items.Any(a => a == resRef);
    }

    public bool InteractingWith(string obj)
    {
        return false;
    }

    public bool InWeaponRange(string obj)
    {
        return false;
    }

    public bool HasWeaponEquipped(string obj)
    {
        return false;
    }

    public bool Happiness(string obj, int amount)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.Members.SingleOrDefault(s => s.Creature == creature)?.Happiness == amount;
    }

    public bool HappinessGT(string obj, int amount)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.Members.SingleOrDefault(s => s.Creature == creature)?.Happiness > amount;
    }

    public bool HappinessLT(string obj, int amount)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.Members.SingleOrDefault(s => s.Creature == creature)?.Happiness < amount;
    }

    public bool TimeGT(int time)
    {
        return false;
    }

    public bool TimeLT(int time)
    {
        return false;
    }

    public bool NumInParty(int num)
    {
        return objectLocator.Party.Members.Count() == num;
    }
    
    public bool NumInPartyGT(int num)
    {
        return objectLocator.Party.Members.Count() > num;
    }

    public bool NumInPartyLT(int num)
    {
        return objectLocator.Party.Members.Count() < num;
    }

    public bool UnselectableVariable(int num)
    {
        return false;
    }

    public bool UnselectableVariableGT(int num)
    {
        return false;
    }

    public bool UnselectableVariableLT(int num)
    {
        return false;
    }

    public bool Clicked(string obj)
    {
        return false;
    }

    public bool NumberOfTimesTalkedTo(int num)
    {
        return false;
    }

    public bool NumDead(string name, int num)
    {
        return false;
    }

    public bool NumDeadGT(string name, int num)
    {
        return false;
    }

    public bool NumDeadLT(string name, int num)
    {
        return false;
    }

    public bool Detect(string obj)
    {
        return false;
    }

    public bool Contains(string resRef, string obj)
    {
        return false;
    }

    public bool OpenState(string obj, bool isOpen)
    {
        return false;
    }

    public bool NumItems(string resRef, string obj, int num)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Items.Count(w => w == resRef) == num;
    }

    public bool NumItemsGT(string resRef, string obj, int num)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Items.Count(w => w == resRef) > num;
    }

    public bool NumItemsLT(string resRef, string obj, int num)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Items.Count(w => w == resRef) < num;
    }

    public bool NumItemsParty(string resRef, int num)
    {
        return false;
    }

    public bool NumItemsPartyGT(string resRef, int num)
    {
        return false;
    }

    public bool NumItemsPartyLT(string resRef, int num)
    {
        return false;
    }

    public bool IsOverMe(string obj)
    {
        return false;
    }

    public bool AreaCheck(string resRef)
    {
        return this.Area.AreaCode == resRef;
    }

    public bool HasItemEquipped(string resRef, string obj)
    {
        return false;
    }

    public bool NumCreatureVsParty(string obj, int num)
    {
        return false;
    }

    public bool NumCreatureVsPartyLT(string obj, int num)
    {
        return false;
    }

    public bool NumCreatureVsPartyGT(string obj, int num)
    {
        return false;
    }

    public bool CombatCounter(int num)
    {
        return false;
    }

    public bool CombatCounterLT(int num)
    {
        return false;
    }

    public bool CombatCounterGT(int num)
    {
        return false;
    }

    public bool AreaType(int areaType)
    {
        return false;
    }

    public bool TrapTriggered(string triggerer)
    {
        return false;
    }

    public bool PartyMemberDied(string obj)
    {
        return false;
    }

    public bool OR(int orCount)
    {
        return false;
    }

    public bool InPartySlot(string obj, int slot)
    {
        return false;
    }

    public bool SpellCast(string obj, int spell)
    {
        return false;
    }

    public bool InLine(string target, string obj)
    {
        return false;
    }

    public bool PartyRested()
    {
        return false;
    }

    public bool Level(string obj, int level)
    {
        var creature = objectLocator.GetObject(obj);
        var creatureLevel = creature?.Level1;

        var divisor = 1;
        if (creature?.Level2 > 0)
        {
            divisor++;
            creatureLevel += creature?.Level2;
        }
        if (creature?.Level3 > 0)
        {
            divisor++;
            creatureLevel += creature?.Level3;
        }

        return (creatureLevel / divisor) == level;
    }

    public bool LevelGT(string obj, int level)
    {
        var creature = objectLocator.GetObject(obj);
        var creatureLevel = creature?.Level1;

        var divisor = 1;
        if (creature?.Level2 > 0)
        {
            divisor++;
            creatureLevel += creature?.Level2;
        }
        if (creature?.Level3 > 0)
        {
            divisor++;
            creatureLevel += creature?.Level3;
        }

        return (creatureLevel / divisor) > level;
    }

    public bool LevelLT(string obj, int level)
    {
        var creature = objectLocator.GetObject(obj);
        var creatureLevel = creature?.Level1;

        var divisor = 1;
        if (creature?.Level2 > 0)
        {
            divisor++;
            creatureLevel += creature?.Level2;
        }
        if (creature?.Level3 > 0)
        {
            divisor++;
            creatureLevel += creature?.Level3;
        }

        return (creatureLevel / divisor) < level;
    }

    public bool Summoned(string obj)
    {
        return false;
    }

    public bool GlobalsEqual(string name1, string name2)
    {
        var global1 = this.GlobalState.SingleOrDefault(w => w.name == name1).value;
        var global2 = this.GlobalState.SingleOrDefault(w => w.name == name2).value;
        return global1 == global2;
    }

    public bool GlobalsGT(string name1, string name2)
    {
        var global1 = this.GlobalState.SingleOrDefault(w => w.name == name1).value;
        var global2 = this.GlobalState.SingleOrDefault(w => w.name == name2).value;
        return global1 > global2;
    }

    public bool GlobalsLT(string name1, string name2)
    {
        var global1 = this.GlobalState.SingleOrDefault(w => w.name == name1).value;
        var global2 = this.GlobalState.SingleOrDefault(w => w.name == name2).value;
        return global1 < global2;
    }

    public bool LocalsEqual(string name1, string name2)
    {
        return false;
    }

    public bool LocalsGT(string name1, string name2)
    {
        return false;
    }

    public bool LocalsLT(string name1, string name2)
    {
        return false;
    }

    public bool ObjectActionListEmpty(string obj)
    {
        return false;
    }

    public bool OnScreen(string obj)
    {
        return false;
    }

    public bool InActiveArea(string obj)
    {
        return false;
    }

    public bool SpellCastOnMe(string caster, int spell)
    {
        return false;
    }

    public bool CalendarDay(int day)
    {
        return false;
    }

    public bool CalendarDayGT(int day)
    {
        return false;
    }

    public bool CalendarDayLT(int day)
    {
        return false;
    }

    public bool Name(string name, string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.ScriptName == name;
    }

    public bool SpellCastPriest(string obj, int spell)
    {
        return false;
    }

    public bool SpellCastInnate(string obj, int spell)
    {
        return false;
    }

    public bool IsValidForPartyDialog(string obj)
    {
        // obj is in the party
        // obj is not dead
        return false;
    }

    public bool PartyHasItemIdentified(string resRef)
    {
        return false;
    }

    public bool HasBounceEffects(string obj)
    {
        return false;
    }

    public bool HasImmunityEffects(string obj)
    {
        return false;
    }

    public bool HasItemSlot(string obj, int slot)
    {
        return false;
    }

    public bool PersonalSpaceDistance(string obj, int range)
    {
        return false;
    }

    public bool InMyGroup(string obj)
    {
        return false;
    }

    public bool RealGlobalTimerExact(string name, string area)
    {
        return false;
    }

    public bool RealGlobalTimerExpired(string name, string area)
    {
        return false;
    }

    public bool RealGlobalTimerNotExpired(string name, string area)
    {
        return false;
    }

    public bool NumInPartyAlive(int num)
    {
        return objectLocator.Party.Members.Count(c => c.State != 0x8000) == num;
    }

    public bool NumInPartyAliveGT(int num)
    {
        return objectLocator.Party.Members.Count(c => c.State != 0x8000) > num;
    }

    public bool NumInPartyAliveLT(int num)
    {
        return objectLocator.Party.Members.Count(c => c.State != 0x8000) < num;
    }

    public bool Kit(string obj, int kit)
    {
        return false;
    }

    public bool IsGabber(string obj)
    {
        return false;
    }

    public bool IsActive(string obj)
    {
        return false;
    }

    public bool CharName(string name, string obj)
    {
        return false;
    }

    public bool FallenRanger(string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.FallenRanger ?? false;
    }

    public bool FallenPaladin(string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.FallenPaladin ?? false;
    }

    public bool InventoryFull(string obj)
    {
        return false;
    }

    public bool HasItemEquippedReal(string resRef, string obj)
    {
        return false;
    }

    public bool XP(string obj, int xp)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.XP == xp;
    }

    public bool XPGT(string obj, int xp)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.XP > xp;
    }

    public bool XPLT(string obj, int xp)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.XP < xp;
    }

    public bool G(string resRef, int num)
    {
        return this.GlobalState.SingleOrDefault(w => w.name == resRef).value == num;
    }

    public bool GGT(string resRef, int num)
    {
        return this.GlobalState.SingleOrDefault(w => w.name == resRef).value > num;
    }

    public bool GLT(string resRef, int num)
    {
        return this.GlobalState.SingleOrDefault(w => w.name == resRef).value < num;
    }

    public bool ModalState(int state)
    {
        return objectLocator.Party.Members.SingleOrDefault(s => s.Creature == this.Creature)?.ModalAction == state;
    }

    public bool InMyArea(string obj)
    {
        return false;
    }

    public bool TookDamage()
    {
        return false;
    }

    public bool DamageTaken(int amount)
    {
        return false;
    }

    public bool DamageTakenGT(int amount)
    {
        return false;
    }

    public bool DamageTakenLT(int amount)
    {
        return false;
    }
}