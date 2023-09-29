using System.Collections;
using System.Collections.Generic;
using System;

public class KeySocketEventArgs : EventArgs
{
    public KeySocketEventArgs(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}
