using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkHandler {
    static private bool done = false;
    static private string data = null;
    static private Thread thread = null;

    static private void getHTTP(string uri)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        WebProxy myProxy = new WebProxy();

        myProxy.Address = new System.Uri("");
        request.Proxy = myProxy;

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new WebException("NetworkHandler Error: response status code was NOT HttpStatusCode.OK but: " + response.StatusCode + "   description: " + response.StatusDescription);
        }

        Stream receiveStream = response.GetResponseStream();
        StreamReader readStream = null;

        if (response.CharacterSet == null)
        {
            readStream = new StreamReader(receiveStream);
        }
        else
        {
            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
        }

        // ending routine:
        data = readStream.ReadToEnd();
        response.Close();
        readStream.Close();
        done = true;
    }

    /// dont be scared. you can just do a if statement (instead of a while statement) because the
    /// function (if it's on the call stack of MonoBehaivor.Start) gets nevertheless called once per
    /// frame. that means you could just do: [if done, display text] [if not done, display "loading..."]
    static public bool isDone()
    {
        return done;
    }

    static public string getData()
    {
        return data;
    }

    static public void sendHTTPRequest(string uri)
    {
        done = false;
        data = null;
        Thread thread = new Thread(() => getHTTP(uri));
        thread.Start();
    }

}
