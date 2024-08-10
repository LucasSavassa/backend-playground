using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;
using Windows.System.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhotographService
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private MediaCapture _media;
        private bool _isPreviewing;
        private DisplayRequest _displayRequest = new DisplayRequest();
        private int _interval = 10;
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await StartPreviewAsync();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (_localSettings.Values.ContainsKey("Interval"))
            {
                _interval = (int)_localSettings.Values["Interval"];
            }
            else
            {
                _localSettings.Values["Interval"] = _interval;
            }
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            await StartCapturing(cancellationToken);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private async Task StartCapturing(CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                while (true)
                {
                    await CapturePhotoAsync();
                    await Task.Delay(TimeSpan.FromSeconds(_interval), token);
                }
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }

        private async Task StartPreviewAsync()
        {
            try
            {
                _media = new MediaCapture();
                await _media.InitializeAsync();

                _displayRequest.RequestActive();
                DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;
            }
            catch (UnauthorizedAccessException)
            {
                // This will be thrown if the user denied access to the camera in privacy settings
                // Show a message to the user to say that the app needs access to the camera
                return;
            }

            try
            {
                PreviewControl.Source = _media;
                await _media.StartPreviewAsync();
                _isPreviewing = true;
            }
            catch (System.IO.FileLoadException)
            {
                _media.CaptureDeviceExclusiveControlStatusChanged += _mediaCapture_CaptureDeviceExclusiveControlStatusChanged;
            }
        }
        private async void _mediaCapture_CaptureDeviceExclusiveControlStatusChanged(MediaCapture sender, MediaCaptureDeviceExclusiveControlStatusChangedEventArgs args)
        {
            if (args.Status == MediaCaptureDeviceExclusiveControlStatus.SharedReadOnlyAvailable)
            {
                return;
            }
            else if (args.Status == MediaCaptureDeviceExclusiveControlStatus.ExclusiveControlAvailable && !_isPreviewing)
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    await StartPreviewAsync();
                });
            }
        }

        private async Task CapturePhotoAsync()
        {
            await CapturePhotoToUI();
            await CapturePhotoToFile();
        }

        private async Task CapturePhotoToUI()
        {
            var lowLagCapture = await _media.PrepareLowLagPhotoCaptureAsync(ImageEncodingProperties.CreateUncompressed(MediaPixelFormat.Bgra8));
            var capturedPhoto = await lowLagCapture.CaptureAsync();
            var softwareBitmap = capturedPhoto.Frame.SoftwareBitmap;

            if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 || softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
            {
                softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
            }

            SoftwareBitmapSource source = new SoftwareBitmapSource();
            await source.SetBitmapAsync(softwareBitmap);
            CapturedImage.Source = source;

            await lowLagCapture.FinishAsync();
        }

        private async Task CapturePhotoToFile()
        {
            StorageLibrary root = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
            StorageFolder folder = await root.SaveFolder.CreateFolderAsync("Portraits", CreationCollisionOption.OpenIfExists);
            StorageFile photoFile = await folder.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);

            using (var captureStream = new InMemoryRandomAccessStream())
            {
                await _media.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), captureStream);
                using (var photoStream = await photoFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    var decoder = await BitmapDecoder.CreateAsync(captureStream);
                    var encoder = await BitmapEncoder.CreateForTranscodingAsync(photoStream, decoder);
                    var imageProperties = new BitmapPropertySet { { "System.Photo.Orientation", new BitmapTypedValue(PhotoOrientation.Normal, PropertyType.UInt16) } };
                    await encoder.BitmapProperties.SetPropertiesAsync(imageProperties);
                    await encoder.FlushAsync();
                }
            }

            ImageProperties fileProperties = await photoFile.Properties.GetImagePropertiesAsync();
            DateTimeOffset dateTaken = fileProperties.DateTaken;
            await photoFile.RenameAsync($"{dateTaken:HH-mm-ss}.jpg", NameCollisionOption.GenerateUniqueName);
        }
    }
}
