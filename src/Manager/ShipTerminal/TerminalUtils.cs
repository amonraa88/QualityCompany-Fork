﻿using JetBrains.Annotations;
using UnityEngine;

namespace QualityCompany.Manager.ShipTerminal;

/// <summary>
/// Terminal utils serves some helpful terminal thingsd
/// </summary>
public class TerminalUtils
{
    private static string ConfirmMessage = "Confirmed!";
    private static string DenyMessage = "Cancelled!";

    public static TerminalNode CreateNodeEmpty(bool clear = true)
    {
        var node = ScriptableObject.CreateInstance<TerminalNode>();

        node.clearPreviousText = clear;

        return node;
    }

    public static TerminalNode CreateNode(
        string name,
        string? text = null,
        string? terminalEvent = null,
        bool? clear = true,
        bool? confirmOrDeny = false)
    {
        var node = ScriptableObject.CreateInstance<TerminalNode>();

        node.name = name;
        node.clearPreviousText = clear ?? true;
        node.displayText = (text ?? "Empty") + AdvancedTerminal.EndOfMessage;
        node.terminalEvent = terminalEvent ?? $"{name}_event";
        node.isConfirmationNode = confirmOrDeny ?? true;

        return node;
    }

    public static TerminalNode CreateConfirmNode(string name, string? confirmText, string? terminalEvent = null)
    {
        return CreateNode($"{name}_confirm", confirmText ?? ConfirmMessage, terminalEvent ?? $"{name}_event");
    }

    public static TerminalNode CreateDenyNode(string name, string? denyText)
    {
        return CreateNode($"{name}_deny", denyText ?? ConfirmMessage);
    }
}