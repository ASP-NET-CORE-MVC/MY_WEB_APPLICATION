namespace ViewModels
{
	public class ErrorViewModel : object
	{
		public ErrorViewModel() : base()
		{
		}

		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
