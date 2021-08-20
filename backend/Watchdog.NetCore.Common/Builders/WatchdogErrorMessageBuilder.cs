using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.NetCore.Common.Builders
{
    public class WatchdogErrorMessageBuilder
    {
        protected WatchdogErrorMessageBuilder()
        {
        }

        protected static string FormatTypeName(Type type, bool fullName)
        {
            string name = fullName ? type.FullName : type.Name;
            if (!type.IsConstructedGenericType)
            {
                return name;
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(name.Substring(0, name.IndexOf("`")));
            stringBuilder.Append('<');
            foreach (Type t in type.GenericTypeArguments)
            {
                stringBuilder.Append(FormatTypeName(t, false)).Append(',');
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append('>');

            return stringBuilder.ToString();
        }

        protected static WatchdogErrorStackTraceLineMessage[] BuildStackTrace(Exception exception)
        {
            var stackTrace = new StackTrace(exception, true);

            return BuildStackTrace(stackTrace);
        }

        public static WatchdogErrorStackTraceLineMessage[] BuildStackTrace(StackTrace stackTrace)
        {
            var lines = new List<WatchdogErrorStackTraceLineMessage>();

            var frames = stackTrace.GetFrames();

            if (frames == null || frames.Length == 0)
            {
                var line = new WatchdogErrorStackTraceLineMessage { FileName = "none", LineNumber = 0 };
                lines.Add(line);

                return lines.ToArray();
            }

            foreach (StackFrame frame in frames)
            {
                MethodBase method = frame.GetMethod();

                if (method != null)
                {
                    int lineNumber = frame.GetFileLineNumber();
                    int columnNumber = frame.GetFileColumnNumber();

                    if (lineNumber == 0)
                    {
                        lineNumber = frame.GetILOffset();
                    }

                    var methodName = GenerateMethodName(method);

                    string file = frame.GetFileName();

                    string className = method.DeclaringType != null ? method.DeclaringType.FullName : "(unknown)";

                    var line = new WatchdogErrorStackTraceLineMessage
                    {
                        FileName = file,
                        LineNumber = lineNumber,
                        ColumnNumber = columnNumber,
                        MethodName = methodName,
                        ClassName = className
                    };

                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }

        protected static string GenerateMethodName(MethodBase method)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(method.Name);

            bool first = true;

            if (method is MethodInfo && method.IsGenericMethod)
            {
                Type[] genericArguments = method.GetGenericArguments();
                stringBuilder.Append('[');

                for (int i = 0; i < genericArguments.Length; i++)
                {
                    if (!first)
                    {
                        stringBuilder.Append(',');
                    }
                    else
                    {
                        first = false;
                    }

                    stringBuilder.Append(genericArguments[i].Name);
                }

                stringBuilder.Append(']');
            }

            stringBuilder.Append('(');

            ParameterInfo[] parameters = method.GetParameters();

            first = true;

            for (int i = 0; i < parameters.Length; ++i)
            {
                if (!first)
                {
                    stringBuilder.Append(", ");
                }
                else
                {
                    first = false;
                }

                string type = "<UnknownType>";

                if (parameters[i].ParameterType != null)
                {
                    type = parameters[i].ParameterType.Name;
                }

                stringBuilder.Append(type + " " + parameters[i].Name);
            }

            stringBuilder.Append(')');

            return stringBuilder.ToString();
        }

        public static WatchdogErrorMessage Build(Exception exception)
        {
            WatchdogErrorMessage message = new WatchdogErrorMessage();

            var exceptionType = exception.GetType();

            message.Message = exception.Message;
            message.ClassName = FormatTypeName(exceptionType, true);

            message.StackTrace = BuildStackTrace(exception);

            AggregateException ae = exception as AggregateException;

            if (ae != null && ae.InnerExceptions != null)
            {
                message.InnerErrors = new WatchdogErrorMessage[ae.InnerExceptions.Count];
                int index = 0;

                foreach (Exception e in ae.InnerExceptions)
                {
                    message.InnerErrors[index] = Build(e);
                    index++;
                }
            }
            else if (exception.InnerException != null)
            {
                message.InnerError = Build(exception.InnerException);
            }

            return message;
        }
    }
}
