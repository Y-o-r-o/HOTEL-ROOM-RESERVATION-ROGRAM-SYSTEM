using BusinessLayer.DTOs;
using Core.Extensions;
using System.Diagnostics;

namespace API.Extensions;

public static class ExceptionExtensions
{
    public static AdditionalInformationDTO? AnalyzeException(this Exception ex)
    {
        var trace = new StackTrace(ex, true);

        var stackFrame = trace.GeFirstFrame();

        if (stackFrame == null)
        {
            return null;
        }

        var reflectedType = stackFrame.GetMethod()!.ReflectedType;

        if (reflectedType == null)
        {
            return null;
        }

        return new AdditionalInformationDTO()
        {
            InnerMessage = ex.InnerException == null ? "There is no inner message." : ex.InnerException.Message,
            Column = stackFrame.GetFileColumnNumber(),
            Line = stackFrame.GetFileLineNumber(),
            MethodName = reflectedType.FullName,
            File = stackFrame.GetFileName()
        };
    }
}