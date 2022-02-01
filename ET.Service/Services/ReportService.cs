using ET.Constracts.ReportContracts;
using ET.Domain.CarAgg;
using ET.Domain.RequestAgg;
using ET.Domain.UserAgg;

namespace ET.Service.Services
{
   public class ReportService : IReportService
   {
      private readonly IUserRepository _userRepository;
      private readonly IRequestRepository _requestRepository;
      private readonly ICarRepository _carRepository;

      #region Ctor
      public ReportService(IUserRepository userRepository, IRequestRepository requestRepository, ICarRepository carRepository)
      {
         _userRepository = userRepository;
         _requestRepository = requestRepository;
         _carRepository = carRepository;
      } 
      #endregion

      public int CarCount => _carRepository.CarCount();

      public int UserCount => _userRepository.UserCount(false);

      public int DeActiveUserCount => _userRepository.UserCount(true);

      public int DriverCount => _userRepository.DriverCount(false);

      public int DeActiveDriverCount => _userRepository.DriverCount(true);

      public int RequestCount => _requestRepository.RequestCount();

      public int DoneRequestCont => _requestRepository.RequestCount(RequestStatuses.Done);

      public int CancelRequestCount => _requestRepository.RequestCount(RequestStatuses.Canceled);

      public int WaitingRequestCont => _requestRepository.RequestCount(RequestStatuses.Waiting);
   }
}
