using Nancy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationService
{
    public class FakeModule: NancyModule
    {
        public FakeModule() : base("/fake")
        {
            Post("/notification/", async (parameters) =>
            {
                await Task.Run(async () => 
                {
                    Debug.WriteLine("Start");
                    await Task.Delay(5000);
                    Debug.WriteLine("Done");
                });
            });
        }
    }
}
