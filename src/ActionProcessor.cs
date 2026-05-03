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

	public bool EquipItemEx(string obj, int slot)
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

	public bool Giveorder(string obj, int order)
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

	public bool LayOnHands(string target)
	{
		return true;
	}

	public bool LeaveParty()
	{
		return true;
	}


	public bool SetGlobal(string name, string area, int type)
	{
		return true;
	}
}