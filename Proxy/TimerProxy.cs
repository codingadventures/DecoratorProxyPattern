using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Threading;

namespace DecoratorProxyPattern.Proxy
{
    public class TimerProxy<T> : RealProxy
    {
        private readonly Stopwatch _stopwatch;

        private readonly T _decorated;

        public TimerProxy(T decorated)
            : base(typeof (T))
        {
            _decorated = decorated;
            _stopwatch = new Stopwatch();
        }

        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;

            try
            {
                Log("In Timer Proxy - Start Taking Time",
                    methodCall.MethodName);
                _stopwatch.Start();
                Thread.Sleep(33);
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                _stopwatch.Stop();
                Log(string.Format("In Timer Proxy - After Adding - {0} - Time {1}", methodCall.InArgs,
                    _stopwatch.ElapsedMilliseconds));
                _stopwatch.Reset();

                return new ReturnMessage(result, null, 0,
                    methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {

                return new ReturnMessage(e, methodCall);
            }
        }
    }
} 
