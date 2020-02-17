using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting;
using System.Text;

namespace ProcessesAppDomains
{
    class IsolationInvoke
    {
        public string LibPath { get; set; }

        public string MethoName { get; set; }

        public object[] Params { get; set; }

        public IsolationInvoke()
        {

        }

        public IsolationInvoke(string libpath, string method, object[] par)
        {
            Params = par;
            MethoName = method;
            LibPath = libpath;
        }

        public void InvokeMethod()
        {
            //validate directory
            string paht = GetValidatePath();

            AppDomain secondDomain = AppDomain.CreateDomain("Second domain");

            Type LadaSedanType = Type.GetType("CarPro.LadaSedan, Cars");

            ObjectHandle userHandle = secondDomain.CreateInstance("Cars", LadaSedanType.Name);

            dynamic userProxy = userHandle.Unwrap();

            if (RemotingServices.IsTransparentProxy(userProxy))
            {

            }


        }

        private string GetValidatePath()
        {
            if (File.Exists(LibPath))
                return LibPath;

            throw new FileNotFoundException($"file {LibPath} doesn't exist");
        }
    }
}
