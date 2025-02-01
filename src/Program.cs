//var triggerText = "Global(\"Lumbar_Huff\", \"GLOBAL\", 1)Global(\"Know_L\r\numbar\", \"GLOBAL\", 0)";
var triggerText = "AreaCheck(\"AR1234\")Global(\"test\", \"global\", 1)HP(Myself, 100)InParty(Myself)PartyHasItem(\"test\")";
var actionText = "JoinParty(test, 1) NoAction()";

var myself = new Creature();
myself.HP = 100;
myself.Items.Add("test");

var partyMember = new PartyMember();
partyMember.Creature = myself;
partyMember.Happiness = 1;

var party = new Party();
party.Members.Add(partyMember);
party.PartyGold = 50;

var objectLocator = new ObjectLocator();
objectLocator.Myself = myself;

objectLocator.AllCreatures.Add(myself);
objectLocator.Party = party;

var idsProcessor = new IdsProcessor();

var globalState = new List<(string name, int value)>();
globalState.Add(("test", 1));

var area = new Area();
area.AreaCode = "AR1234";

Console.WriteLine("Triggers");
var tp = new TriggerProcessor(objectLocator, idsProcessor);
tp.Area = area;
tp.GlobalState = globalState;
var triggers = triggerText.Split([")"], StringSplitOptions.None)
                          .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
                          .ToArray();
var triggered = ProcessMethod<TriggerProcessor>(triggers, tp);

if (triggered)
{
    Console.WriteLine("");
    Console.WriteLine("Actions");
    var ap = new ActionProcessor(objectLocator, idsProcessor);
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

            Console.WriteLine($"  {methodName} {String.Join(",", methodParameters)}");
            result = method.Invoke(o, methodParameters) as bool?;
            if (result != true)
            {
                Console.WriteLine("    Method result: " + false);
                break;
            }
            Console.WriteLine("    Method result: " + result);
        }
        else
        {
            Console.WriteLine("    Method not found.");
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