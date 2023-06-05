using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace Core.Extensions;

public static class StackTraceExtensions
{
    private static readonly string[] projectNames = { "API", "BusinessLayer", "RepositoryLayer", "Core" };

    public static StackFrame? GeFirstFrame(this StackTrace stackTrace)
    {
        foreach (StackFrame stackFrame in stackTrace.GetFrames())
        {
            var methodDeclaringType = stackFrame.GetMethod()!.DeclaringType;
            
            if(methodDeclaringType == null)
            {
                break;
            }

            var assemblyProjectName = methodDeclaringType.Assembly.FullName!.Split(',').FirstOrDefault();

            bool marked = stackFrame.GetMethod()!.DeclaringType!.CustomAttributes.Any(ca => ca.AttributeType == typeof(StackTraceHiddenAttribute));

            if (!marked && projectNames.Any(n => n.Equals(assemblyProjectName)))
            {
                return stackFrame;
            }
        }

        return null;
    }
}