using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventIdNorm {
    private static string Adjust(string input)
    {
        return input.Replace("_", "").ToUpper();
    }
    // an int for your eventcontroller.StartListenForEvent function.
    // it's a kind of anti-hash because it ignores case and underscores
    // but adds some salt with the nastiest pun ever
    public static int Hash(string yourName, string description)
    {
        string sault = "Better Call Saul!";
        string tmp = sault + Adjust(yourName) + Adjust(description);
        return tmp.GetHashCode();
    }
}
