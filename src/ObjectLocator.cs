public class ObjectLocator()
{
    public Creature GetObject(string obj)
    {
        var type = this.GetType();
        var propertyInfos = type.GetProperties();

        var method = propertyInfos.Where(propertyInfo => propertyInfo.Name == obj).SingleOrDefault();
        if (method != null)
        {
            return (Creature)method.GetValue(this);
        }
        return null;
    }

    public Creature Myself { get; set; }
    public Creature LeaderOf { get; set; }
    public Creature GroupOf { get; set; }
    public Creature WeakestOf { get; set; }
    public Creature StrongestOf { get; set; }
    public Creature MostDamagedOf { get; set; }
    public Creature LeastDamagedOf { get; set; }
    public Creature ProtectedBy { get; set; }
    public Creature ProtectorOf { get; set; }
    public Creature LastAttackerOf { get; set; }
    public Creature LastTargettedBy { get; set; }
    public Creature NearestEnemyOf { get; set; }
    public Creature LastCommandedBy { get; set; }
    public Creature Nearest { get; set; }
    public Creature LastHitter { get; set; }
    public Creature LastTrigger { get; set; }
    public Creature LastSeenBy { get; set; }
    public Creature LastTalkedToBy { get; set; }
    public Creature LastHeardBy { get; set; }
    public Creature Player1 { get; set; }
    public Creature Player2 { get; set; }
    public Creature Player3 { get; set; }
    public Creature Player4 { get; set; }
    public Creature Player5 { get; set; }
    public Creature Player6 { get; set; }
    public Creature Protagonist { get; set; }
    public Creature StrongestOfMale { get; set; }
    public Creature SecondNearestEnemyOf { get; set; }
    public Creature ThirdNearestEnemyOf { get; set; }
    public Creature FourthNearestEnemyOf { get; set; }
    public Creature FifthNearestEnemyOf { get; set; }
    public Creature SixthNearestEnemyOf { get; set; }
    public Creature SeventhNearestEnemyOf { get; set; }
    public Creature EighthNearestEnemyOf { get; set; }
    public Creature NinthNearestEnemyOf { get; set; }
    public Creature TenthNearestEnemyOf { get; set; }
    public Creature SecondNearest { get; set; }
    public Creature ThirdNearest { get; set; }
    public Creature FourthNearest { get; set; }
    public Creature FifthNearest { get; set; }
    public Creature SixthNearest { get; set; }
    public Creature SeventhNearest { get; set; }
    public Creature EighthNearest { get; set; }
    public Creature NinthNearest { get; set; }
    public Creature TenthNearest { get; set; }
    public Creature WorstAC { get; set; }
    public Creature BestAC { get; set; }
    public Creature LastSummonerOf { get; set; }
    public Creature NearestEnemyOfType { get; set; }
    public Creature SecondNearestEnemyOfType { get; set; }
    public Creature ThirdNearestEnemyOfType { get; set; }
    public Creature FourthNearestEnemyOfType { get; set; }
    public Creature FifthNearestEnemyOfType { get; set; }
    public Creature SixthNearestEnemyOfType { get; set; }
    public Creature SeventhNearestEnemyOfType { get; set; }
    public Creature EigthNearestEnemyOfType { get; set; }
    public Creature EighthNearestEnemyOfType { get; set; }
    public Creature NinthNearestEnemyOfType { get; set; }
    public Creature TenthNearestEnemyOfType { get; set; }
    public Creature NearestMyGroupOfType { get; set; }
    public Creature SecondNearestMyGroupOfType { get; set; }
    public Creature ThirdNearestMyGroupOfType { get; set; }
    public Creature FourthNearestMyGroupOfType { get; set; }
    public Creature FifthNearestMyGroupOfType { get; set; }
    public Creature SixthNearestMyGroupOfType { get; set; }
    public Creature SeventhNearestMyGroupOfType { get; set; }
    public Creature EigthNearestMyGroupOfType { get; set; }
    public Creature EighthNearestMyGroupOfType { get; set; }
    public Creature NinthNearestMyGroupOfType { get; set; }
    public Creature TenthNearestMyGroupOfType { get; set; }
    public Creature Player1Fill { get; set; }
    public Creature Player2Fill { get; set; }
    public Creature Player3Fill { get; set; }
    public Creature Player4Fill { get; set; }
    public Creature Player5Fill { get; set; }
    public Creature Player6Fill { get; set; }
    public Creature NearestDoor { get; set; }
    public Creature SecondNearestDoor { get; set; }
    public Creature ThirdNearestDoor { get; set; }
    public Creature FourthNearestDoor { get; set; }
    public Creature FifthNearestDoor { get; set; }
    public Creature SixthNearestDoor { get; set; }
    public Creature SeventhNearestDoor { get; set; }
    public Creature EighthNearestDoor { get; set; }
    public Creature NinthNearestDoor { get; set; }
    public Creature TenthNearestDoor { get; set; }
    public Creature PartySlot1 { get; set; }
    public Creature PartySlot2 { get; set; }
    public Creature PartySlot3 { get; set; }
    public Creature PartySlot4 { get; set; }
    public Creature PartySlot5 { get; set; }
    public Creature PartySlot6 { get; set; }
    public Creature Familiar { get; set; }
    public Creature FamiliarSummoner { get; set; }
    public Creature LastKilled { get; set; }
    public Creature NearestAllyOf { get; set; }
    public Creature SecondNearestAllyOf { get; set; }
    public Creature ThirdNearestAllyOf { get; set; }
    public Creature FourthNearestAllyOf { get; set; }
    public Creature FifthNearestAllyOf { get; set; }
    public Creature SixthNearestAllyOf { get; set; }
    public Creature SeventhNearestAllyOf { get; set; }
    public Creature EighthNearestAllyOf { get; set; }
    public Creature NinthNearestAllyOf { get; set; }
    public Creature TenthNearestAllyOf { get; set; }
    public Creature FarthestEnemyOf { get; set; }
    public Creature SecondFarthestEnemyOf { get; set; }
    public Creature ThirdFarthestEnemyOf { get; set; }
    public Creature FourthFarthestEnemyOf { get; set; }
    public Creature FifthFarthestEnemyOf { get; set; }
    public Creature SixthFarthestEnemyOf { get; set; }
    public Creature SeventhFarthestEnemyOf { get; set; }
    public Creature EighthFarthestEnemyOf { get; set; }
    public Creature NinthFarthestEnemyOf { get; set; }
    public Creature TenthFarthestEnemyOf { get; set; }
}