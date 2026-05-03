using ii.InfinityEngine;
using ii.InfinityEngine.Files;
using System.Linq;

var game = new Game("D:\\Games\\ie\\bg2ee", "D:\\Games\\ie\\bg2ee\\lang\\en_US");
game.LoadResources([IEFileType.Dlg, IEFileType.Ids]);

var d = game.Dialogs.Where(w => w.Filename.ToUpper() == "PPDILI.DLG").First();

var myself = new Creature();
myself.HP = 100;
myself.Items.Add("test");

var globalState = new List<(string name, int value)>();
globalState.Add(("test", 1));
globalState.Add(("OHN_dili", 1));

var area = new Area();
area.AreaCode = "AR1234";

var idsProcessor = new IdsProcessor();
var objectLocator = new ObjectLocator();
objectLocator.Myself = myself;

var toady = new Creature();
toady.ScriptName = "arntra03";
toady.State = 1;
objectLocator.AllCreatures.Add(toady);

var foundEntryState = false;

if (d.states.Any(a => a.Weight > 0))
{
	d.states = d.states.OrderBy(o => o.Weight).ToList();
}

var tp = new TriggerProcessor(objectLocator, idsProcessor);
tp.Area = area;
tp.GlobalState = globalState;

var currentState = 0;
foreach (var state in d.states)
{
	//Console.Write($"Checking state {state.StateNumber}");
	var valid = false;
	if (String.IsNullOrEmpty(state.Trigger))
	{
		//valid = true;
		//Console.WriteLine();
		//Console.WriteLine(" Not a top level state (no trigger)");
		//Console.WriteLine();
		continue;
	}
	else
	{
		Console.WriteLine($"State {state.StateNumber} (weight {state.Weight})");
		var trigger = state.Trigger;

		var triggers = trigger.Split([")"], StringSplitOptions.None)
								  .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
								  .ToArray();

		valid = EvaluateTriggers<TriggerProcessor>(triggers, tp, game.Identifiers);
	}

	if (valid)
	{
		tp.selectedRandom = -1;
		currentState = state.StateNumber;
		foundEntryState = true;
		Console.WriteLine($"{state.ResponseText.Text} ({state.ResponseText.Strref})");
		for (int i = 0; i < state.transitions.Count; i++)
		{
			if (state.transitions[i].HasTrigger)
			{
				var responseTriggers = state.transitions[i].Trigger.Split([")"], StringSplitOptions.None)
						  .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
						  .ToArray();

				var validResponse = EvaluateTriggers<TriggerProcessor>(responseTriggers, tp, game.Identifiers);
				if (state.transitions[i].HasText)
				{
					Console.WriteLine($" - [{i}] {state.transitions[i].TransitionText.Text}");
				}
			}
			else
			{
				if (state.transitions[i].HasText)
				{
					Console.WriteLine($" - [{i}] {state.transitions[i].TransitionText.Text}");
				}
			}
		}
		break;
	}
}


//TODO: User enters a number to select a response, then we run the actions associated with that response

var selected = Convert.ToInt32(Console.ReadLine());

var actionText = d.states[Convert.ToInt32(currentState)].transitions[selected].Action;

Console.WriteLine("Actions");
var ap = new ActionProcessor(objectLocator, idsProcessor);
var actions = actionText.Split([")"], StringSplitOptions.None)
						.Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
						.ToArray();
var done = EvaluateTriggers<ActionProcessor>(actions, ap, game.Identifiers);

Console.WriteLine();


if (!foundEntryState)
{
	Console.WriteLine("Target has no valid dialog");
}


////var triggerText = "Global(\"Lumbar_Huff\", \"GLOBAL\", 1)Global(\"Know_L\r\numbar\", \"GLOBAL\", 0)";
//var triggerText = "AreaCheck(\"AR1234\")Global(\"test\", \"global\", 1)HP(Myself, 100)InParty(Myself)PartyHasItem(\"test\")";
//var actionText = "JoinParty(test, 1) NoAction()";

//var myself = new Creature();
//myself.HP = 100;
//myself.Items.Add("test");

//var partyMember = new PartyMember();
//partyMember.Creature = myself;
//partyMember.Happiness = 1;

//var party = new Party();
//party.Members.Add(partyMember);
//party.PartyGold = 50;

//var objectLocator = new ObjectLocator();
//objectLocator.Myself = myself;

//objectLocator.AllCreatures.Add(myself);
//objectLocator.Party = party;

//var idsProcessor = new IdsProcessor();

//var globalState = new List<(string name, int value)>();
//globalState.Add(("test", 1));

//var area = new Area();
//area.AreaCode = "AR1234";

//Console.WriteLine("Triggers");
//var tp = new TriggerProcessor(objectLocator, idsProcessor);
//tp.Area = area;
//tp.GlobalState = globalState;
//var triggers = triggerText.Split([")"], StringSplitOptions.None)
//                          .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
//                          .ToArray();
//var triggered = EvaluateTriggers<TriggerProcessor>(triggers, tp);

//if (triggered)
//{
//    Console.WriteLine("");
//    Console.WriteLine("Actions");
//    var ap = new ActionProcessor(objectLocator, idsProcessor);
//    var actions = actionText.Split([")"], StringSplitOptions.None)
//                            .Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
//                            .ToArray();
//    EvaluateTriggers<ActionProcessor>(actions, ap);
//}


static bool EvaluateTriggers<T>(string[] methods, object o, List<IdsFile> idsFiles)
{
	bool? result = true;
	foreach (var methodCall in methods)
	{
		if (methodCall == ")")
			continue;

		var methodName = methodCall[..methodCall.IndexOf('(')];

		var inverted = false;
		if (methodName.StartsWith("!"))
		{
			methodName = methodName[1..];
			inverted = true;
		}

		var parametersString = methodCall.Substring(methodCall.IndexOf('(') + 1, methodCall.IndexOf(')') - methodCall.IndexOf('(') - 1);

		var parameters = parametersString.Split(',').Select(p => p.Trim()).ToArray();




		//TODO: Find the trigger in trigger.ids
		//      Split the parameters
		//      Check the parameter types
		//      If a parameter type is I:<something> load the <something>ids file and replace our param value with the int associated with the value in the IDS

		var triggerDefinition = idsFiles.Single(s => s.Filename.ToUpper() == "TRIGGER.IDS");
		var triggers = triggerDefinition.contents.Split("\r\n");
		// Note: This .First() means we don't support overloads
		var thisTrigger = triggers.Where(w => w.Contains($" {methodName}(")).First(); // e.g. "0x400F Global(S:Name*,S:Area*,I:Value*)"
		var triggerParameters = thisTrigger.Substring(thisTrigger.IndexOf("(")).Trim(['(', ')']).Split(',');

		var i = 0;
		foreach (var p in triggerParameters)
		{
			if (p.Contains('*') && !p.EndsWith('*'))
			{
				var ids = p.Substring(p.LastIndexOf('*'));
				var relevantIds = idsFiles.Where(w => w.Filename.ToUpper().Replace(".IDS", "") == ids.ToUpper().Replace("*", "")).First();
				var lines = relevantIds.contents.Split("\r\n");

				var actualTrigger = parameters[i].Replace("\"", "");

				var line = lines.Where(w => w.EndsWith(actualTrigger)).First();
				var value = line.Split(" ")[0];
				parameters[i] = value;
				if (value.StartsWith("0x"))
				{
					parameters[i] = Convert.ToString(Convert.ToInt32(value, 16));
				}
			}
			i++;
		}



		//parameters.Replace("STATE_SLEEPING", "1"); //TEMP

		var method = typeof(T).GetMethod(methodName);

		if (method != null)
		{
			var methodParameters = method.GetParameters()
										 .Select((p, index) => ConvertParameter(parameters[index], p.ParameterType))
										 .Select(m => (m as string) != null ? (m as string).Trim('\"') : m)
										 .ToArray();

			result = method.Invoke(o, methodParameters) as bool?;
			if (inverted)
			{
				result = !result;
			}

			Console.WriteLine($"  {(inverted ? "!" : string.Empty)}{methodName} {String.Join(",", parametersString.Split(',').Select(p => p.Trim()).ToArray())} -> {result}");

			if (result != true)
			{
				//Console.WriteLine("    Method result: " + false);
				break;
			}
			//Console.WriteLine("    Method result: " + result);
		}
		else
		{
			Console.WriteLine("    Method not found: " + methodName);
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