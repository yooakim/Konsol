using Serilog;

public class Runner
 {
     private readonly ILogger _log;

     public Runner(ILogger log)
     {
         _log = log;
     }

     public void DoAction(string name)
     {
         _log.Debug("Doing hard work! {Action}", name);
     }


 }