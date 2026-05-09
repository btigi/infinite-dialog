using ii.InfinityEngine.Files;

public class TriggerProcessor
{
    private readonly ObjectLocator objectLocator;
    private readonly IdsProcessor idsProcessor;
    private List<StoFile> stores;
    private readonly Random random;
    private List<ItmFile> items;
    private GamFile game;
    private TlkFile tlk;

    public TriggerProcessor(ObjectLocator objectLocator, IdsProcessor idsProcessor, List<DimensionalArrayFile> dimensionalArrayFiles, List<StoFile> stores, List<ItmFile> items,
                            GamFile game, TlkFile tlk)
    {
        this.objectLocator = objectLocator;
        this.idsProcessor = idsProcessor;
        this.dimensionalArrayFiles = dimensionalArrayFiles;
        this.stores = stores;
        this.items = items;
        this.game = game;
        this.tlk = tlk;
        random = new Random();
    }

    public Area Area { get; set; }
    public CreFile Creature { get; set; }
    public List<(string name, int value)> GlobalState = [];
    public GamFile Game = new();
    public List<DimensionalArrayFile> dimensionalArrayFiles = [];
    public int selectedRandom = -1;

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
        if (area.Equals("GLOBAL", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.GlobalState.SingleOrDefault(w => w.name == name).value == value;
        }
        if (area.Equals("AREA", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.Area.Variables.Count(w => w.variable == name && w.value == value) == 1;
        }
        if (area.Equals("LOCALS", StringComparison.CurrentCultureIgnoreCase))
        {
            //
        }
        return false;
    }

    public bool HP(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.CurrentHP == hitPoints;
    }

    public bool HPGT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.CurrentHP > hitPoints;
    }

    public bool HPLT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.CurrentHP < hitPoints;
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
        return creature?.CurrentHP / creature?.MaximumHP == hitPoints;
    }

    public bool HPPercentLT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.CurrentHP / creature?.MaximumHP < hitPoints;
    }

    public bool HPPercentGT(string obj, int hitPoints)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.CurrentHP / creature?.MaximumHP > hitPoints;
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
        var spellString = Convert.ToString(spell);
        var type = spellString.First();
        var level = spellString.Skip(1).Take(1).First();
        var spellId = spellString.Substring(spellString.Length - 3, 3);

        return type switch
        {
            // cleric
            '1' => level switch
            {
                '1' => this.Creature.MemorisedSpells.PriestLevel1.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '2' => this.Creature.MemorisedSpells.PriestLevel2.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '3' => this.Creature.MemorisedSpells.PriestLevel3.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '4' => this.Creature.MemorisedSpells.PriestLevel4.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '5' => this.Creature.MemorisedSpells.PriestLevel5.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '6' => this.Creature.MemorisedSpells.PriestLevel6.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '7' => this.Creature.MemorisedSpells.PriestLevel7.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                _ => false,
            },
            // mage
            '2' => level switch
            {
                '1' => this.Creature.MemorisedSpells.MageLevel1.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '2' => this.Creature.MemorisedSpells.MageLevel2.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '3' => this.Creature.MemorisedSpells.MageLevel3.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '4' => this.Creature.MemorisedSpells.MageLevel4.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '5' => this.Creature.MemorisedSpells.MageLevel5.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '6' => this.Creature.MemorisedSpells.MageLevel6.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '7' => this.Creature.MemorisedSpells.MageLevel7.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '8' => this.Creature.MemorisedSpells.MageLevel7.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '9' => this.Creature.MemorisedSpells.MageLevel7.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                _ => false,
            },
            // innate
            '3' => level switch
            {
                '1' => this.Creature.MemorisedSpells.Innate.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                _ => false,
            },
            _ => false,
        };
    }

    public bool HaveSpellRES(string spell)
    {
        return
          this.Creature.MemorisedSpells.PriestLevel1.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.PriestLevel2.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.PriestLevel3.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.PriestLevel4.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.PriestLevel5.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.PriestLevel6.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.PriestLevel7.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel1.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel2.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel3.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel4.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel5.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel6.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel7.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel8.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.MageLevel9.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.MemorisedSpells.Innate.Where(w => w.IsMemorised).Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper());
    }

    public bool HaveAnySpells()
    {
        return
            this.Creature.MemorisedSpells.PriestLevel1.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.PriestLevel2.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.PriestLevel3.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.PriestLevel4.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.PriestLevel5.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.PriestLevel6.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.PriestLevel7.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel1.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel2.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel3.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel4.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel5.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel6.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel7.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel8.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.MageLevel9.Where(w => w.IsMemorised).Any() ||
            this.Creature.MemorisedSpells.Innate.Where(w => w.IsMemorised).Any();
    }

    public bool BecameVisible()
    {
        return false;
    }

    public bool GlobalGT(string name, string area, int value)
    {
        if (area.Equals("GLOBAL", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.GlobalState.SingleOrDefault(w => w.name == name).value > value;
        }
        if (area.Equals("AREA", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.Area.Variables.Count(w => w.variable == name && w.value > value) == 1;
        }
        if (area.Equals("LOCALS", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.Creature.Effects2.Where(w => w.Opcode == 187 && w.Variable.ToString().ToUpper().Trim('\0') == name.ToUpper()).Select(s => s.Parameter1 > value).FirstOrDefault();
        }
        return false;
    }

    public bool GlobalLT(string name, string area, int value)
    {
        if (area.Equals("GLOBAL", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.GlobalState.SingleOrDefault(w => w.name == name).value < value;
        }
        if (area.Equals("AREA", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.Area.Variables.Count(w => w.variable == name && w.value < value) == 1;
        }
        if (area.Equals("LOCALS", StringComparison.CurrentCultureIgnoreCase))
        {
            return this.Creature.Effects2.Where(w => w.Opcode == 187 && w.Variable.ToString().ToUpper().Trim('\0') == name.ToUpper()).Select(s => s.Parameter1 < value).FirstOrDefault();
        }
        return false;
    }

    public bool OnCreation()
    {
        return false;
    }

    public bool StateCheck(string obj, int state)
    {
        var creature = objectLocator.GetObject(obj);
        if (creature == null)
            return false;

        var flagsInt = StatusFlagsToInt(creature.StatusFlags);
        return (flagsInt & state) != 0;
    }

    private static int StatusFlagsToInt(StatusFlags flags)
    {
        var value = 0;
        if (flags.Sleeping) value |= 0x00000001;
        if (flags.Berserk) value |= 0x00000002;
        if (flags.Panic) value |= 0x00000004;
        if (flags.Stunned) value |= 0x00000008;
        if (flags.Invisible) value |= 0x00000010;
        if (flags.Helpless) value |= 0x00000020;
        if (flags.FrozenDeath) value |= 0x00000040;
        if (flags.StoneDeath) value |= 0x00000080;
        if (flags.ExplodingDeath) value |= 0x00000100;
        if (flags.FlameDeath) value |= 0x00000200;
        if (flags.AcidDeath) value |= 0x00000400;
        if (flags.Dead) value |= 0x00000800;
        if (flags.Silenced) value |= 0x00001000;
        if (flags.Charmed) value |= 0x00002000;
        if (flags.Poisoned) value |= 0x00004000;
        if (flags.Hasted) value |= 0x00008000;
        if (flags.Slowed) value |= 0x00010000;
        if (flags.Infravision) value |= 0x00020000;
        if (flags.Blind) value |= 0x00040000;
        if (flags.Diseased) value |= 0x00080000;
        if (flags.Feebleminded) value |= 0x00100000;
        if (flags.Nondetection) value |= 0x00200000;
        if (flags.ImprovedInvisibility) value |= 0x00400000;
        if (flags.Bless) value |= 0x00800000;
        if (flags.Chant) value |= 0x01000000;
        if (flags.DrawUponHolyMight) value |= 0x02000000;
        if (flags.Luck) value |= 0x04000000;
        if (flags.Aid) value |= 0x08000000;
        if (flags.ChantBad) value |= 0x10000000;
        if (flags.Blur) value |= 0x20000000;
        if (flags.MirrorImage) value |= 0x40000000;
        if (flags.Confused) value |= unchecked((int)0x80000000);
        return value;
    }

    public bool NotStateCheck(string obj, int state)
    {
        var creature = objectLocator.GetObject(obj);
        if (creature == null)
            return true;

        var flagsInt = StatusFlagsToInt(creature.StatusFlags);
        return (flagsInt & state) == 0;
    }

    public bool NumTimesTalkedTo(int num)
    {
        //TODO: This is stored in the CRE field in the ARE file
        return true;
    }

    public bool NumTimesTalkedToGT(int num)
    {
        //TODO: This is stored in the CRE field in the ARE file
        return false;
    }

    public bool NumTimesTalkedToLT(int num)
    {
        //TODO: This is stored in the CRE field in the ARE file
        return false;
    }

    public bool Reaction(string obj, int value)
    {
        var creature = objectLocator.GetObject(obj);
        if (creature == null)
            return false;

        //TODO: Reaction = 10 + rmodchr + rmodrep (see rmodchr.2da and rmodrep.2da) - we need to get the party member's CHA and reputation
        return false;
    }

    public bool ReactionGT(string obj, int value)
    {
        var creature = objectLocator.GetObject(obj);
        if (creature == null)
            return false;

        //TODO: Reaction = 10 + rmodchr + rmodrep (see rmodchr.2da and rmodrep.2da) - we need to get the party member's CHA and reputation

        return false;
    }

    public bool ReactionLT(string obj, int value)
    {
        var creature = objectLocator.GetObject(obj);
        if (creature == null)
            return false;

        //TODO: Reaction = 10 + rmodchr + rmodrep (see rmodchr.2da and rmodrep.2da) - we need to get the party member's CHA and reputation

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
        if (string.IsNullOrEmpty(item))
            return false;

        var targetItem = item.Trim('\0').ToUpperInvariant();

        foreach (var partyMember in objectLocator.Party)
        {
            var cre = partyMember.CreFile;
            var slots = new CreItem2[]
            {
                cre?.Items?.Helmet,
                cre?.Items?.Armor,
                cre?.Items?.Shield,
                cre?.Items?.Gloves,
                cre?.Items?.RingLeft,
                cre?.Items?.RingRight,
                cre?.Items?.Amulet,
                cre?.Items?.Belt,
                cre?.Items?.Boots,
                cre?.Items?.Weapon1,
                cre?.Items?.Weapon2,
                cre?.Items?.Weapon3,
                cre?.Items?.Weapon4,
                cre?.Items?.Quiver1,
                cre?.Items?.Quiver2,
                cre?.Items?.Quiver3,
                cre?.Items?.Quiver4,
                cre?.Items?.Cloak,
                cre?.Items?.QuickItem1,
                cre?.Items?.QuickItem2,
                cre?.Items?.QuickItem3,
                cre?.Items?.InventoryItem1,
                cre?.Items?.InventoryItem2,
                cre?.Items?.InventoryItem3,
                cre?.Items?.InventoryItem4,
                cre?.Items?.InventoryItem5,
                cre?.Items?.InventoryItem6,
                cre?.Items?.InventoryItem7,
                cre?.Items?.InventoryItem8,
                cre?.Items?.InventoryItem9,
                cre?.Items?.InventoryItem10,
                cre?.Items?.InventoryItem11,
                cre?.Items?.InventoryItem12,
                cre?.Items?.InventoryItem13,
                cre?.Items?.InventoryItem14,
                cre?.Items?.InventoryItem15,
                cre?.Items?.InventoryItem16,
                cre?.Items?.MagicWeapon
            };

            foreach (var slot in slots)
            {
                var slotItem = slot?.Filename.ToString().ToUpper().Trim('\0');
                if (string.IsNullOrEmpty(slotItem))
                    continue;

                if (slotItem == targetItem)
                    return true;

                var store = stores.Where(w => w.Filename.ToString().ToUpper().Trim('\0').TrimEnd(".STO") == slotItem).FirstOrDefault();
                if (store != null)
                {
                    return store.ItemsSoldByStore.Where(w => w.Filename.ToString().ToUpper().Trim('\0') == targetItem).Any();
                }
            }
        }

        return false;
    }

    public bool InParty(string obj)
    {
        var creature = objectLocator.Party.Select(s => s.CreFile.DeathVariable.ToString().ToUpper().Trim('\0')).FirstOrDefault();
        return creature != null;
    }

    public bool CheckStat(string obj, int value, int statNum)
    {
        return false;
    }

    public bool CheckStatGT(string obj, int value, int statNum)
    {
        var creature = objectLocator.GetObject(obj);
        switch (statNum)
        {
            case 0:
                return creature.CurrentHP > value;
            case 1:
                return creature.MaximumHP > value;
            case 2:
                return creature.ArmorClassEffective > value;
            case 3:
                return creature.CrushingModifuer > value;
            case 4:
                return creature.MissileModifier > value;
            case 5:
                return creature.PiercingModifier > value;
            case 6:
                return creature.SlashingModifier > value;
            case 7:
                return creature.Thac0 > value;
            case 8:
                // TODO: number of attacks - calculate
                return false;
            case 9:
                return creature.SaveVsDeath > value;
            case 10:
                return creature.SaveVsWands > value;
            case 11:
                return creature.SaveVsPolymorph > value;
            case 12:
                return creature.SaveVsBreath > value;
            case 13:
                return creature.SaveVsSpells > value;
            case 14:
                return creature.FireResistance > value;
            case 15:
                return creature.ColdResistance > value;
            case 16:
                return creature.ElectricityResistance > value;
            case 17:
                return creature.AcidResistance > value;
            case 18:
                return creature.MagicResistance > value;
            case 19:
                return creature.MagicFireResistance > value;
            case 20:
                return creature.MagicColdResistance > value;
            case 21:
                return creature.SlashingResistance > value;
            case 22:
                return creature.CrushingResistance > value;
            case 23:
                return creature.PiercingResistance > value;
            case 24:
                return creature.MissileResistance > value;
            case 25:
                return creature.Lore > value;
            case 26:
                return creature.LockPicking > value;
            case 27:
                return creature.Stealth > value;
            case 28:
                return creature.FindTraps > value;
            case 29:
                return creature.PickPockets > value;
            case 30:
                return creature.Fatigue > value;
            case 31:
                return creature.Intoxication > value;
            case 32:
                return creature.Luck > value;
            case 33:
                return creature.Tracking > value;
            case 34:
                return creature.Level1 > value;
            case 35:
                return creature.Sex > value;
            case 36:
                return creature.Strength > value;
            case 37:
                return creature.StrengthBonus > value;
            case 38:
                return creature.Intelligence > value;
            case 39:
                return creature.Wisdom > value;
            case 40:
                return creature.Dexterity > value;
            case 41:
                return creature.Constitution > value;
            case 42:
                return creature.Charisma > value;
            case 43:
                return creature.XPReward > value; //TODO: Probably not the same as #44
            case 44:
                return creature.XPReward > value; //TODO: Probably not the same as #43
            case 45:
                return creature.Gold > value;
            case 46:
                return creature.MoraleBreak > value;
            case 47:
                return creature.MoraleRecoveryTime > value;
            case 48:
                return creature.Reputation > value;
            case 49:
                return creature.RacialEnemy > value;
            //case 50:
            //	return DamageBonus > value; //TODO: calculate?
            case 51:
                //TODO: what if there are multiple spell failure effects
                //TODO: calculate - better way of checking effects1 and effects2
                var mageSpellFailure = creature.Effects1.Where(w => w.Opcode == 60 && (w.Parameter2 == 0 || w.Parameter2 == 3)).Select(s => s.Parameter1).FirstOrDefault();
                mageSpellFailure = creature.Effects2.Where(w => w.Opcode == 60 && (w.Parameter2 == 0 || w.Parameter2 == 3)).Select(s => s.Parameter1).FirstOrDefault();
                return mageSpellFailure > value;
            case 52:
                //TODO: what if there are multiple spell failure effects
                //TODO: calculate - better way of checking effects1 and effects2
                var clericSpellFailure = creature.Effects1.Where(w => w.Opcode == 60 && (w.Parameter2 == 1 || w.Parameter2 == 4)).Select(s => s.Parameter1).FirstOrDefault();
                clericSpellFailure = creature.Effects2.Where(w => w.Opcode == 60 && (w.Parameter2 == 1 || w.Parameter2 == 4)).Select(s => s.Parameter1).FirstOrDefault();
                return clericSpellFailure > value;
            //case 53:
            //	return SpellDurationModifierMage > value; //TODO: calculate
            //case 54:
            //	return SpellDurationModifierPriest > value; //TODO: calculate
            case 55:
                return creature.TurnUndead > value;
            //case 56:
            //	return BackstabMultiplier > value; //TODO: calculate
            //case 57:
            //	return LayOnHandsAmount > value; //TODO: calculate - look up creature's level in layonhands.2da

            //TODO: Expand this list

            case 148:
                var exploreV1 = creature.Effects1.Where(w => w.Opcode == 268).Select(s => s.Parameter1).FirstOrDefault();
                var exploreV2 = creature.Effects2.Where(w => w.Opcode == 268).Select(s => s.Parameter1).FirstOrDefault();
                return exploreV1 != 0 || exploreV2 != 0;

            case 187:
                var immuneToTurnUndeadV1 = creature.Effects1.Where(w => w.Opcode == 297 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                var immuneToTurnUndeadV2 = creature.Effects2.Where(w => w.Opcode == 297 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                return immuneToTurnUndeadV1 != 0 || immuneToTurnUndeadV2 != 0;

            case 191:
                var useAnyItemV1 = creature.Effects1.Where(w => w.Opcode == 302 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                var useAnyItemV2 = creature.Effects2.Where(w => w.Opcode == 302 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                return useAnyItemV1 != 0 || useAnyItemV2 != 0;

            case 201:
                //TODO: calculate - better way of checking effects1 and effects2
                var doNotDraw = creature.Effects1.Where(w => w.Opcode == 315 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                doNotDraw = creature.Effects2.Where(w => w.Opcode == 315 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                return doNotDraw > 0;
            case 202:
                //TODO: calculate - better way of checking effects1 and effects2
                var ignoreDrainDeath = creature.Effects1.Where(w => w.Opcode == 367 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                ignoreDrainDeath = creature.Effects2.Where(w => w.Opcode == 367 && w.Parameter2 != 0).Select(s => s.Parameter1).FirstOrDefault();
                return ignoreDrainDeath > 0;
        }
        return false;
    }

    public bool CheckStatLT(string obj, int value, int statNum)
    {
        return false;
    }

    public bool RandomNum(int range, int value)
    {
        if (selectedRandom == -1)
        {
            selectedRandom = random.Next(1, range);
        }
        return selectedRandom == value;
    }

    public bool RandomNumGT(int range, int value)
    {
        if (selectedRandom == -1)
        {
            selectedRandom = random.Next(1, range);
        }
        return selectedRandom > value;
    }

    public bool RandomNumLT(int range, int value)
    {
        if (selectedRandom == -1)
        {
            selectedRandom = random.Next(1, range);
        }
        return selectedRandom < value;
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
        return Game.Gold == amount;
    }

    public bool PartyGoldGT(int amount)
    {
        return Game.Gold > amount;
    }

    public bool PartyGoldLT(int amount)
    {
        return Game.Gold < amount;
    }

    public bool Dead(string name)
    {
        return Game.Variables.Where(w => w.Name.ToString().ToUpper().Trim('\0') == $"SPRITE_IS_DEAD{name}".ToUpper()).Any();
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
        var slot = 35 + this.Creature.Items.SelectedWeapon;
        switch (slot)
        {
            case 11:
                return this.Creature.Items.Quiver1?.Charges1 == 0 || this.Creature.Items.Quiver1 == null;
            case 12:
                return this.Creature.Items.Quiver2?.Charges1 == 0 || this.Creature.Items.Quiver2 == null;
            case 13:
                return this.Creature.Items.Quiver3?.Charges1 == 0 || this.Creature.Items.Quiver3 == null;
            case 14:
                return this.Creature.Items.Quiver4?.Charges1 == 0 || this.Creature.Items.Quiver4 == null;

            case 34:
                return false;
            case 35:
                return false;
            case 36:
                return false;
            case 37:
                return false;
            case 38:
                return false;
        }

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
        //TODO: Check for bag of holding etc.
        var creature = objectLocator.GetObject(obj);
        return
            creature.Items.Helmet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Armor?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Shield?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Gloves?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.RingLeft?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.RingRight?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Amulet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Belt?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Boots?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Cloak?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.QuickItem1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.QuickItem2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.QuickItem3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem5?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem6?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem7?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem8?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem9?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem10?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem11?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem12?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem13?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem14?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem15?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.InventoryItem16?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.MagicWeapon?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper();
    }

    public bool HasItemType(string obj, int type, int ignoreDestructible)
    {
        return true;
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
        var creature = objectLocator.GetObject(obj);
        return
            creature.Items.Weapon1?.Filename != null ||
            creature.Items.Weapon2?.Filename != null ||
            creature.Items.Weapon3?.Filename != null ||
            creature.Items.Weapon4?.Filename != null;
    }

    public bool Happiness(string obj, int amount)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.SingleOrDefault(s => s.CreFile.DeathVariable.ToString().Trim('\0') == creature.DeathVariable.ToString().ToUpper().Trim('\0'))?.Happiness == amount;
    }

    public bool HappinessGT(string obj, int amount)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.SingleOrDefault(s => s.CreFile.DeathVariable.ToString().Trim('\0') == creature.DeathVariable.ToString().ToUpper().Trim('\0'))?.Happiness > amount;
    }

    public bool HappinessLT(string obj, int amount)
    {
        var creature = objectLocator.GetObject(obj);
        return objectLocator.Party.SingleOrDefault(s => s.CreFile.DeathVariable.ToString().Trim('\0') == creature.DeathVariable.ToString().ToUpper().Trim('\0'))?.Happiness < amount;
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
        return objectLocator.Party.Count() == num;
    }

    public bool NumInPartyGT(int num)
    {
        return objectLocator.Party.Count() > num;
    }

    public bool NumInPartyLT(int num)
    {
        return objectLocator.Party.Count() < num;
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
        var count = this.GlobalState.Where(w => $"SPRITE_IS_DEAD{w.name.ToString().ToUpper().Trim('\0')}" == name.ToUpper()).FirstOrDefault().value;
        return count == num;
    }

    public bool NumDeadGT(string name, int num)
    {
        var count = this.GlobalState.Where(w => $"SPRITE_IS_DEAD{w.name.ToString().ToUpper().Trim('\0')}" == name.ToUpper()).FirstOrDefault().value;
        return count > num;
    }

    public bool NumDeadLT(string name, int num)
    {
        var count = this.GlobalState.Where(w => $"SPRITE_IS_DEAD{w.name.ToString().ToUpper().Trim('\0')}" == name.ToUpper()).FirstOrDefault().value;
        return count < num;
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

    private int GetItemCount(CreFile creature, string resRef)
    {
        var count = 0;
        if (creature?.Items.Amulet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Armor?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Belt?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Boots?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Cloak?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Gloves?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Helmet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Helmet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem5?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem6?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem7?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem8?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem9?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem10?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem11?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem12?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem13?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem14?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem15?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.InventoryItem16?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.MagicWeapon?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.QuickItem1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.QuickItem2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.QuickItem3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Quiver1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Quiver2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Quiver3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Quiver4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.RingLeft?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.RingRight?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Weapon1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Weapon2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Weapon3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        if (creature?.Items.Weapon4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper())
            count++;

        return count;
    }

    public bool NumItems(string resRef, string obj, int num)
    {
        if (string.IsNullOrEmpty(resRef))
            return false;

        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var count = GetItemCount(creature, resRef);

        return count == num;
    }

    public bool NumItemsGT(string resRef, string obj, int num)
    {
        if (string.IsNullOrEmpty(resRef))
            return false;

        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var count = GetItemCount(creature, resRef);

        return count > num;
    }

    public bool NumItemsLT(string resRef, string obj, int num)
    {
        if (string.IsNullOrEmpty(resRef))
            return false;

        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var count = GetItemCount(creature, resRef);

        return count < num;
    }

    public bool NumItemsParty(string resRef, int num)
    {
        var count = 0;
        var partyMembers = objectLocator.Party.Where(w => w.CreFile != null).Select(s => s.CreFile);
        foreach (var partyMember in partyMembers)
        {
            count += GetItemCount(partyMember, resRef);
        }

        return num == count;
    }

    public bool NumItemsPartyGT(string resRef, int num)
    {
        var count = 0;
        var partyMembers = objectLocator.Party.Where(w => w.CreFile != null).Select(s => s.CreFile);
        foreach (var partyMember in partyMembers)
        {
            count += GetItemCount(partyMember, resRef);
        }

        return num > count;
    }

    public bool NumItemsPartyLT(string resRef, int num)
    {
        var count = 0;
        var partyMembers = objectLocator.Party.Where(w => w.CreFile != null).Select(s => s.CreFile);
        foreach (var partyMember in partyMembers)
        {
            count += GetItemCount(partyMember, resRef);
        }

        return num < count;
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
        var creature = objectLocator.GetObject(obj);
        return
            creature.Items.Helmet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Armor?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Shield?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Gloves?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.RingLeft?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.RingRight?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Amulet?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Belt?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Boots?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Weapon4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Quiver4?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.Cloak?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.QuickItem1?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.QuickItem2?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper() ||
            creature.Items.QuickItem3?.Filename.ToString().ToUpper().Trim('\0') == resRef.ToUpper();
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

    public bool CalanderDay(int day)
    {
        //var years2da = dimensionalArrayFiles.Where(w => w.Filename.ToUpper() == "YEARS.2DA").Single();
        //var lines = years2da.Contents.Split("\r\n");
        //var startTime = Convert.ToInt32(lines.Where(w => w.StartsWith("STARTTIME")).Single().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last()) / 7200;
        //var startYear = Convert.ToInt32(lines.Where(w => w.StartsWith("STARTYEAR")).Single().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());

        //var months2da = dimensionalArrayFiles.Where(w => w.Filename.ToUpper() == "MONTHS.2DA").Single();
        //lines = months2da.Contents.Split("\r\n").Skip(3).ToArray();


        //var months = new List<(string, int)>();
        //foreach (var line in lines)
        //{
        //	var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        //	if (parts.Length > 0)
        //	{
        //		months.Add((tlk.Strings[Convert.ToInt32(parts[2])].Text, Convert.ToInt32(parts[1])));
        //	}
        //}

        var currentDays = game.GameTime / 7200;
        return day == currentDays;
    }

    public bool CalandarDayGT(int day)
    {
        var currentDays = game.GameTime / 7200;
        return day > currentDays;
    }

    public bool CalandarDayLT(int day)
    {
        var currentDays = game.GameTime / 7200;
        return day < currentDays;
    }

    public bool Name(string name, string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.DeathVariable.ToString().Trim('\0').ToUpper() == name.ToUpper();
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
        return IfValidForPartyDialog(obj);
    }

    public bool IsValidForPartyDialogue(string obj)
    {
        return IfValidForPartyDialog(obj);
    }

    public bool IfValidForPartyDialogue(string obj)
    {
        return IfValidForPartyDialog(obj);
    }

    public bool IfValidForPartyDialog(string obj)
    {
        var creature = this.objectLocator.Party.Where(w => w.CreFile.DeathVariable.ToString().Trim('\0').ToUpper() == obj).SingleOrDefault();
        return creature?.Selection != 0x8000;
    }

    public bool PartyHasItemIdentified(string resRef)
    {
        if (string.IsNullOrEmpty(resRef))
            return false;

        var targetItem = resRef.Trim('\0').ToUpperInvariant();

        foreach (var partyMember in objectLocator.Party)
        {
            var cre = partyMember.CreFile;
            var slots = new CreItem2[]
            {
                cre?.Items?.Helmet,
                cre?.Items?.Armor,
                cre?.Items?.Shield,
                cre?.Items?.Gloves,
                cre?.Items?.RingLeft,
                cre?.Items?.RingRight,
                cre?.Items?.Amulet,
                cre?.Items?.Belt,
                cre?.Items?.Boots,
                cre?.Items?.Weapon1,
                cre?.Items?.Weapon2,
                cre?.Items?.Weapon3,
                cre?.Items?.Weapon4,
                cre?.Items?.Quiver1,
                cre?.Items?.Quiver2,
                cre?.Items?.Quiver3,
                cre?.Items?.Quiver4,
                cre?.Items?.Cloak,
                cre?.Items?.QuickItem1,
                cre?.Items?.QuickItem2,
                cre?.Items?.QuickItem3,
                cre?.Items?.InventoryItem1,
                cre?.Items?.InventoryItem2,
                cre?.Items?.InventoryItem3,
                cre?.Items?.InventoryItem4,
                cre?.Items?.InventoryItem5,
                cre?.Items?.InventoryItem6,
                cre?.Items?.InventoryItem7,
                cre?.Items?.InventoryItem8,
                cre?.Items?.InventoryItem9,
                cre?.Items?.InventoryItem10,
                cre?.Items?.InventoryItem11,
                cre?.Items?.InventoryItem12,
                cre?.Items?.InventoryItem13,
                cre?.Items?.InventoryItem14,
                cre?.Items?.InventoryItem15,
                cre?.Items?.InventoryItem16,
                cre?.Items?.MagicWeapon
            };

            foreach (var slot in slots)
            {
                var slotItem = slot?.Filename.ToString().ToUpper().Trim('\0');
                if (string.IsNullOrEmpty(slotItem))
                    continue;

                if (slotItem == targetItem && slot.Flags.IsIdentified)
                    return true;

                var store = stores.Where(w => w.Filename.ToString().ToUpper().Trim('\0').TrimEnd(".STO") == slotItem).FirstOrDefault();
                if (store != null)
                {
                    return store.ItemsSoldByStore.Where(w => w.Filename.ToString().ToUpper().Trim('\0') == targetItem && w.Flags.Identified).Any();
                }
            }
        }

        return false;
    }

    public bool HasBounceEffects(string obj)
    {
        var creature = objectLocator.GetObject(obj);

        return (creature?.Effects1.Any(a => a.Opcode == 197) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 198) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 199) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 200) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 202) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 203) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 207) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 227) ?? false) ||
               (creature?.Effects1.Any(a => a.Opcode == 228) ?? false) ||

               (creature?.Effects2.Any(a => a.Opcode == 197) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 198) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 199) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 200) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 202) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 203) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 207) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 227) ?? false) ||
               (creature?.Effects2.Any(a => a.Opcode == 228) ?? false);
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
        return objectLocator.Party.Count(c => !c.CreFile.StatusFlags.Dead) == num;
    }

    public bool NumInPartyAliveGT(int num)
    {
        return objectLocator.Party.Count(c => !c.CreFile.StatusFlags.Dead) > num;
    }

    public bool NumInPartyAliveLT(int num)
    {
        return objectLocator.Party.Count(c => !c.CreFile.StatusFlags.Dead) < num;
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
        return creature?.Flags.FallenRanger ?? false;
    }

    public bool FallenPaladin(string obj)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.Flags.FallenPaladin ?? false;
    }

    public bool InventoryFull(string obj)
    {
        var creature = objectLocator.GetObject(obj);

        return creature?.Items.InventoryItem1.Filename != null &&
               creature?.Items.InventoryItem2.Filename != null &&
               creature?.Items.InventoryItem3.Filename != null &&
               creature?.Items.InventoryItem4.Filename != null &&
               creature?.Items.InventoryItem5.Filename != null &&
               creature?.Items.InventoryItem6.Filename != null &&
               creature?.Items.InventoryItem7.Filename != null &&
               creature?.Items.InventoryItem8.Filename != null &&
               creature?.Items.InventoryItem9.Filename != null &&
               creature?.Items.InventoryItem10.Filename != null &&
               creature?.Items.InventoryItem11.Filename != null &&
               creature?.Items.InventoryItem12.Filename != null &&
               creature?.Items.InventoryItem13.Filename != null &&
               creature?.Items.InventoryItem14.Filename != null &&
               creature?.Items.InventoryItem15.Filename != null &&
               creature?.Items.InventoryItem16.Filename != null;
    }

    public bool HasItemEquippedReal(string resRef, string obj)
    {
        return false;
    }

    public bool XP(string obj, int xp)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.XPReward == xp;
    }

    public bool XPGT(string obj, int xp)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.XPReward > xp;
    }

    public bool XPLT(string obj, int xp)
    {
        var creature = objectLocator.GetObject(obj);
        return creature?.XPReward < xp;
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
        return false;
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

    public bool Difficulty(int amount)
    {
        return false;
    }

    public bool DifficultyGT(int amount)
    {
        return false;
    }

    public bool DifficultyLT(int amount)
    {
        return false;
    }

    public bool InPartyAllowDead(string obj)
    {
        return false;
    }

    public bool AreaCheckObject(string resref, string obj)
    {
        return false;
    }

    public bool ActuallyInCombat()
    {
        return false;
    }

    public bool WalkedToTrigger(string obj)
    {
        return false;
    }

    public bool LevelParty(int num)
    {
        return false;
    }

    public bool LevelPartyGT(int num)
    {
        return false;
    }

    public bool LevelPartyLT(int num)
    {
        return false;
    }

    public bool HaveSpellParty(int spell)
    {
        return false;
    }

    public bool AmIInWatchersKeepPleaseIgnoreTheLackOfApostophe()
    {
        return false;
    }

    public bool InWatchersKeep()
    {
        return false;
    }

    public bool AreaCheckAllegiance(int allegience)
    {
        return false;
    }

    public bool IsTouchGUI()
    {
        return false;
    }

    public bool HasDLC(string dlcName)
    {
        return false;
    }

    public bool BeenInParty(string name)
    {
        return false;
    }

    public bool NextTriggerObject(string obj)
    {
        return false;
    }

    public bool ExtendedStateCheck(string obj, int state)
    {
        return false;
    }

    public bool CheckSpellState(string obj, int state)
    {
        return false;
    }

    public bool NearLocation(string obj, int pointX, int pointY, int range)
    {
        return false;
    }

    public bool NearSavedLocation(string obj, string global, int range)
    {
        return false;
    }

    public bool Switch(string global, string area)
    {
        return false;
    }

    public bool IsWeaponRanged(string obj)
    {
        return false;
    }

    public bool ButtonDisabled(int button)
    {
        return
            this.Creature.Effects1.Where(w => w.Opcode == 144 && w.Parameter2 == button).Any() ||
            this.Creature.Effects2.Where(w => w.Opcode == 144 && w.Parameter2 == button).Any();
    }

    public bool HasItemCategory(string obj, int itemtype, bool equipped)
    {
        return false;
    }

    public bool NightmareModeOn()
    {
        return false;
    }

    public bool OriginalClass(string obj, int @class)
    {
        return false;
    }

    public bool CutSceneBroken()
    {
        return false;
    }

    public bool WeaponEffectiveVs(string obj, int hand)
    {
        return false;
    }

    public bool INI(string name, int number)
    {
        return false;
    }
    public bool ModalStateObject(string obj, int modalState)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var gamCreature = Game.PartyMembers.SingleOrDefault(s => s.CreFile.DeathVariable.ToString().Trim('\0') == creature.DeathVariable.ToString().Trim('\0'));
        if (gamCreature == null)
        {
            gamCreature = Game.NonPartyMembers.SingleOrDefault(s => s.CreFile.DeathVariable.ToString().Trim('\0') == creature.DeathVariable.ToString().Trim('\0'));
        }

        return gamCreature != null && gamCreature.ModalAction == modalState;
    }

    public bool WeaponCanDamage(string obj, int hand)
    {
        return false;
    }

    public bool NumKilledByParty(int number)
    {
        return this.GlobalState.Where(w => w.name.StartsWith("SPRITE_IS_DEAD")).Sum(c => c.value) == number;
    }

    public bool NumKilledByPartyGT(int number)
    {
        return this.GlobalState.Where(w => w.name.StartsWith("SPRITE_IS_DEAD")).Sum(c => c.value) > number;
    }

    public bool NumKilledByPartyLT(int number)
    {
        return this.GlobalState.Where(w => w.name.StartsWith("SPRITE_IS_DEAD")).Sum(c => c.value) < number;
    }

    public bool CanTurn(string obj, int difference)
    {
        return false;
    }

    public bool BitCheck(string name, string area, int bits)
    {
        // Apparently the engine has a bug for this trigger and always returns false in dialog checks
        return false;
    }

    public bool CanEquipRanged()
    {
        return false;
    }

    public bool ImmuneToSpellLevel(string obj, int level)
    {
        return false;
    }

    public bool StoryModeOn()
    {
        return false;
    }

    public bool IsForcedRandomEncounterActive(string area)
    {
        return false;
    }

    public bool ClassLevel(string obj, int category, int value)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        return category switch
        {
            // mage
            1 => (creature.Class == 1 && creature.Level1 == value) ||  // mage
                 (creature.Class == 7 && creature.Level2 == value) ||  // fighter_mage
                 (creature.Class == 10 && creature.Level2 == value) || // fighter_mage_thief
                 (creature.Class == 13 && creature.Level1 == value) || // mage_thief
                 (creature.Class == 14 && creature.Level2 == value) || // cleric_mage
                 (creature.Class == 17 && creature.Level2 == value),   // fighter_mage_cleric

            // warrior
            2 => (creature.Class == 2 && creature.Level1 == value) ||  // fighter
                 (creature.Class == 7 && creature.Level1 == value) ||  // fighter_mage
                 (creature.Class == 8 && creature.Level1 == value) ||  // fighter_cleric
                 (creature.Class == 9 && creature.Level1 == value) ||  // fighter_thief
                 (creature.Class == 10 && creature.Level1 == value) || // fighter_mage_thief
                 (creature.Class == 16 && creature.Level1 == value) || // fighter_druid
                 (creature.Class == 17 && creature.Level1 == value) || // fighter_mage_cleric
                 (creature.Class == 20 && creature.Level1 == value),   // monk

            // priest
            3 => (creature.Class == 3 && creature.Level1 == value) ||  // cleric
                 (creature.Class == 8 && creature.Level2 == value) ||  // fighter_cleric
                 (creature.Class == 14 && creature.Level1 == value) || // cleric_mage
                 (creature.Class == 15 && creature.Level1 == value) || // cleric_thief
                 (creature.Class == 17 && creature.Level3 == value) || // fighter_mage_cleric
                 (creature.Class == 18 && creature.Level1 == value),   // cleric_ranger

            // rogue
            4 => (creature.Class == 4 && creature.Level1 == value) ||  // thief
                 (creature.Class == 9 && creature.Level2 == value) ||  // fighter_thief
                 (creature.Class == 10 && creature.Level3 == value) || // fighter_mage_thief
                 (creature.Class == 13 && creature.Level2 == value) || // mage_thief
                 (creature.Class == 15 && creature.Level3 == value),   // cleric_thief
            _ => false,
        };
    }
    public bool ClassLevelGT(string obj, int category, int value)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        return category switch
        {
            // mage
            1 => (creature.Class == 1 && creature.Level1 > value) ||  // mage
                 (creature.Class == 7 && creature.Level2 > value) ||  // fighter_mage
                 (creature.Class == 10 && creature.Level2 > value) || // fighter_mage_thief
                 (creature.Class == 13 && creature.Level1 > value) || // mage_thief
                 (creature.Class == 14 && creature.Level2 > value) || // cleric_mage
                 (creature.Class == 17 && creature.Level2 > value),   // fighter_mage_cleric

            // warrior                                                                   
            2 => (creature.Class == 2 && creature.Level1 > value) ||  // fighter
                 (creature.Class == 7 && creature.Level1 > value) ||  // fighter_mage
                 (creature.Class == 8 && creature.Level1 > value) ||  // fighter_cleric
                 (creature.Class == 9 && creature.Level1 > value) ||  // fighter_thief
                 (creature.Class == 10 && creature.Level1 > value) || // fighter_mage_thief
                 (creature.Class == 16 && creature.Level1 > value) || // fighter_druid
                 (creature.Class == 17 && creature.Level1 > value) || // fighter_mage_cleric
                 (creature.Class == 20 && creature.Level1 > value),   // monk

            // priest
            3 => (creature.Class == 3 && creature.Level1 > value) ||  // cleric
                 (creature.Class == 8 && creature.Level2 > value) ||  // fighter_cleric
                 (creature.Class == 14 && creature.Level1 > value) || // cleric_mage
                 (creature.Class == 15 && creature.Level1 > value) || // cleric_thief
                 (creature.Class == 17 && creature.Level3 > value) || // fighter_mage_cleric
                 (creature.Class == 18 && creature.Level1 > value),   // cleric_ranger

            // rogue
            4 => (creature.Class == 4 && creature.Level1 > value) ||  // thief
                 (creature.Class == 9 && creature.Level2 > value) ||  // fighter_thief
                 (creature.Class == 10 && creature.Level3 > value) || // fighter_mage_thief
                 (creature.Class == 13 && creature.Level2 > value) || // mage_thief
                 (creature.Class == 15 && creature.Level3 > value),   // cleric_thief
            _ => false,
        };
    }
    public bool ClassLevelLT(string obj, int category, int value)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        return category switch
        {
            // mage
            1 => (creature.Class == 1 && creature.Level1 < value) ||  // mage
                 (creature.Class == 7 && creature.Level2 < value) ||  // fighter_mage
                 (creature.Class == 10 && creature.Level2 < value) || // fighter_mage_thief
                 (creature.Class == 13 && creature.Level1 < value) || // mage_thief
                 (creature.Class == 14 && creature.Level2 < value) || // cleric_mage
                 (creature.Class == 17 && creature.Level2 < value),   // fighter_mage_cleric

            // warrior                                                                   
            2 => (creature.Class == 2 && creature.Level1 < value) ||  // fighter
                 (creature.Class == 7 && creature.Level1 < value) ||  // fighter_mage
                 (creature.Class == 8 && creature.Level1 < value) ||  // fighter_cleric
                 (creature.Class == 9 && creature.Level1 < value) ||  // fighter_thief
                 (creature.Class == 10 && creature.Level1 < value) || // fighter_mage_thief
                 (creature.Class == 16 && creature.Level1 < value) || // fighter_druid
                 (creature.Class == 17 && creature.Level1 < value) || // fighter_mage_cleric
                 (creature.Class == 20 && creature.Level1 < value),   // monk

            // priest
            3 => (creature.Class == 3 && creature.Level1 < value) ||  // cleric
                 (creature.Class == 8 && creature.Level2 < value) ||  // fighter_cleric
                 (creature.Class == 14 && creature.Level1 < value) || // cleric_mage
                 (creature.Class == 15 && creature.Level1 < value) || // cleric_thief
                 (creature.Class == 17 && creature.Level3 < value) || // fighter_mage_cleric
                 (creature.Class == 18 && creature.Level1 < value),   // cleric_ranger

            // rogue
            4 => (creature.Class == 4 && creature.Level1 < value) ||  // thief
                 (creature.Class == 9 && creature.Level2 < value) ||  // fighter_thief
                 (creature.Class == 10 && creature.Level3 < value) || // fighter_mage_thief
                 (creature.Class == 13 && creature.Level2 < value) || // mage_thief
                 (creature.Class == 15 && creature.Level3 < value),   // cleric_thief
            _ => false,
        };
    }

    public bool SecretDoorDetected(string obj, int open)
    {
        return false;
    }

    public bool HaveKnownSpell(int spell)
    {
        var spellString = Convert.ToString(spell);
        var type = spellString.First();
        var level = spellString.Skip(1).Take(1).First();
        var spellId = spellString.Substring(spellString.Length - 3, 3);

        return type switch
        {
            // cleric
            '1' => level switch
            {
                '1' => this.Creature.KnownSpells.PriestLevel1.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '2' => this.Creature.KnownSpells.PriestLevel2.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '3' => this.Creature.KnownSpells.PriestLevel3.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '4' => this.Creature.KnownSpells.PriestLevel4.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '5' => this.Creature.KnownSpells.PriestLevel5.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '6' => this.Creature.KnownSpells.PriestLevel6.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '7' => this.Creature.KnownSpells.PriestLevel7.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                _ => false,
            },
            // mage
            '2' => level switch
            {
                '1' => this.Creature.KnownSpells.MageLevel1.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '2' => this.Creature.KnownSpells.MageLevel2.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '3' => this.Creature.KnownSpells.MageLevel3.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '4' => this.Creature.KnownSpells.MageLevel4.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '5' => this.Creature.KnownSpells.MageLevel5.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '6' => this.Creature.KnownSpells.MageLevel6.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '7' => this.Creature.KnownSpells.MageLevel7.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '8' => this.Creature.KnownSpells.MageLevel7.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                '9' => this.Creature.KnownSpells.MageLevel7.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                _ => false,
            },
            // innate
            '3' => level switch
            {
                '1' => this.Creature.KnownSpells.Innate.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spellId),
                _ => false,
            },
            _ => false,
        };
    }

    public bool HaveKnownSpellRES(string spell)
    {
        return
          this.Creature.KnownSpells.PriestLevel1.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.PriestLevel2.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.PriestLevel3.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.PriestLevel4.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.PriestLevel5.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.PriestLevel6.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.PriestLevel7.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel1.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel2.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel3.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel4.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel5.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel6.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel7.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel8.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.MageLevel9.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper()) ||
          this.Creature.KnownSpells.Innate.Select(s => s.Filename).ToString().ToUpper().Trim('\0').Contains(spell.ToUpper());
    }

    public bool CheckItemSlot(string obj, string item, int slot)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        switch (slot)
        {
            case 0:
                return creature.Items.Amulet?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 1:
                return creature.Items.Armor?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 2:
                return creature.Items.Belt?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 3:
                return creature.Items.Boots?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 4:
                return creature.Items.Cloak?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 5:
                return creature.Items.Gloves?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 6:
                return creature.Items.Helmet?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 7:
                return creature.Items.RingLeft?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 8:
                return creature.Items.RingRight?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 9:
                return creature.Items.Shield?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 10:
                return creature.Items.Amulet?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper(); // TODO: 'fist'
            case 11:
                return creature.Items.Quiver1?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 12:
                return creature.Items.Quiver2?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 13:
                return creature.Items.Quiver3?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 14:
                return creature.Items.Quiver4?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();


            //TODO: There are 19 "misc" slots - figure out the order (some are quick item slots, some are inventory slots)
            case 15:
                return creature.Items.InventoryItem1?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 16:
                return creature.Items.InventoryItem2?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 17:
                return creature.Items.InventoryItem3?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 18:
                return creature.Items.InventoryItem4?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 19:
                return creature.Items.InventoryItem5?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 20:
                return creature.Items.InventoryItem6?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 21:
                return creature.Items.InventoryItem7?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 22:
                return creature.Items.InventoryItem8?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 23:
                return creature.Items.InventoryItem9?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 24:
                return creature.Items.InventoryItem10?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 25:
                return creature.Items.InventoryItem11?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 26:
                return creature.Items.InventoryItem12?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 27:
                return creature.Items.InventoryItem13?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 28:
                return creature.Items.InventoryItem14?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 29:
                return creature.Items.InventoryItem15?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 30:
                return creature.Items.InventoryItem16?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 31:
                return creature.Items.Amulet?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 32:
                return creature.Items.Amulet?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 33:
                return creature.Items.Amulet?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();


            case 34:
                return creature.Items.MagicWeapon?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 35:
                return creature.Items.Weapon1?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 36:
                return creature.Items.Weapon2?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 37:
                return creature.Items.Weapon3?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
            case 38:
                return creature.Items.Weapon4?.Filename.ToString().Trim('\0').ToUpper() == item.ToUpper();
        }

        return false;
    }

    public bool CurrentAmmo(string resref, string obj)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var slot = 35 + this.Creature.Items.SelectedWeapon;
        switch (slot)
        {
            case 11:
                return this.Creature.Items.Quiver1?.Charges1 > 0 && this.Creature.Items.Quiver1?.Filename.ToString().ToUpper().Trim('\0') == resref.ToUpper();
            case 12:
                return this.Creature.Items.Quiver2?.Charges1 > 0 && this.Creature.Items.Quiver2?.Filename.ToString().ToUpper().Trim('\0') == resref.ToUpper();
            case 13:
                return this.Creature.Items.Quiver3?.Charges1 > 0 && this.Creature.Items.Quiver3?.Filename.ToString().ToUpper().Trim('\0') == resref.ToUpper();
            case 14:
                return this.Creature.Items.Quiver4?.Charges1 > 0 && this.Creature.Items.Quiver4?.Filename.ToString().ToUpper().Trim('\0') == resref.ToUpper();
        }

        return false;
    }

    public bool Proficiency(string obj, int slot, int value)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var first3Bits = 0;
        switch (slot)
        {
            case 0:
                first3Bits = (byte)(creature?.Unused1Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 1:
                first3Bits = (byte)(creature?.Unused2Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 2:
                first3Bits = (byte)(creature?.Unused3Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 3:
                first3Bits = (byte)(creature?.Unused4Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 4:
                first3Bits = (byte)(creature?.Unused5Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 5:
                first3Bits = (byte)(creature?.Unused6Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 6:
                first3Bits = (byte)(creature?.Unused7Proficiency & 0b0000_0111);
                return first3Bits == value;
            case 7:
                first3Bits = (byte)(creature?.NightmareMode & 0b0000_0111);
                return first3Bits == value;
        }
        return false;
    }

    public bool ProficiencyGT(string obj, int slot, int value)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var first3Bits = 0;
        switch (slot)
        {
            case 0:
                first3Bits = (byte)(creature?.Unused1Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 1:
                first3Bits = (byte)(creature?.Unused2Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 2:
                first3Bits = (byte)(creature?.Unused3Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 3:
                first3Bits = (byte)(creature?.Unused4Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 4:
                first3Bits = (byte)(creature?.Unused5Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 5:
                first3Bits = (byte)(creature?.Unused6Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 6:
                first3Bits = (byte)(creature?.Unused7Proficiency & 0b0000_0111);
                return first3Bits > value;
            case 7:
                first3Bits = (byte)(creature?.NightmareMode & 0b0000_0111);
                return first3Bits > value;
        }
        return false;
    }

    public bool ProficiencyLT(string obj, int slot, int value)
    {
        var creature = objectLocator.GetObject(obj);

        if (creature == null)
            return false;

        var first3Bits = 0;
        switch (slot)
        {
            case 0:
                first3Bits = (byte)(creature?.Unused1Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 1:
                first3Bits = (byte)(creature?.Unused2Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 2:
                first3Bits = (byte)(creature?.Unused3Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 3:
                first3Bits = (byte)(creature?.Unused4Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 4:
                first3Bits = (byte)(creature?.Unused5Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 5:
                first3Bits = (byte)(creature?.Unused6Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 6:
                first3Bits = (byte)(creature?.Unused7Proficiency & 0b0000_0111);
                return first3Bits < value;
            case 7:
                first3Bits = (byte)(creature?.NightmareMode & 0b0000_0111);
                return first3Bits < value;
        }
        return false;
    }
}