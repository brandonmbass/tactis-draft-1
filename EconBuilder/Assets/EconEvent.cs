using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using EconEventHandler = System.Func<EconEventArgs, EconEventArgs>;

public class EconEvent
{

    private List<EconEventHandler> Handlers = new List<EconEventHandler>();

    public EconEventHandler AddListener(EconEventHandler handler)
    {
        Handlers.Insert(0, handler);
        return handler;
    }

    public EconEventHandler AddListener(Action<EconEventArgs> handler)
    {
        return AddListener((eg) => { handler(eg); return eg; });
    }

    public void RemoveListener(EconEventHandler handler)
    {
        Handlers.Remove(handler);
    }

    public void Invoke()
    {
        var args = new EconEventArgs();
        args.KeysPressed = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().Where(k => Input.GetKeyDown(k)).ToList();

        var handlersToRemove = new List<EconEventHandler>();

        foreach (var handler in Handlers)
        {
            var response = handler(args);

            if (response.RemoveHandler)
            {
                handlersToRemove.Add(handler);
            }

            // Reset args
            args.RemoveHandler = false;
        }

        foreach (var handler in handlersToRemove)
        {
            Handlers.Remove(handler);
        }
    }
}

public class EconEventArgs
{
    // TODO: having this both be input and output seems a bit sloppy (for example, RemoveSelf makes no sense as an input param); worth changing?
    public IList<KeyCode> KeysPressed { get; set; }

    public bool RemoveHandler { get; set; }

    // Helpers
    public bool IsPressed(KeyCode code)
    {
        return KeysPressed.Contains(code);
    }

    public EconEventArgs RemoveSelf()
    {
        RemoveHandler = true;
        return this;
    }

    public EconEventArgs RemoveKeys(params KeyCode[] codes)
    {
        foreach (var code in codes)
        {
            KeysPressed.Remove(code);
        }

        return this;
    }

    public EconEventArgs RemoveAllKeys()
    {
        KeysPressed.Clear();
        return this;
    }

    public EconEventArgs ClearKeys()
    {
        KeysPressed.Clear();
        return this;
    }
}
