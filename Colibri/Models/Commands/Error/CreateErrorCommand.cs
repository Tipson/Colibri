namespace Colibri.Models.Commands.Error;

public record CreateErrorCommand(
    string Message,
    string Controller,
    string Method,
    string Source);