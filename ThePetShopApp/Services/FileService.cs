namespace ThePetShopApp.Services
{
	public class FileService
	{
		private readonly IWebHostEnvironment host;

		public FileService(IWebHostEnvironment host)
		{
			this.host = host;
		}

		public string UploadToWebRoot(IFormFile file)
		{
			var filePath = Path.Combine(host.WebRootPath, "img", file.FileName);

			if (!File.Exists(filePath))
				using (var fs = new FileStream(filePath, FileMode.Create))
					file.CopyTo(fs);

			return $" /img/{file.FileName}";
		}

	}
}

