using Camera.MAUI;

namespace TruthOrDrinkAppMac;

public partial class JoinGamePage : ContentPage
{
	public JoinGamePage()
	{
		InitializeComponent();
	}

    private void CameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = new CameraView().Cameras.First();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void cameraView_BarcodeDetected(object sender, 
        Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            barcodeResult.Text = $"{args.Result[0].BarcodeFormat}: {args.Result[0].Text}";
        });
    }
}