using Interfaces;
using Interfaces.workflows;
WorkFlowEngine engine=new WorkFlowEngine();

VideoCloudStorage storage=new VideoCloudStorage();
VideoEncoding videoEncoding=new VideoEncoding();
VideoStatus videoStatus=new VideoStatus();  
EmailSending emailSending=new EmailSending();

WorkFlow work = new WorkFlow(emailSending);
work.addActivity(storage);
work.addActivity(videoEncoding);
work.addActivity(emailSending);
work.addActivity(videoStatus);
engine.run(work);

Console.WriteLine();
work.removeActivity(videoEncoding);
engine.run(work);
