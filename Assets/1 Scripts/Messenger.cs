using System;
using System.Collections.Generic;

public class Messenger {

    private static List<Listener> listeners = new List<Listener>();

    public static void WaitForMessage(string tagToWaitFor, Action<string> callback) {
        listeners.Add(new Listener(tagToWaitFor, callback));
    }

    public static void PublishMessage(string tag, string message) {
        var listenersCopy = new List<Listener>(listeners);
        foreach (var listener in listenersCopy) {
            if (tag == listener.Tag) {
                listener.Callback(message);
                listeners.Remove(listener);
                break;
            }
        }
    }

    public static void ClearMessageListeners() => listeners.Clear();

    private class Listener {
        public string Tag { get; }
        public Action<string> Callback { get; }
        public Listener(string tag, Action<string> callback) {
            Tag = tag;
            Callback = callback;
        }
    }
}
