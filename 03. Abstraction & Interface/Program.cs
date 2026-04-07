// public interface INotify{
//   public void Send();
//   public void Log();
//   public void Save();
// }

// public class EmailNotify : INotify {
//   public string? Email {get; set;}

//   public void Send(){
//      Console.WriteLine("Sending Email to " + Email);
//   }
  
//   public void Log(){
//      Console.WriteLine("Logging Email to " + Email);
//   }
  
//   public void Save(){
//      Console.WriteLine("Saving DB to " + Email);
//   }
// }

// public class SMSNotify : INotify{
//   public string? Phone {get; set;}

//   public void Send(){
//      Console.WriteLine("Sending SMS to " + Phone);
//   }

//   public void Log(){
//      Console.WriteLine("Logging SMS to " + Phone);
//   }

//   public void Save(){
//      Console.WriteLine("Saving DB to " + Phone);
//   }
// }

// // new feature reuest by clinet -> push notification

// public class PushNotify : INotify{
//   public string? Token {get; set;}

//   public void Send(){
//      Console.WriteLine("Sending Push to " + Token);
//   }

//   public void Log(){
//      Console.WriteLine("Logging Push to " + Token);
//   }

//   public void Save(){               
//      // Console.WriteLine("Saving DB to " + Token). 
//      // Interface Segregation Principle
//   }
// }

// public class NotifyContext {
//   public INotify notify {get; set;}

//   public NotifyContext(INotify notify){
//     this.notify = notify;
//   }
//   public void Process(){
//     notify.Send();
//     notify.Log();
//     notify.Save();
//   }
// }

// class Program {
//   public static void Main(string[] args){

//     // INotify emailNotify = new EmailNotify{ Email = "test@test.com" };
//     // emailNotify.Send();
//     // emailNotify.Log();
//     // emailNotify.Save();

//     // INotify smsNotify = new SMSNotify{ Phone = "123456789" };
//     // smsNotify.Send();
//     // smsNotify.Log();
//     // smsNotify.Save();

    
//     // IList<INotify> notifies = new List<INotify>{
//     //    new EmailNotify{ Email = "test@test.com" },
//     //    new SMSNotify{ Phone = "123456789" }
//     // };

//     // foreach(var notify in notifies){
//     //   notify.Send();
//     //   notify.Log();
//     //   notify.Save();


//     IList<NotifyContext> notifyContexts = new List<NotifyContext>(); 
    
//     INotify emailNotify = new EmailNotify{ Email = "test@test.com" };
//     NotifyContext emailNotifyContext = new NotifyContext(emailNotify);

//     INotify smsNotify = new SMSNotify{ Phone = "123456789" };
//     NotifyContext smsNotifyContext = new NotifyContext(smsNotify);

//     INotify pushNotify = new PushNotify{ Token = "2222222" };
//     NotifyContext pushNotifyContext = new NotifyContext(pushNotify);
    
//     notifyContexts.Add(emailNotifyContext);
//     notifyContexts.Add(smsNotifyContext);
//     notifyContexts.Add(pushNotifyContext);

//     foreach(var notifyContext in notifyContexts){
//       Console.WriteLine("----------------------------");
//       notifyContext.Process(); 
//     }
    
//     // IList<NotifyContext> notifyContexts = new List<NotifyContext>{
//     //    new NotifyContext(new EmailNotify{ Email = "test@test.com" }),  
//     //    new NotifyContext(new SMSNotify{ Phone = "123456789" }),
//     //    new NotifyContext(new PushNotify{ Token = "2222222" })
//     // };
//   }
// }



// -------------------------------- Multiple Interface ------------------------
public interface ISend{
  public void Send();
}

public interface ILog{
  public void Log();
}

public interface ISave{
  public void Save();
}


public class EmailNotify : ISend, ILog, ISave {
  public string? Email {get; set;}

  public void Send(){
     Console.WriteLine("Sending Email to " + Email);
  }

  public void Log(){
     Console.WriteLine("Logging Email to " + Email);
  }

  public void Save(){
     Console.WriteLine("Saving DB to " + Email);
  }
}

public class SMSNotify : ISend, ILog, ISave {
  public string? Phone {get; set;}

  public void Send(){
     Console.WriteLine("Sending SMS to " + Phone);
  }

  public void Log(){
     Console.WriteLine("Logging SMS to " + Phone);
  }

  public void Save(){
     Console.WriteLine("Saving DB to " + Phone);
  }
}

// new feature reuest by clinet -> push notification

public class PushNotify : ISend, ILog {
  public string? Token {get; set;}

  public void Send(){
     Console.WriteLine("Sending Push to " + Token);
  }

  public void Log(){
     Console.WriteLine("Logging Push to " + Token);
  }

}

public class NotifyContext {
  public ISend send {get; set;}
  public ILog log {get; set;}
  public ISave save {get; set;}

  public NotifyContext(ISend send, ILog log, ISave save){
    this.send = send;
    this.log = log;
    this.save = save;
  }
  public void Process(){
    send.Send();
    log.Log();

    if (save != null){
      save.Save();
    }
  }
}

class Program {
  public static void Main(string[] args){

    NotifyContext notifyContextEmail = new NotifyContext(
      new EmailNotify{ Email = "test@test.com" },
      new EmailNotify{ Email = "test@test.com" },
      new EmailNotify{ Email = "test@test.com" }
    );

    NotifyContext notifyContextSms = new NotifyContext(
      new SMSNotify{ Phone = "123456789" },
      new SMSNotify{ Phone = "123456789" },
      new SMSNotify{ Phone = "123456789" }
    );

    NotifyContext notifyContextPush = new NotifyContext(
      new PushNotify{ Token = "2222222" },
      new PushNotify{ Token = "2222222" },
      null
    );

    notifyContextEmail.Process();
    notifyContextSms.Process();
    notifyContextPush.Process();
  }
}