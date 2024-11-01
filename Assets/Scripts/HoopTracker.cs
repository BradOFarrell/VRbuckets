using Normal.Realtime;
using UnityEngine;

public class HoopTracker : MonoBehaviour {
    [SerializeField]
    private ScoreboardSync scoreboardSync;
    [SerializeField]
    private GameObject myVRPlayer;
    [SerializeField]
    private TrickshotTracker trickshotTracker;
    private Realtime myRealtime;
    private ColorSync colorSync;
    private RealtimeView realtimeView;
    private ForceDrop forceDrop;
    private bool consecutive = false;
    private bool topTrigger = false;
    private bool hoopTrigger = false;
    private bool bottomTrigger = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        colorSync = GetComponent<ColorSync>();
        forceDrop = GetComponent<ForceDrop>();
        realtimeView = GetComponent<RealtimeView>();
        myRealtime = myVRPlayer.GetComponent<Realtime>();
    }

    public void ResetTriggers()
    {
        topTrigger = false;
        hoopTrigger = false;
        bottomTrigger = false;
    }

    public void TriggerTop()
    {
        topTrigger = true;
        bottomTrigger = false;
    }
    public void TriggerHoop()
    {
        hoopTrigger = true;
        forceDrop.Drop();
    }

    public void TriggerBottom()
    {
        forceDrop.Drop();
        if (topTrigger && hoopTrigger && !bottomTrigger) {
            scoreBall();
        } else {
            bottomTrigger = true;
            GetComponentInParent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
    private void scoreBall()
    {
        int myClientID = myRealtime.clientID; 
        int ballOwnerID = realtimeView.ownerIDSelf;
        bool trickshot = trickshotTracker.getTrickshotBonus();
        uint uID;
        if (ballOwnerID % 2 == 0)
        {
            uID = 0;
        }
        else
        {
            uID = 1;
        }
        Debug.Log(myClientID);
        Debug.Log(uID);
        if (ballOwnerID == myClientID) {
            scoreboardSync.IncrementScore(uID, trickshot, consecutive);
            colorSync.ResetOwnershipColor();
            consecutive = true;
        }
        else {
            consecutive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
