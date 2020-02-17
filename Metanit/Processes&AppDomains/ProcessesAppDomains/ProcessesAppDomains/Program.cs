using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Remoting;

namespace ProcessesAppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            Process proc = Process.GetCurrentProcess();

            foreach (ProcessThread item in proc.Threads)
            {
                //Console.WriteLine(item.Id);
            }

            (from currentprocess in Process.GetProcesses(".") orderby currentprocess.ProcessName select currentprocess)
                .Distinct(new ProcessComparer())
                .AsParallel()
                .ForAll(x => Console.WriteLine(x.ProcessName));

            var modules = proc.Modules.OfType<ProcessModule>();

            (from m in modules orderby m.ModuleName select m)
                .AsParallel()
                .ForAll(x => Console.WriteLine(x.ModuleName));

            Console.WriteLine(new string('=', 20) + " DOMAIN =>");

            AppDomain defDomain = AppDomain.CurrentDomain;

            Console.WriteLine(new string('=', 20) + " DOMAIN TEST EVENT LOAD ASSMS =>");

            defDomain.AssemblyLoad += (ob, args) => Console.WriteLine(args.LoadedAssembly.GetName().Name);

            Console.WriteLine(defDomain.FriendlyName);

            Console.WriteLine(new string('=', 20) + " DOMAIN ASSMS =>");

            var assms = from asm in defDomain.GetAssemblies() orderby asm.GetName().Name select asm;

            foreach (var item in assms)
            {
                Console.WriteLine(item.GetName().Name);
            }            

            Console.ReadKey();
        }

        class ProcessComparer : IEqualityComparer<Process>
        {
            public bool Equals([AllowNull] Process x, [AllowNull] Process y)
            {
                return x.ProcessName == y.ProcessName;
            }

            public int GetHashCode([DisallowNull] Process obj)
            {
                return 0;
            }
        }

    }
}
