using ii.InfinityEngine.Files;

public class ObjectLocator()
{
    public CreFile GetObject(string obj)
    {
        var type = this.GetType();
        var propertyInfos = type.GetProperties();

        var method = propertyInfos.Where(propertyInfo => propertyInfo.Name == obj).SingleOrDefault();
        if (method != null)
        {
            return (CreFile)method.GetValue(this);
        }
        else if (AllCreatures.Any(creature => creature.DeathVariable.ToString().Trim('\0').ToUpper() == obj.ToUpper()))
        {
            return AllCreatures.Where(creature => creature.DeathVariable.ToString().Trim('\0').ToUpper() == obj.ToUpper()).Single();
		}
        return null;
    }

    public List<CreFile> AllCreatures = [];
    public List<GamNpcStruct> Party = new();

	public CreFile Myself { get; set; }
    public CreFile LeaderOf { get; set; }
    public CreFile GroupOf { get; set; }
    public CreFile WeakestOf { get; set; }
    public CreFile StrongestOf { get; set; }
    public CreFile MostDamagedOf { get; set; }
    public CreFile LeastDamagedOf { get; set; }
    public CreFile ProtectedBy { get; set; }
    public CreFile ProtectorOf { get; set; }
    public CreFile LastAttackerOf { get; set; }
    public CreFile LastTargettedBy { get; set; }
    public CreFile NearestEnemyOf { get; set; }
    public CreFile LastCommandedBy { get; set; }
    public CreFile Nearest { get; set; }
    public CreFile LastHitter { get; set; }
    public CreFile LastTrigger { get; set; }
    public CreFile LastSeenBy { get; set; }
    public CreFile LastTalkedToBy { get; set; }
    public CreFile LastHeardBy { get; set; }
    public CreFile Player1 { get; set; }
    public CreFile Player2 { get; set; }
    public CreFile Player3 { get; set; }
    public CreFile Player4 { get; set; }
    public CreFile Player5 { get; set; }
    public CreFile Player6 { get; set; }
    public CreFile Protagonist { get; set; }
    public CreFile StrongestOfMale { get; set; }
    public CreFile SecondNearestEnemyOf { get; set; }
    public CreFile ThirdNearestEnemyOf { get; set; }
    public CreFile FourthNearestEnemyOf { get; set; }
    public CreFile FifthNearestEnemyOf { get; set; }
    public CreFile SixthNearestEnemyOf { get; set; }
    public CreFile SeventhNearestEnemyOf { get; set; }
    public CreFile EighthNearestEnemyOf { get; set; }
    public CreFile NinthNearestEnemyOf { get; set; }
    public CreFile TenthNearestEnemyOf { get; set; }
    public CreFile SecondNearest { get; set; }
    public CreFile ThirdNearest { get; set; }
    public CreFile FourthNearest { get; set; }
    public CreFile FifthNearest { get; set; }
    public CreFile SixthNearest { get; set; }
    public CreFile SeventhNearest { get; set; }
    public CreFile EighthNearest { get; set; }
    public CreFile NinthNearest { get; set; }
    public CreFile TenthNearest { get; set; }
    public CreFile WorstAC { get; set; }
    public CreFile BestAC { get; set; }
    public CreFile LastSummonerOf { get; set; }
    public CreFile NearestEnemyOfType { get; set; }
    public CreFile SecondNearestEnemyOfType { get; set; }
    public CreFile ThirdNearestEnemyOfType { get; set; }
    public CreFile FourthNearestEnemyOfType { get; set; }
    public CreFile FifthNearestEnemyOfType { get; set; }
    public CreFile SixthNearestEnemyOfType { get; set; }
    public CreFile SeventhNearestEnemyOfType { get; set; }
    public CreFile EigthNearestEnemyOfType { get; set; }
    public CreFile EighthNearestEnemyOfType { get; set; }
    public CreFile NinthNearestEnemyOfType { get; set; }
    public CreFile TenthNearestEnemyOfType { get; set; }
    public CreFile NearestMyGroupOfType { get; set; }
    public CreFile SecondNearestMyGroupOfType { get; set; }
    public CreFile ThirdNearestMyGroupOfType { get; set; }
    public CreFile FourthNearestMyGroupOfType { get; set; }
    public CreFile FifthNearestMyGroupOfType { get; set; }
    public CreFile SixthNearestMyGroupOfType { get; set; }
    public CreFile SeventhNearestMyGroupOfType { get; set; }
    public CreFile EigthNearestMyGroupOfType { get; set; }
    public CreFile EighthNearestMyGroupOfType { get; set; }
    public CreFile NinthNearestMyGroupOfType { get; set; }
    public CreFile TenthNearestMyGroupOfType { get; set; }
    public CreFile Player1Fill { get; set; }
    public CreFile Player2Fill { get; set; }
    public CreFile Player3Fill { get; set; }
    public CreFile Player4Fill { get; set; }
    public CreFile Player5Fill { get; set; }
    public CreFile Player6Fill { get; set; }
    public CreFile NearestDoor { get; set; }
    public CreFile SecondNearestDoor { get; set; }
    public CreFile ThirdNearestDoor { get; set; }
    public CreFile FourthNearestDoor { get; set; }
    public CreFile FifthNearestDoor { get; set; }
    public CreFile SixthNearestDoor { get; set; }
    public CreFile SeventhNearestDoor { get; set; }
    public CreFile EighthNearestDoor { get; set; }
    public CreFile NinthNearestDoor { get; set; }
    public CreFile TenthNearestDoor { get; set; }
    public CreFile PartySlot1 { get; set; }
    public CreFile PartySlot2 { get; set; }
    public CreFile PartySlot3 { get; set; }
    public CreFile PartySlot4 { get; set; }
    public CreFile PartySlot5 { get; set; }
    public CreFile PartySlot6 { get; set; }
    public CreFile Familiar { get; set; }
    public CreFile FamiliarSummoner { get; set; }
    public CreFile LastKilled { get; set; }
    public CreFile NearestAllyOf { get; set; }
    public CreFile SecondNearestAllyOf { get; set; }
    public CreFile ThirdNearestAllyOf { get; set; }
    public CreFile FourthNearestAllyOf { get; set; }
    public CreFile FifthNearestAllyOf { get; set; }
    public CreFile SixthNearestAllyOf { get; set; }
    public CreFile SeventhNearestAllyOf { get; set; }
    public CreFile EighthNearestAllyOf { get; set; }
    public CreFile NinthNearestAllyOf { get; set; }
    public CreFile TenthNearestAllyOf { get; set; }
    public CreFile FarthestEnemyOf { get; set; }
    public CreFile SecondFarthestEnemyOf { get; set; }
    public CreFile ThirdFarthestEnemyOf { get; set; }
    public CreFile FourthFarthestEnemyOf { get; set; }
    public CreFile FifthFarthestEnemyOf { get; set; }
    public CreFile SixthFarthestEnemyOf { get; set; }
    public CreFile SeventhFarthestEnemyOf { get; set; }
    public CreFile EighthFarthestEnemyOf { get; set; }
    public CreFile NinthFarthestEnemyOf { get; set; }
    public CreFile TenthFarthestEnemyOf { get; set; }
}