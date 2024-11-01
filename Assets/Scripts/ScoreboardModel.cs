using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class ScoreboardModel
{
    [RealtimeProperty(1, true, false)]
    private RealtimeDictionary<UserScoreModel> _players;
}