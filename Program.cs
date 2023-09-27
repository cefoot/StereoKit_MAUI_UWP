using StereoKit;

namespace SKTemplate_Multi;

class Program
{
	static void Main(string[] args)
	{

		var app = new StereoKitApp.StereoApp();
		if (!SK.Initialize(app.Settings))
			return;
		app.Init();

		// Core application loop
		SK.Run(app.Step);
	}
}