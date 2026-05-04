using ii.InfinityEngine.Files;

public class TriggerProcessor
{
	private readonly ObjectLocator objectLocator;
	private readonly IdsProcessor idsProcessor;
	private readonly Random random;

	public TriggerProcessor(ObjectLocator objectLocator, IdsProcessor idsProcessor, List<DimensionalArrayFile> dimensionalArrayFiles)
	{
		this.objectLocator = objectLocator;
		this.idsProcessor = idsProcessor;
		random = new Random();
		this.dimensionalArrayFiles = dimensionalArrayFiles;
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
		//return this.Creature.MemorisedSpells.PriestLevel7.First().Filename Contains(spell);
		return true;
	}

	public bool HaveSpell(string spell)
	{
		//var spellId = idsProcessor.GetIdsValue("spell.ids", spell);
		//return this.Creature.MemorisedSpells.Contains(spellId);
		return true;
	}

	public bool HaveAnySpells()
	{
		//return this.Creature.MemorisedSpells.Any();
		return true;
	}

	public bool BecameVisible()
	{
		return false;
	}

	public bool GlobalGT(string name, string area, int value)
	{
		if (area == "global")
		{
			return this.GlobalState.SingleOrDefault(w => w.name == name).value > value;
		}
		if (area == "area")
		{
			return this.Area.Variables.Count(w => w.variable == name && w.value > value) == 1;
		}
		if (area == "locals")
		{
			//
		}
		return false;
	}

	public bool GlobalLT(string name, string area, int value)
	{
		if (area == "global")
		{
			return this.GlobalState.SingleOrDefault(w => w.name == name).value < value;
		}
		if (area == "area")
		{
			return this.Area.Variables.Count(w => w.variable == name && w.value < value) == 1;
		}
		if (area == "locals")
		{
			//
		}
		return false;
	}

	public bool OnCreation()
	{
		return false;
	}

	public bool StateCheck(string obj, int state)
	{
		//var creature = objectLocator.GetObject(obj);
		//return (creature.StatusFlags & state) > 0;
		return true;
	}

	//public bool StateCheck(string obj, string state)
	//{
	//    var stateId = idsProcessor.GetIdsValue("state.ids", state);
	//    return StateCheck(obj, stateId);
	//}

	public bool NotStateCheck(string obj, int state)
	{
		//var creature = objectLocator.GetObject(obj);      
		//return (creature.StatusFlags & state) == 0;
		return true;
	}

	public bool NumTimesTalkedTo(int num)
	{
		// This is stored in the CRE field in the ARE file
		return true;
	}

	public bool NumTimesTalkedToGT(int num)
	{
		// This is stored in the CRE field in the ARE file
		return false;
	}

	public bool NumTimesTalkedToLT(int num)
	{
		// This is stored in the CRE field in the ARE file
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
		//TODO: Bag of holding etc.
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
				var filename = slot?.Filename.ToString().ToUpper().Trim('\0');
				if (string.IsNullOrEmpty(filename))
					continue;

				var slotItem = filename.Trim('\0').ToUpperInvariant();

				if (slotItem == targetItem)
					return true;

				var dotIndex = slotItem.IndexOf('.');
				if (dotIndex > 0)
				{
					var noExt = slotItem.Substring(0, dotIndex);
					if (noExt == targetItem)
						return true;
				}
			}
		}

		return false;
	}

	public bool InParty(string obj)
	{
		var creature = objectLocator.GetObject(obj);
		return creature.DeathVariable.ToString().ToUpper().Trim('\0') == obj.ToUpper();
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
			//	return LayOnHandsAmount > value; //TODO: calculate

			//TODO: Expand this list

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
		//var creature = objectLocator.GetObject(obj);
		//return creature.Items.Any(a => a == resRef);
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
		return false;
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
		//var creature = objectLocator.GetObject(obj);
		//return creature?.Items.Count(w => w == resRef) == num;
		return true;
	}

	public bool NumItemsGT(string resRef, string obj, int num)
	{
		//var creature = objectLocator.GetObject(obj);
		//return creature?.Items.Count(w => w == resRef) > num;
		return true;
	}

	public bool NumItemsLT(string resRef, string obj, int num)
	{
		//var creature = objectLocator.GetObject(obj);
		//return creature?.Items.Count(w => w == resRef) < num;
		return true;
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

	public bool IfValidForPartyDialogue(string obj)
	{
		return IfValidForPartyDialog(obj);
	}

	public bool IsValidForPartyDialog(string obj)
	{
		// obj is in the party
		// obj is not dead
		return IfValidForPartyDialog(obj);
	}

	public bool IfValidForPartyDialog(string obj)
	{
		//var creature = this.objectLocator.Party.Where(w => w.CreFile.DeathVariable.ToString().Trim('\0').ToUpper() == obj).SingleOrDefault();
		//return creature != null;
		return true;
	}

	public bool IsValidForPartyDialogue(string obj)
	{
		return IfValidForPartyDialog(obj);
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
		return false;
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


	public bool IsWeaponRanged(string obj)
	{
		return false;
	}

	public bool ButtonDisabled(int button)
	{
		return false;
	}

	public bool HasItemCategory(string obj, int itemtype, bool equipped)
	{
		return false;
	}

	public bool NightmareModeOn()
	{
		return false;
	}

	//OriginalClass(O:Object*, I:Class* CLASS)
	//CutSceneBroken()
	//WeaponEffectiveVs(O:Object*, I:Hand* HAND)
	//INI(S:Name*, I:Number*)
	//ModalStateObject(O:Object*, I:ModalState* Modal)
	//WeaponCanDamage(O:Object*, I:Hand* HAND)
	//NumKilledByParty(I:Number*)
	//NumKilledByPartyGT(I:Number*)
	//NumKilledByPartyLT(I:Number*)
	//CanTurn(O:Object*, I:Difference*)
	//BitCheck(S:Name*, S:Area*, I:Bit* Bits)
	//CanEquipRanged()
	//ImmuneToSpellLevel(O:Object*, I:Level*
	//StoryModeOn()
	//IsForcedRandomEncounterActive(S:Area*)
	//ClassLevel(O:Object*, I:Category* CLASSCAT, I:Value*)
	//ClassLevelGT(O:Object*, I:Category* CLASSCAT, I:Value*)
	//ClassLevelLT(O:Object*, I:Category* CLASSCAT, I:Value*)

	public bool SecretDoorDetected(string obj, int open)
	{
		return false;
	}

	public bool HaveKnownSpell(int spell)
	{
		return false;
	}

	public bool HaveKnownSpellRES(string spell)
	{
		return false;
	}

	public bool CheckItemSlot(string obj, string item, int slot)
	{
		return false;
	}

	public bool CurrentAmmo(string resref, string obj)
	{
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