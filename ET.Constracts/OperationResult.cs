namespace ET.Constracts
{
   public class OperationResult
   {
      public string Message { get; set; }
      public bool IsSuccess { get; set; }

      public OperationResult Success(string message)
      {
         Message = message;
         IsSuccess = true;
         return this;
      }

      public OperationResult Failed(string message)
      {
         Message = message;
         IsSuccess = false;
         return this;
      }
   }
}
