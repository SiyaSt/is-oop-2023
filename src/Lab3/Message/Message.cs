using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public record Message
{
    public Message(string header, string text, ImportanceLevel importanceLevel, DateTime dateTime)
    {
        Header = header;
        Text = text;
        ImportanceLevel = importanceLevel;
        DateTime = dateTime;
    }

    public string Header { get; }
    public string Text { get; }
    public ImportanceLevel ImportanceLevel { get; }
    public DateTime DateTime { get; }
}