
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;

namespace TestLamaWithDocker
{



    public class LogAspectAttribute : OverrideMethodAspect
    {

        public override void BuildAspect(IAspectBuilder<IMethod> builder)
        {
            base.BuildAspect(builder);


        }
        public override dynamic? OverrideMethod()
        {
            Console.WriteLine($"before {meta.Target.Method} Calling");

            try
            {
                return meta.Proceed();
            }
            finally
            {
                Console.WriteLine($"After {meta.Target.Method} Calling");
            }
        }
    }


}
