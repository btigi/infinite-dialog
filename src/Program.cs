using ii.InfinityEngine;
using ii.InfinityEngine.Files;
using ii.InfinityEngine.Readers;

var gameDirectory = @"D:\Games\ie\bg2ee";
var tlkDirectory = @"D:\Games\ie\bg2ee\lang\en_US";
var gamFile = @"C:\Users\igi\Downloads\baldursgate2shadowsofamn_savegames_all\BGII\save\000000065-057 North Forest\baldur.gam";
var dFile = "ABAZIGAL.DLG";

if (args.Length == 4)
{
	gameDirectory = args[0];
	tlkDirectory = args[1];
	gamFile = args[2];
	dFile = args[3];
}

var game = new Game(gameDirectory, tlkDirectory);
game.LoadResources([IEFileType.Dlg, IEFileType.Ids, IEFileType.DimensionalArray, IEFileType.Cre, IEFileType.Itm, IEFileType.Sto]);

var gamReader = new GamFileBinaryReader();
gamReader.TlkFile = game.Tlk;
var gam = gamReader.Read(gamFile);
var globalVariables = gam.Variables.Select(s => (name: s.Name.ToString().Trim('\0'), value: s.ValueInt)).ToList();

//var d = game.Dialogs.Where(w => w.Filename.ToUpper() == "PPDILI.DLG").First();
//var d = game.Dialogs.Where(w => w.Filename.ToUpper() == "MOOK.DLG").First();
var d = game.Dialogs.Where(w => w.Filename.ToUpper() == dFile).First();

var myself = new CreFile();
myself.CurrentHP = 100;
//myself.Items.Add("test");

//var globalState = new List<(string name, int value)>();
//globalState.Add(("test", 1));
//globalState.Add(("OHN_dili", 1));

var area = new Area();
area.AreaCode = "AR1234";

var idsProcessor = new IdsProcessor();
var objectLocator = new ObjectLocator();
objectLocator.Myself = myself;
objectLocator.Party = gam.PartyMembers;

var toady = new CreFile();
toady.DeathVariable = new array32("arntra03");
toady.StatusFlags.Sleeping = true;
objectLocator.AllCreatures.Add(toady);

var foundEntryState = false;

if (d.states.Any(a => a.Weight > 0))
{
	d.states = d.states.OrderBy(o => o.Weight).ToList();
}

var tp = new TriggerProcessor(objectLocator, idsProcessor, game.DimensionalArrays, game.Stores, game.Items, gam, game.Tlk);
tp.Area = area;
tp.GlobalState = globalVariables;
tp.Game = gam;
tp.Creature = gam.PartyMembers.First().CreFile;

var x = Path.ChangeExtension(d.Filename.ToString().Trim('\0').ToUpper(), "").TrimEnd('.');
var c = game.Creatures.Where(w => w.DialogFile.ToString().Trim('\0').ToUpper() == x).FirstOrDefault();
if (c != null)
{
	var existingColour = Console.ForegroundColor;
	Console.ForegroundColor = ConsoleColor.Blue;
	Console.WriteLine($"{c.ShortName.Text}");
	Console.ForegroundColor = existingColour;
}

var currentStateNumber = 0;
foreach (var state in d.states)
{
	var valid = false;
	if (String.IsNullOrEmpty(state.Trigger))
	{
		continue;
	}
	else
	{
		Console.WriteLine($"State {state.StateNumber} (weight {state.Weight})");
		var trigger = state.Trigger;

		var triggers = SplitTriggers(trigger);

		//triggers = new string[1];
		//triggers[0] = "CalanderDay(1)";

		valid = EvaluateTriggers<TriggerProcessor>(triggers, tp, game.Identifiers);
	}

	if (valid)
	{
		tp.selectedRandom = -1;
		currentStateNumber = state.StateNumber;
		foundEntryState = true;
		break;
	}
}

if (!foundEntryState)
{
	Console.WriteLine("Target has no valid dialog");
}
else
{
	var ap = new ActionProcessor(objectLocator, idsProcessor);
	ap.Area = area;
	ap.Creature = myself;

	DlgFile currentDlg = d;
	var dialogDone = false;

	void ProcessTransition(Transition2 t)
	{
		if (t.HasAction && !string.IsNullOrEmpty(t.Action))
		{
			EvaluateTriggers<ActionProcessor>(SplitTriggers(t.Action), ap, game.Identifiers);
		}

		if (t.TerminateDialog)
		{
			dialogDone = true;
			return;
		}

		var x = t.Dialog.ToString().Trim('\0').ToUpper();
		var c = game.Creatures.Where(w => w.DialogFile.ToString().Trim('\0').ToUpper() == x).FirstOrDefault();
		if (c != null)
		{
			var existingColour = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"{c.ShortName.Text}");
			Console.ForegroundColor = existingColour;
		}

		var nextDlg = LookupDlg(game.Dialogs, t.Dialog) ?? currentDlg;
		currentDlg = nextDlg;
		currentStateNumber = t.NextState;
	}

	while (!dialogDone)
	{
		var state = LookupState(currentDlg, currentStateNumber);
		if (state == null)
		{
			Console.WriteLine("[State not found]");
			break;
		}

		Console.WriteLine($"{state.ResponseText.Text} ({state.ResponseText.Strref})");

		var validTransitions = state.transitions
			.Where(t => !t.HasTrigger ||
						 EvaluateTriggers<TriggerProcessor>(SplitTriggers(t.Trigger), tp, game.Identifiers))
			.ToList();

		if (!validTransitions.Any())
		{
			Console.WriteLine("[No valid responses]");
			break;
		}

		if (validTransitions.Count == 1 && !validTransitions[0].HasText)
		{
			ProcessTransition(validTransitions[0]);
			continue;
		}

		for (int i = 0; i < validTransitions.Count; i++)
		{
			if (validTransitions[i].HasText)
			{
				Console.WriteLine($" - [{i}] {validTransitions[i].TransitionText.Text}");
			}
		}

		Console.Write("> ");
		var selected = Convert.ToInt32(Console.ReadLine());
		ProcessTransition(validTransitions[selected]);
	}

	Console.WriteLine();
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


static string[] SplitTriggers(string text)
{
	if (string.IsNullOrEmpty(text))
		return [];
	return text.Split([")"], StringSplitOptions.None)
		.Select(m => (m.EndsWith(')') ? m : m + ")").Trim())
		.ToArray();
}

static State2 LookupState(DlgFile dlg, int stateNumber) => dlg.states.SingleOrDefault(s => s.StateNumber == stateNumber);

static DlgFile LookupDlg(IEnumerable<DlgFile> dialogs, array8 resref)
{
	var name = resref.ToString().ToUpperInvariant();
	if (string.IsNullOrEmpty(name))
		return null;
	return dialogs.SingleOrDefault(d => Path.GetFileNameWithoutExtension(d.Filename).ToUpperInvariant() == name);
}

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
		try
		{
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
		}
		catch
		{
			//TODO:
		}

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

			//Console.WriteLine($"  {(inverted ? "!" : string.Empty)}{methodName} {String.Join(",", parametersString.Split(',').Select(p => p.Trim()).ToArray())} -> {result}");

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