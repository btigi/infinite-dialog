//var triggerText = "Global(\"Lumbar_Huff\", \"GLOBAL\", 1)Global(\"Know_L\r\numbar\", \"GLOBAL\", 0)";
var triggerText = "AreaCheck(\"AR1234\")Global(\"test\", \"global\", 1)";
var actionText = "JoinParty(test, 1) Other(6)";

var globalState = new List<(string name, int value)>();

var area = new Area();
area.AreaCode = "AR1234";

var tp = new TriggerProcessor();
tp.Area = area;
tp.GlobalState = globalState;
var triggers = triggerText.Split([")"], StringSplitOptions.None)
                          .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
                          .ToArray();
var triggered = ProcessMethod<TriggerProcessor>(triggers, tp);

if (triggered)
{
    var ap = new ActionProcessor();
    var actions = actionText.Split([")"], StringSplitOptions.None)
                            .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
                            .ToArray();
    ProcessMethod<ActionProcessor>(actions, ap);
}


static bool ProcessMethod<T>(string[] methods, object o)
{
    bool? result = true;
    foreach (var methodCall in methods)
    {
        if (methodCall == ")")
            continue;

        var methodName = methodCall[..methodCall.IndexOf('(')];
        var parametersString = methodCall.Substring(methodCall.IndexOf('(') + 1, methodCall.IndexOf(')') - methodCall.IndexOf('(') - 1);

        var parameters = parametersString.Split(',').Select(p => p.Trim()).ToArray();

        var method = typeof(T).GetMethod(methodName);

        if (method != null)
        {
            var methodParameters = method.GetParameters()
                                         .Select((p, index) => ConvertParameter(parameters[index], p.ParameterType))
                                         .Select(m => (m as string) != null ? (m as string).Trim('\"') : m)
                                         .ToArray();                                        

            result = method.Invoke(o, methodParameters) as bool?;
            if (result != true)
            {
                Console.WriteLine("Method result: " + false);
                break;
            }
            Console.WriteLine("Method result: " + result);
        }
        else
        {
            Console.WriteLine("Method not found.");
        }
    }
    return result ?? false;
}


static object ConvertParameter(string parameter, Type targetType)
{
    if (targetType == typeof(string))
    {
        return parameter;
    }
    return Convert.ChangeType(parameter, targetType);
}

public class Area()
{
    public List<(string variable, string value)> Variables = new();
    public string AreaCode { get; set; }
}

public class Creature()
{
    public List<(string variable, string value)> Variables = new();
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Wisdeom { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Charisma { get; set; }
    public int Class { get; set; }
    public int Specific { get; set; }
    public int Gender { get; set; }
    public int HP { get; set; }
}

public class ActionProcessor()
{
    public Area Area { get; set; }
    public Creature Creature { get; set; }

    public bool NoAction()
    {
        return true;
    }

    public bool ActionOverride(string actor, string action)
    {
        return true;
    }

    public bool AddWayPoint(string waypoint)
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

    public bool CreateCreature(string newOject, string location, int face)
    {
        return true;
    }

    public bool Dialog(string @object)
    {
        return true;
    }

    public bool Dialogue(string @object)
    {
        return Dialog(@object);
    }

    public bool DropItem(string @object, string location)
    {
        return true;
    }

    public bool Enemy()
    {
        return true;
    }

    public bool FindTraps()
    {
        return true;
    }

    public bool GetItems(string @object, string target)
    {
        return true;
    }


    public bool JoinParty(string input, int other)
    {
        return true;
    }

    public bool Other(int a)
    {
        return true;
    }
}

public class TriggerProcessor()
{
    public Area Area { get; set; }
    public Creature Creature { get; set; }
    public List<(string name, int value)> GlobalState = new();

    public bool Acquired(string resRef)
    {
        return false;
    }

    public bool AttackedBy(object attacker, string style)
    {
        return false;
    }

    public bool Help(object obj)
    {
        return false;
    }

    public bool Joins(object obj)
    {
        return false;
    }

    public bool Leaves(object obj)
    {
        return false;
    }

    public bool ReceivedOrder(object obj, int orderId)
    {
        return false;
    }

    public bool Said(object obj, int dialogId)
    {
        return false;
    }

    public bool TurnedBy(object obj)
    {
        return false;
    }

    public bool Unusable(string resRef)
    {
        return false;
    }

    public bool Alignment(object obj, int align)
    {
        return false;
    }

    public bool Allegiance(object obj, int allegiance)
    {
        return false;
    }

    public bool Class(object obj, int classId)
    {
        return false;
    }

    public bool Exists(object obj)
    {
        return false;
    }

    public bool General(object obj, int general)
    {
        return false;
    }

    public bool Global(string name, string area, int value)
    {
        if (area == "global")
        {
            return this.GlobalState.SingleOrDefault(w => w.name == name).value == value;
        }
        if (area == "area")
        {
            return true;
        }
        return false;
    }

    public bool HP(object obj, int hitPoints)
    {
        return false;
    }

    public bool HPGT(object obj, int hitPoints)
    {
        return false;
    }

    public bool HPLT(object obj, int hitPoints)
    {
        return false;
    }

    public bool LOS(object obj, int range)
    {
        return false;
    }

    public bool Morale(object obj, int morale)
    {
        return false;
    }

    public bool MoraleGT(object obj, int morale)
    {
        return false;
    }

    public bool MoraleLT(object obj, int morale)
    {
        return false;
    }

    public bool Race(object obj, int race)
    {
        return false;
    }

    public bool Range(object obj, int range)
    {
        return false;
    }

    public bool Reputation(object obj, int reputation)
    {
        return false;
    }

    public bool ReputationGT(object obj, int reputation)
    {
        return false;
    }

    public bool ReputationLT(object obj, int reputation)
    {
        return false;
    }

    public bool See(object obj)
    {
        return false;
    }

    public bool Specifics(object obj, int specifics)
    {
        return false;
    }

    public bool Time(int time)
    {
        return false;
    }

    public bool TimeOfDay(int timeOfDay)
    {
        return false;
    }

    public bool HitBy(object obj, int damageType)
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

    public bool TargetUnreachable(object obj)
    {
        return false;
    }

    public bool Delay(int delay)
    {
        return false;
    }

    public bool NumCreature(object obj, int number)
    {
        return false;
    }

    public bool NumCreatureLT(object obj, int number)
    {
        return false;
    }

    public bool NumCreatureGT(object obj, int number)
    {
        return false;
    }

    public bool ActionListEmpty()
    {
        return false;
    }

    public bool HPPercent(object obj, int hitPoints)
    {
        return false;
    }

    public bool HPPercentLT(object obj, int hitPoints)
    {
        return false;
    }

    public bool HPPercentGT(object obj, int hitPoints)
    {
        return false;
    }

    public bool Heard(object obj, int shoutId)
    {
        return false;
    }

    public bool False()
    {
        return false;
    }

    public bool HaveSpell(int spell)
    {
        return false;
    }

    public bool HaveAnySpells()
    {
        return false;
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

    public bool StateCheck(object obj, int state)
    {
        return false;
    }

    public bool NotStateCheck(object obj, int state)
    {
        return false;
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

    public bool Reaction(object obj, int value)
    {
        return false;
    }

    public bool ReactionGT(object obj, int value)
    {
        return false;
    }

    public bool ReactionLT(object obj, int value)
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
        return false;
    }

    public bool InParty(object obj)
    {
        return false;
    }

    public bool CheckStat(object obj, int value, int statNum)
    {
        return false;
    }

    public bool CheckStatGT(object obj, int value, int statNum)
    {
        return false;
    }

    public bool CheckStatLT(object obj, int value, int statNum)
    {
        return false;
    }

    public bool RandomNum(int range, int value)
    {
        return false;
    }

    public bool RandomNumGT(int range, int value)
    {
        return false;
    }

    public bool RandomNumLT(int range, int value)
    {
        return false;
    }

    public bool Died(object obj)
    {
        return false;
    }

    public bool Killed(object obj)
    {
        return false;
    }

    public bool Entered(object obj)
    {
        return false;
    }

    public bool Gender(object obj, int gender)
    {
        return false;
    }

    public bool PartyGold(int amount)
    {
        return false;
    }

    public bool PartyGoldGT(int amount)
    {
        return false;
    }

    public bool PartyGoldLT(int amount)
    {
        return false;
    }

    public bool Dead(string name)
    {
        return false;
    }

    public bool Opened(object obj)
    {
        return false;
    }

    public bool Closed(object obj)
    {
        return false;
    }

    public bool Detected(object obj)
    {
        return false;
    }

    public bool Reset(object obj)
    {
        return false;
    }

    public bool Disarmed(object obj)
    {
        return false;
    }

    public bool Unlocked(object obj)
    {
        return false;
    }

    public bool OutOfAmmo()
    {
        return false;
    }

    public bool NumTimesInteracted(object npc, int num)
    {
        return false;
    }

    public bool NumTimesInteractedGT(object npc, int num)
    {
        return false;
    }

    public bool NumTimesInteractedLT(object npc, int num)
    {
        return false;
    }

    public bool BreakingPoint()
    {
        return false;
    }

    public bool PickPocketFailed(object obj)
    {
        return false;
    }

    public bool StealFailed(object obj)
    {
        return false;
    }

    public bool DisarmFailed(object obj)
    {
        return false;
    }

    public bool PickLockFailed(object obj)
    {
        return false;
    }

    public bool HasItem(string resRef, object obj)
    {
        return false;
    }

    public bool InteractingWith(object obj)
    {
        return false;
    }

    public bool InWeaponRange(object obj)
    {
        return false;
    }

    public bool HasWeaponEquipped(object obj)
    {
        return false;
    }

    public bool Happiness(object obj, int amount)
    {
        return false;
    }

    public bool HappinessGT(object obj, int amount)
    {
        return false;
    }

    public bool HappinessLT(object obj, int amount)
    {
        return false;
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
        return false;
    }

    public bool NumInPartyGT(int num)
    {
        return false;
    }

    public bool NumInPartyLT(int num)
    {
        return false;
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

    public bool Clicked(object obj)
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

    public bool Detect(object obj)
    {
        return false;
    }

    public bool Contains(string resRef, object obj)
    {
        return false;
    }

    public bool OpenState(object obj, bool isOpen)
    {
        return false;
    }

    public bool NumItems(string resRef, object obj, int num)
    {
        return false;
    }

    public bool NumItemsGT(string resRef, object obj, int num)
    {
        return false;
    }

    public bool NumItemsLT(string resRef, object obj, int num)
    {
        return false;
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

    public bool IsOverMe(object obj)
    {
        return false;
    }

    public bool AreaCheck(string resRef)
    {
        return this.Area.AreaCode == resRef;
    }

    public bool HasItemEquipped(string resRef, object obj)
    {
        return false;
    }

    public bool NumCreatureVsParty(object obj, int num)
    {
        return false;
    }

    public bool NumCreatureVsPartyLT(object obj, int num)
    {
        return false;
    }

    public bool NumCreatureVsPartyGT(object obj, int num)
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

    public bool TrapTriggered(object triggerer)
    {
        return false;
    }

    public bool PartyMemberDied(object obj)
    {
        return false;
    }

    public bool OR(int orCount)
    {
        return false;
    }

    public bool InPartySlot(object obj, int slot)
    {
        return false;
    }

    public bool SpellCast(object obj, int spell)
    {
        return false;
    }

    public bool InLine(string target, object obj)
    {
        return false;
    }

    public bool PartyRested()
    {
        return false;
    }

    public bool Level(object obj, int level)
    {
        return false;
    }

    public bool LevelGT(object obj, int level)
    {
        return false;
    }

    public bool LevelLT(object obj, int level)
    {
        return false;
    }

    public bool Summoned(object obj)
    {
        return false;
    }

    public bool GlobalsEqual(string name1, string name2)
    {
        return false;
    }

    public bool GlobalsGT(string name1, string name2)
    {
        return false;
    }

    public bool GlobalsLT(string name1, string name2)
    {
        return false;
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

    public bool ObjectActionListEmpty(object obj)
    {
        return false;
    }

    public bool OnScreen(object obj)
    {
        return false;
    }

    public bool InActiveArea(object obj)
    {
        return false;
    }

    public bool SpellCastOnMe(object caster, int spell)
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

    public bool Name(string name, object obj)
    {
        return false;
    }

    public bool SpellCastPriest(object obj, int spell)
    {
        return false;
    }

    public bool SpellCastInnate(object obj, int spell)
    {
        return false;
    }

    public bool IsValidForPartyDialog(object obj)
    {
        return false;
    }

    public bool PartyHasItemIdentified(string resRef)
    {
        return false;
    }

    public bool HasBounceEffects(object obj)
    {
        return false;
    }

    public bool HasImmunityEffects(object obj)
    {
        return false;
    }

    public bool HasItemSlot(object obj, int slot)
    {
        return false;
    }

    public bool PersonalSpaceDistance(object obj, int range)
    {
        return false;
    }

    public bool InMyGroup(object obj)
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
        return false;
    }

    public bool NumInPartyAliveGT(int num)
    {
        return false;
    }

    public bool NumInPartyAliveLT(int num)
    {
        return false;
    }

    public bool Kit(object obj, int kit)
    {
        return false;
    }

    public bool IsGabber(object obj)
    {
        return false;
    }

    public bool IsActive(object obj)
    {
        return false;
    }

    public bool CharName(string name, object obj)
    {
        return false;
    }

    public bool FallenRanger(object obj)
    {
        return false;
    }

    public bool FallenPaladin(object obj)
    {
        return false;
    }

    public bool InventoryFull(object obj)
    {
        return false;
    }

    public bool HasItemEquippedReal(string resRef, object obj)
    {
        return false;
    }

    public bool XP(object obj, int xp)
    {
        return false;
    }

    public bool XPGT(object obj, int xp)
    {
        return false;
    }

    public bool XPLT(object obj, int xp)
    {
        return false;
    }

    public bool G(string resRef, int num)
    {
        return false;
    }

    public bool GGT(string resRef, int num)
    {
        return false;
    }

    public bool GLT(string resRef, int num)
    {
        return false;
    }

    public bool ModalState(int state)
    {
        return false;
    }

    public bool InMyArea(object obj)
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