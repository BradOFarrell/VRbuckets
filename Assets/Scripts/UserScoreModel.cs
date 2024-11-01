using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class UserScoreModel
{
    [RealtimeProperty(1, true, false)]
    private int _score;
}