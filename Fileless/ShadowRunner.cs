using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fileless
{
    public class ShadowRunner : MarshalByRefObject
    {
        public void LoadAssembly(byte[] assembly, string[] args)
        {
            var loader = new TransactedAssembly();
            var asm = loader.Load(assembly,args[0]);
            //asm.EntryPoint.Invoke(null, new object[] { args });
            try
            {
                Console.WriteLine("ShadowRunner.Args[0]:{0}",args[0]);
                if (args[0] == "Fileless.exe")
                {
                    Console.WriteLine("Bypassing Fileless.exe");
                }
                else
                {
                    asm.EntryPoint.Invoke(null, new object[] { new[] { "klist" } });
                }
            }
            catch(Exception e)
            {

            }
            
        }
    }
}
