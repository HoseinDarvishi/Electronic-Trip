namespace ET.Constracts.ReportContracts
{
   public interface IReportService
   {
      int CarCount { get; }
      int UserCount { get; }
      int DeActiveUserCount { get; }
      int DriverCount { get; }
      int DeActiveDriverCount { get; }
      int RequestCount { get; }
      int DoneRequestCont { get; }
      int CancelRequestCount { get; }
      int WaitingRequestCont { get; }
   }
}
